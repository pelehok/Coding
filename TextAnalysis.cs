using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeazarCode
{
    
    static class TextAnalysis
    {
        private struct LetterWithFrequensy
        {
            public char letter { get; set; }
            public int count { get; set; }
            public LetterWithFrequensy(char _letter, int _count)
            {
                letter = _letter;
                count = _count;
            }
        };

        public static char GetOffenLetter(StringBuilder text)
        {
            string textToString = text.ToString();

            List<char> textList = textToString.ToList();

            List<LetterWithFrequensy> letterFrequency = GetLetterFrequency(textList);
            letterFrequency.Sort((p, g) => p.count.CompareTo(g.count));

            return letterFrequency.Last().letter;
        }

        private static int GetCountRepeat(char letter, List<char> text)
        {
            int count = 0;
            for(int i = 0; i < text.Count; i++)
            {
                if (text[i].Equals(letter))
                {
                    count++;
                    text.RemoveAt(i);
                }
            }
            return count;
        }

        private static List<LetterWithFrequensy> GetLetterFrequency(List<char> _text)
        {
            List<char> currenttext = new List<char>(_text);

            List<LetterWithFrequensy> resFreq = new List<LetterWithFrequensy>();
            for (int i=0; i < currenttext.Count; i++)
            {
                resFreq.Add(new LetterWithFrequensy(currenttext[i], GetCountRepeat(currenttext[i], currenttext)));
            }

            return resFreq;
        }
    }
}
