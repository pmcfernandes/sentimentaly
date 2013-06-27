using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sentimentaly
{
    public class SentimentalInfo
    {
        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        public decimal Score
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
        /// Gets or sets the positives.
        /// </summary>
        /// <value>
        /// The positives.
        /// </value>
        public SentenceInfo Positives
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets the negatives.
        /// </summary>
        /// <value>
        /// The negatives.
        /// </value>
        public SentenceInfo Negatives
        {
            get;
            set;
        }
    }
}
