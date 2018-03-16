using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeazarCode
{
    static class CharUA
    {
        private static List<char> UAAlfavit = new List<char>()
            { 'а', 'б', 'в', 'г','ґ', 'д', 'е', 'є', 'ж', 'з', 'и',
            'і', 'ї', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
            'т', 'у','ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ю', 'я','А',
            'Б','В','Г','Ґ','Д','Е','Є','Ж','З','И','І','Ї','Й','К',
            'Л','М','Н','О','П','Р','С','Т','У','Ф','Х','Ц','Ч','Ш',
            'Щ','Ь','Ю','Я' };

        private static List<char> UALoudLetter = new List<char>()
            { 'о','а','и', 'і', 'у' };

        public static int loudLetterLenght = UALoudLetter.Count;

        public static int alfavitLength = UAAlfavit.Count;

        public static int GetNumber(char inputChar)
        {
            return UAAlfavit.IndexOf(inputChar);
        }

        public static Char GetChar(int inputInt)
        {
            return UAAlfavit[inputInt];
        }

        public static char GetLoudLetter(int inputNumber)
        {
            return UALoudLetter[inputNumber];
        }

        public static int getNumBetweenLetter(char letterFirst, char letterSecond)
        {
            int numFirstLetter = GetNumber(letterFirst);
            int numSecondLetter = GetNumber(letterSecond);
            return numFirstLetter - numSecondLetter;
        }

    }
}
