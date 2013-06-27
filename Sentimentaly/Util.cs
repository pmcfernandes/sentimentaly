using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Sentimentaly
{
    internal class Util
    {
        /// <summary>
        /// Convert all string to unicode removing specialchars
        /// </summary>
        /// <param name="str">The STR.</param>
        public static string ToUnicode(string str)
        {
            string stFormD = str.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }

            return (sb.ToString());
        }
    }
}
