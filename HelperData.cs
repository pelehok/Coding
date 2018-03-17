using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeazarCode
{
    static class HelperData
    {
        private const string message = "*******************************************";
        private const string messageError = "Некоректне введення!!!";
        private const string messageEnterText = "Введiть текст!!!";
        private const string messageHowLine = "Скiльки рядкiв тексту ви хочете ввести?";

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
            Console.WriteLine(message);
            Console.WriteLine(messageHowLine);
            int countLine = 0;
            try
            {
                countLine = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine();
                return new StringBuilder(messageError);
            }

            Console.WriteLine(message);
            Console.WriteLine(messageEnterText);
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
                Console.WriteLine(messageError);
                return new StringBuilder("");
            }
            return result;
        }

        public static void WriteConsole(StringBuilder text)
        {
            Console.WriteLine(message);
            Console.WriteLine(text.ToString());
        }
    }
}
