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
        public static int length = 66;
        public static int GetNumber(char inputChar)
        {
            return UAAlfavit.IndexOf(inputChar);
        }
        public static Char GetChar(int inputInt)
        {
            return UAAlfavit[inputInt];
        }
    }
}
