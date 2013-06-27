using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sentimentaly
{
    public class SentimentalAnalyser
    {
        public static List<AdjectiveClassification> positives = new List<AdjectiveClassification>();
        public static List<AdjectiveClassification> neutral = new List<AdjectiveClassification>();
        public static List<AdjectiveClassification> negatives = new List<AdjectiveClassification>();

        private const string NO_PONCTUATION = "[^a-zA-Z ]+";
        private const string NO_SPACES = "[/ {2,}/]";

        /// <summary>
        /// Normalizes the specified phrase.
        /// </summary>
        /// <param name="phrase">The phrase.</param>
        /// <returns></returns>
        private string Normalize(string phrase)
        {
            return (new Regex(NO_SPACES)).Replace((new Regex(NO_PONCTUATION)).Replace(phrase, ""), " ");
        }    

        /// <summary>
        /// Initializes a new instance of the <see cref="SentimentalAnalyser"/> class.
        /// </summary>
        public SentimentalAnalyser()
        {
            if (positives.Count == 0 || negatives.Count == 0)
            {
                positives.Clear();
                negatives.Clear();

                this.LoadDictionary();
            }
        }

        /// <summary>
        /// Loads the dictionary.
        /// </summary>
        private void LoadDictionary()
        {
            string[] lines = System.IO.File.ReadAllText(".\\SentiLex-flex-PT02.txt", Encoding.UTF8).Split(new char[] { '\n' });

            foreach (string line in lines)
            {
                if (line == "")
                {
                    continue;
                }

                AdjectiveClassification classification = new AdjectiveClassification();

                string[] linesplited = line.Split(new char[] { '.', ';' });

                // Get text
                string text = linesplited[0].Substring(0, line.IndexOf(","));
                string pol = linesplited[4].Split('=')[1];
                string gn = linesplited[2].Split('=')[1];

                switch (gn)
                {
                    case "ms":
                        classification.Forme = Forme.M;
                        classification.Genere = Genere.S;
                        break;
                    case "mp":
                        classification.Forme = Forme.M;
                        classification.Genere = Genere.P;
                        break;
                    case "fp":
                        classification.Forme = Forme.F;
                        classification.Genere = Genere.S;
                        break;
                    case "fs":
                        classification.Forme = Forme.F;
                        classification.Genere = Genere.P;
                        break;
                }

                classification.Text = Util.ToUnicode(text).ToLowerInvariant();
                classification.Polarity = Convert.ToInt32(pol);

                switch (classification.Polarity)
                {
                    case 1:
                        positives.Add(classification);
                        break;
                    case -1:
                        negatives.Add(classification);
                        break;
                    default:
                        neutral.Add(classification);
                        break;
                }
            }
        }


        /// <summary>
        /// Determines whether the specified sentence is word.
        /// </summary>
        /// <param name="sentence">The sentence.</param>
        /// <returns>
        ///   <c>true</c> if the specified sentence is word; otherwise, <c>false</c>.
        /// </returns>
        private bool IsWord(string sentence)
        {
            if (IsAdjective(sentence, neutral) == true)
            {
                return true;
            }
            else
            {
                return Regex.Matches(sentence, @"[\S]+").Count == 1;
            }           
        }

        /// <summary>
        /// Determines whether the specified sentence is adjective.
        /// </summary>
        /// <param name="sentence">The sentence.</param>
        /// <param name="adjectives">The adjectives.</param>
        /// <returns>
        ///   <c>true</c> if the specified sentence is adjective; otherwise, <c>false</c>.
        /// </returns>
        private bool IsAdjective(string sentence, List<AdjectiveClassification> adjectives)
        {
            foreach (AdjectiveClassification adjective in adjectives)
            {
                if (adjective == null)
                {
                    continue;
                }

                if (adjective.Text.Trim() == sentence.Trim())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Positivities the specified phrase.
        /// </summary>
        /// <param name="phrase">The phrase.</param>
        /// <returns></returns>
        private SentenceInfo Positivity(string phrase)
        {
            string strNormalized = Normalize(phrase); // Create a temp copy
            int hits = 0;

            List<string> tokens = strNormalized.ToLowerInvariant().Split(' ').ToList<string>();
            List<string> words = new List<string>();
            List<string> adjectives = new List<string>();

            for (int i = 0; i < tokens.Count; i++)
            {
                if (this.IsWord(tokens[i]) == true)
                {
                    hits += 1;
                    words.Add(tokens[i]);
                }

                if (this.IsAdjective(tokens[i], positives) == true)
                {
                    if (i != 0)
                    {
                        if (this.IsAdjective(tokens[i - 1], negatives) == true)
                        {
                            continue;
                        }
                    }

                    hits *= 2;
                    adjectives.Add(tokens[i]);
                }
            }

            SentenceInfo sentenceInfo = new SentenceInfo();
            sentenceInfo.Score = hits;
            sentenceInfo.Comparative = decimal.Divide(hits, tokens.Count);
            sentenceInfo.Words = words.ToArray();
            sentenceInfo.Adjectives = adjectives.ToArray();

            return sentenceInfo;
        }

        /// <summary>
        /// Negativities the specified phrase.
        /// </summary>
        /// <param name="phrase">The phrase.</param>
        /// <returns></returns>
        private SentenceInfo Negativity(string phrase)
        {
            string strNormalized = Normalize(phrase); // Create a temp copy
            int hits = 0;

            List<string> tokens = strNormalized.ToLowerInvariant().Split(' ').ToList<string>();
            List<string> words = new List<string>();
            List<string> adjectives = new List<string>();

            for (int i = 0; i < tokens.Count; i++)
            {
                if (this.IsWord(tokens[i]) == true)
                {
                    hits += 1;
                    words.Add(tokens[i]);
                }

                if (this.IsAdjective(tokens[i], negatives) == true)
                {
                    if (i != 0)
                    {
                        if (this.IsAdjective(tokens[i - 1], positives) == true)
                        {
                            continue;
                        }
                    }

                    hits *= 2;
                    adjectives.Add(tokens[i]);
                }
            }

            SentenceInfo sentenceInfo = new SentenceInfo();
            sentenceInfo.Score = hits;
            sentenceInfo.Comparative = decimal.Divide(hits, tokens.Count);
            sentenceInfo.Words = words.ToArray();
            sentenceInfo.Adjectives = adjectives.ToArray();

            return sentenceInfo;
        }

        /// <summary>
        /// Analyzes the specified phrase.
        /// </summary>
        /// <param name="phrase">The phrase.</param>
        /// <returns></returns>
        public SentimentalInfo Analyze(string phrase)
        {
            string str = Util.ToUnicode(phrase);

            SentenceInfo pos = this.Positivity(str);
            SentenceInfo neg = this.Negativity(str);

            SentimentalInfo result = new SentimentalInfo();                      
            result.Positives = pos;
            result.Negatives = neg;

            result.Score = decimal.Divide((pos.Score - neg.Score), 10);
            result.Comparative = decimal.Divide(pos.Comparative - neg.Comparative, 10);
            result.Comparative = Math.Round(result.Comparative, 2, MidpointRounding.ToEven);
            
            return result;
        }
    }
}
