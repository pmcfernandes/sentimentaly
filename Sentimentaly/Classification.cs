using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sentimentaly
{
    public enum Part_of_speech
    {
        Adj = 0,
        Noun = 1,
        Verb = 2,
        Idiom = 3
    }

    public enum Forme
    {
        M = 0,
        F = 1
    }

    public enum Genere
    {
        S = 0,
        P = 1
    }


    public class AdjectiveClassification
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the part_of_speech.
        /// </summary>
        /// <value>
        /// The part_of_speech.
        /// </value>
        public Part_of_speech Part_of_speech 
        { 
            get; 
            set;
        }

        /// <summary>
        /// Gets or sets the polarity.
        /// </summary>
        /// <value>
        /// The polarity.
        /// </value>
        public int Polarity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the forme.
        /// </summary>
        /// <value>
        /// The forme.
        /// </value>
        public Forme Forme
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the genere.
        /// </summary>
        /// <value>
        /// The genere.
        /// </value>
        public Genere Genere
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return String.Format("{0};GN={1}{2};POL={3}", this.Text, this.Forme, this.Genere, this.Polarity);
        }

    }
}
