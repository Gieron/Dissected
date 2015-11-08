using System;
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

        public string[] FindAllCommonSubstrings(string a, string b)
        {
            throw new NotImplementedException();
        }
    }
}
