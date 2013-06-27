using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sentimentaly
{
    public class SentenceInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SentimentalInfo"/> class.
        /// </summary>
        public SentenceInfo()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SentimentalInfo"/> class.
        /// </summary>
        /// <param name="score">The score.</param>
        public SentenceInfo(int score)
            : this()
        {
            this.Score = score;
        }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        public int Score
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the comparative.
        /// </summary>
        /// <value>
        /// The comparative.
        /// </value>
        public decimal Comparative
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the words.
        /// </summary>
        /// <value>
        /// The words.
        /// </value>
        public string[] Words
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the adjectives.
        /// </summary>
        /// <value>
        /// The adjectives.
        /// </value>
        public string[] Adjectives
        {
            get;
            set;
        }
    }
}
