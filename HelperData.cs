using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeazarCode
{
    static class HelperData
    {
        public static StringBuilder ReadFile(string fileName)
        {
            return new StringBuilder(System.IO.File.ReadAllText(fileName));
        }

        public static void WriteFile(string fileName, StringBuilder text)
        {
            System.IO.File.WriteAllText(fileName, text.ToString());
        }

        public static StringBuilder ReadConsole()
        {
            Console.Write("Скільки рядків тексту ви хочете ввести?");
            int countLine = 0;
            try
            {
                countLine = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Некоректне введення!!!");
                return new StringBuilder("");
            }

            Console.WriteLine("Введіть текст!!!");
            StringBuilder result = new StringBuilder("");
            try
            {
                for (int i = 0; i < countLine; i++)
                {
                    result.Append(Console.ReadLine());
                }
            }
            catch
            {
                Console.WriteLine("Некоректне введення!!!");
                return new StringBuilder("");
            }
            return result;
        }

        public static void WriteConsole(StringBuilder text)
        {
            Console.WriteLine(text.ToString());
        }
    }
}
