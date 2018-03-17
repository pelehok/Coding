using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeazarCode
{
    class Menu
    {
        private readonly string[] ITEMS_MENU_CODING = {
            "1.Закодувати текст",
            "2.Розкодувати текст",
            "3.Декодувати текст",
            "4.Вихiд"};
        private readonly string[] ITEMS_MENU_READING_TEXT = {
            "1.Зчитати текст з файлу",
            "2.Зчитати текст з консолi",
            "3.Вихiд в головне меню"};
        private readonly string[] ITEMS_MENU_WRITE_TEXT = {
            "1.Записати отриманий текст у файлу",
            "2.Вивiд отриманий тексту на консолi",
            "3.Вихiд в головне меню"};

        private const string messageWelcom = "Виберiть дiю";
        private const string messageError = "Неправильно введенi данi. Попробуйте ще раз";

        private const string messageFilePath = "Введiть шлях до файлу";
        private const string messageFileError = "Шлях до файлу некоректний або файлу не iснує";
        private const string messageSuccesfullFile = "Дiю виконано";
        private const string messageKey = "Введiть ключ шифрування";
        private const string messageReadFile = " зчитування з файлу";
        private const string messageWriteFile = " зчитування з файлу";
        private const string message = "*******************************************";

        public void Show()
        {
            WelcomMenu();
        }

        private void WelcomMenu()
        {
            while (true)
            {
                Console.WriteLine(message);
                Console.WriteLine(messageWelcom);
                foreach (string item in ITEMS_MENU_CODING)
                {
                    Console.WriteLine(item);
                }
                try
                {
                    int number = Int32.Parse(Console.ReadLine());
                    if (IsCorrect(number, ITEMS_MENU_CODING.Length))
                    {
                        bool isExit = false;
                        switch (number)
                        {
                            case 1:
                                EncodingItem();
                                break;
                            case 2:
                                DecodingItem();
                                break;
                            case 3:
                                DecodingWithoutKeyItem();
                                break;
                            case 4:
                                isExit = true;
                                break;
                        }
                        if (isExit)
                        {
                            break;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine(messageError);
                }
            }
        }

        private void EncodingItem()
        {
            StringBuilder resultMenuFile = ReadDataMenu();
            if (resultMenuFile != null)
            {
                CeazarCode ceazarCode = new CeazarCode();
                int num = GerKeyMenu();
                if (num != 0)
                {
                    StringBuilder result = ceazarCode.EncodingUA(resultMenuFile, num);
                    if (result != null)
                    {
                        WriteDataMenu(result);
                    }
                    else
                    {
                        Console.WriteLine(messageError);
                    }
                }
                else
                {
                    Console.WriteLine(messageError);
                }
            }
        }

        private void DecodingItem()
        {

            StringBuilder resultMenuFile = ReadDataMenu();
            if (resultMenuFile != null)
            {
                CeazarCode ceazarCode = new CeazarCode();

                int num = GerKeyMenu();
                if (num != 0)
                {
                    StringBuilder result = ceazarCode.DecodingUA(resultMenuFile, num);
                    if (result != null)
                    {
                        WriteDataMenu(result);
                    }
                    else
                    {
                        Console.WriteLine(messageError);
                    }
                }
                else
                {
                    Console.WriteLine(messageError);
                }
            }
        }

        private void DecodingWithoutKeyItem()
        {
            StringBuilder resultMenuFile = ReadDataMenu();
            if (resultMenuFile != null)
            {
                CeazarCode ceazarCode = new CeazarCode();
                StringBuilder result = ceazarCode.DecodingWithoutKey(resultMenuFile);
                if (result != null)
                {
                    WriteDataMenu(result);
                }
                else
                {
                    Console.WriteLine(messageError);
                }
            }
        }

        private int GerKeyMenu()
        {
            Console.WriteLine(message);

            Console.WriteLine(messageKey);
            try
            {
                int number = Int32.Parse(Console.ReadLine());
                if (IsCorrect(number, CharUA.alfavitLength))
                {
                    return number;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine(messageError);
                return 0;
            }
        }

        private StringBuilder ReadDataMenu()
        {
            while (true)
            {
                Console.WriteLine(message);
                Console.WriteLine(messageWelcom);
                foreach (string item in ITEMS_MENU_READING_TEXT)
                {
                    Console.WriteLine(item);
                }
                try
                {
                    int number = Int32.Parse(Console.ReadLine());
                    if (IsCorrect(number, ITEMS_MENU_READING_TEXT.Length))
                    {
                        bool isExit = false;
                        switch (number)
                        {
                            case 1:
                                return ReadFileItem();
                            case 2:
                                return HelperData.ReadConsole();
                            case 3:
                                isExit = true;
                                break;
                        }
                        if (isExit)
                        {
                            break;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine(messageError);
                }
            }
            return null;
        }

        private StringBuilder ReadFileItem()
        {
            Console.WriteLine(message);

            Console.WriteLine(messageFilePath);
            try
            {
                string filePath = Console.ReadLine();
                StringBuilder resultText = HelperData.ReadFile(filePath);

                Console.WriteLine(messageSuccesfullFile+messageReadFile);
                return resultText;
            }
            catch
            {
                Console.WriteLine(messageFileError);
                return null;
            }
        }

        private void WriteFileItem(StringBuilder inputString)
        {
            Console.WriteLine(message);

            Console.WriteLine(messageFilePath);
            try
            {
                string filePath = Console.ReadLine();
                HelperData.WriteFile(filePath,inputString);
                Console.WriteLine(messageSuccesfullFile+messageWriteFile);
            }
            catch
            {
                Console.WriteLine(messageFileError);
            }
        }

        private void WriteDataMenu(StringBuilder _inputText)
        {
            while (true)
            {
                Console.WriteLine(message);
                Console.WriteLine(messageWelcom);
                foreach (string item in ITEMS_MENU_WRITE_TEXT)
                {
                    Console.WriteLine(item);
                }
                try
                {
                    int number = Int32.Parse(Console.ReadLine());
                    if (IsCorrect(number, ITEMS_MENU_WRITE_TEXT.Length))
                    {
                        bool isExit = false;
                        switch (number)
                        {
                            case 1:
                                WriteFileItem(_inputText);
                                isExit = true;
                                break;
                            case 2:
                                HelperData.WriteConsole(_inputText);
                                break;
                            case 3:
                                isExit = true;
                                break;
                        }
                        if (isExit)
                        {
                            break;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine(messageError);
                }
            }
        }

        private bool IsCorrect(int number,int maxValue)
        {
            if(number>0 && number <= maxValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
