using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dissected.Decomposition
{
    public class LcsFinder
    {
        // Modified version of code taken from:
        // https://en.wikibooks.org/wiki/Algorithm_Implementation/Strings/Longest_common_substring
        public string FindLongestCommonSubstring(string a, string b)
        {
            if(String.IsNullOrEmpty(a) || String.IsNullOrEmpty(b))
            {
                return String.Empty;
            }

            int[,] num = new int[a.Length, b.Length];
            int maxlen = 0;
            int lastSubsBegin = 0;
            StringBuilder builder = new StringBuilder();

            for(int i = 0; i < a.Length; i++)
            {
                for(int j = 0; j < b.Length; j++)
                {
                    if(a[i] != b[j])
                    {
                        num[i, j] = 0;
                    }
                    else
                    {
                        if(i == 0 || j == 0)
                        {
                            num[i, j] = 1;
                        }
                        else
                        {
                            num[i, j] = 1 + num[i - 1, j - 1];
                        }

                        if(num[i, j] > maxlen)
                        {
                            maxlen = num[i, j];
                            int thisSubsBegin = i - num[i, j] + 1;
                            if(lastSubsBegin == thisSubsBegin)
                            {
                                // If the current LCS is the same as the last time this block ran
                                builder.Append(a[i]);
                            }
                            else
                            {
                                // This block resets the string builder if a different LCS is found
                                lastSubsBegin = thisSubsBegin;
                                builder.Clear();
                                builder.Append(a.Substring(lastSubsBegin, (i + 1) - lastSubsBegin));
                            }
                        }
                    }
                }
            }

            return builder.ToString();
        }

        public IEnumerable<string> FindAllCommonSubstrings(string a, string b)
        {
            string lcs = FindLongestCommonSubstring(a, b);

            if(String.IsNullOrEmpty(lcs))
            {
                return new List<string>();
            }

            int index = a.IndexOf(lcs, StringComparison.InvariantCulture);
            string a1 = a.Substring(0, index);
            index += lcs.Length;
            string a2 = a.Length < index ? String.Empty : a.Substring(index);

            index = b.IndexOf(lcs, StringComparison.InvariantCulture);
            string b1 = b.Substring(0, index);
            index += lcs.Length;
            string b2 = b.Length < index ? String.Empty : b.Substring(index);

            IEnumerable<string> result = FindAllCommonSubstrings(a1, b1);
            result = result.Concat(new List<string> {lcs});
            return result.Concat(FindAllCommonSubstrings(a2, b2));
        }
    }
}
