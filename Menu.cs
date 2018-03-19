﻿using System;
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
            "0.Вихiд"};
        private readonly string[] ITEMS_MENU_READING_TEXT = {
            "1.Зчитати текст з файлу",
            "2.Зчитати текст з консолi",
            "0.Вихiд в головне меню"};
        private readonly string[] ITEMS_MENU_WRITE_TEXT = {
            "1.Записати отриманий текст у файлу",
            "2.Вивiд отриманий тексту на консолi",
            "0.Вихiд в головне меню"};

        private const int USER_SAY_ENCODE_TEXT = 1;
        private const int USER_SAY_DECODE_TEXT = 2;
        private const int USER_SAY_DECODEWITHOUTKEY_TEXT = 3;
        private const int USER_SAY_EXIT_OR_BACK = 0;

        private const int USER_SAY_READ_FILE = 1;
        private const int USER_SAY_READ_CONSOLE = 2;

        private const int USER_SAY_WRITE_FILE = 1;
        private const int USER_SAY_WRITE_CONSOLE = 2;

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
                            case USER_SAY_ENCODE_TEXT:
                                EncodingItem();
                                break;
                            case USER_SAY_DECODE_TEXT:
                                DecodingItem();
                                break;
                            case USER_SAY_DECODEWITHOUTKEY_TEXT:
                                DecodingWithoutKeyItem();
                                break;
                            case USER_SAY_EXIT_OR_BACK:
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
            CodingItem(TypeCoding.ENCODING);
        }

        private void DecodingItem()
        {
            CodingItem(TypeCoding.DECODING);
        }

        private void CodingItem(TypeCoding typeCoding)
        {
            StringBuilder resultMenuFile = ReadDataMenu();
            if (resultMenuFile != null)
            {
                CeazarCode ceazarCode = new CeazarCode();
                int? num = GerKeyMenu();
                if (num != null)
                {
                    StringBuilder result = null;
                    if (typeCoding == TypeCoding.ENCODING)
                    {
                        result = ceazarCode.EncodingUA(resultMenuFile, (int)num);
                    }
                    else
                    {
                        result = ceazarCode.DecodingUA(resultMenuFile, (int)num);
                    }
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

        private int? GerKeyMenu()
        {
            Console.WriteLine(message);

            Console.WriteLine(messageKey);
            try
            {
                int number = Int32.Parse(Console.ReadLine());
                if (IsCorrect(number, CharUA.ABCLength))
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
                return null;
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
                            case USER_SAY_READ_FILE:
                                return ReadFileItem();
                            case USER_SAY_READ_CONSOLE:
                                return HelperData.ReadConsole();
                            case USER_SAY_EXIT_OR_BACK:
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
                            case USER_SAY_WRITE_FILE:
                                WriteFileItem(_inputText);
                                isExit = true;
                                break;
                            case USER_SAY_WRITE_CONSOLE:
                                HelperData.WriteConsole(_inputText);
                                break;
                            case USER_SAY_EXIT_OR_BACK:
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
            if(number>=0 && number <= maxValue)
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
