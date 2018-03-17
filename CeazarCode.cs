using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeazarCode
{
    enum TypeCoding
    {
        ENCODING, DECODING
    };
    class CeazarCode
    {
        private const string messageError = "Некоректне введення!!!";
        private const string messageErrorLetter = "Error with letter ";
        private const string messageIsCorrect = "Цей текст можна вважати коректним?";
        private const string messageYes = "1:Yes";
        private const string messageNo = "2:No";
        public string EncodingUK(string _inputText, int _key)
        {
            string outputString = "";
            for (int i = 0; i < _inputText.Length; i++)
            {
                if (Char.IsLetter(_inputText[i]))
                {
                    int temp = (int)_inputText[i] + _key;
                    outputString += (char)(temp);
                }
                else
                {
                    outputString += _inputText[i];
                }
            }
            return outputString;
        }

        public string DecodingUK(string _inputText, int _key)
        {
            string outputString = "";
            for (int i = 0; i < _inputText.Length; i++)
            {
                if (Char.IsLetter(_inputText[i]))
                {
                    int temp = (int)_inputText[i] - _key;
                    outputString += (char)(temp);
                }
                else
                {
                    outputString += _inputText[i];
                }
            }
            return outputString;
        }

        public StringBuilder EncodingUA(StringBuilder _inputText, int _key)
        {
            return MoveString(_inputText, _key, TypeCoding.ENCODING);
        }

        public StringBuilder DecodingUA(StringBuilder _inputText, int _key)
        {
            return MoveString(_inputText, _key, TypeCoding.DECODING);
        }

        public StringBuilder DecodingWithoutKey(StringBuilder _inputString)
        {
            StringBuilder res = null;

            char offerLetter = TextAnalysis.GetOffenLetter(_inputString);
            for (int i = 0; i < 5; i++)
            {
                int numbetween = CharUA.getNumBetweenLetter(offerLetter, CharUA.GetLoudLetter(i));
                StringBuilder tempResult = DecodingUA(_inputString, numbetween);
                StringBuilder partText = GetFirstTenLetter(tempResult);
                if (CorrectText(partText))
                {
                    return tempResult;
                }
            }

            return res;
        }

        private StringBuilder MoveString(StringBuilder _inputSrting, int _key, TypeCoding typeCoding)
        {
            StringBuilder outputString = new StringBuilder();

            int tempKey = _key;
            if (typeCoding == TypeCoding.DECODING)
            {
                tempKey = -_key;
            }

            for (int i = 0; i < _inputSrting.Length; i++)
            {
                if (Char.IsLetter(_inputSrting[i]))
                {
                    int temp = CharUA.GetNumber(_inputSrting[i]);
                    if (IsExist(temp))
                    {
                        temp += tempKey;
                        if (IsCorrectNumber(temp))
                        {
                            outputString.Append(CharUA.GetChar(temp));
                        }
                        else
                        {
                            if (typeCoding == TypeCoding.DECODING)
                            {
                                outputString.Append(CharUA.GetChar(CharUA.alfavitLength + tempKey));
                            }
                            else
                            {
                                outputString.Append(CharUA.GetChar(CharUA.alfavitLength - tempKey));
                            }
                        }
                    }
                    else
                    {
                        outputString = new StringBuilder(messageErrorLetter + _inputSrting[i]);
                        return null;
                    }
                }
            }
            return outputString;
        }

        private bool IsExist(int numberLetter)
        {
            if (numberLetter != -1)
            {
                return true;
            } else
            {
                return false;
            }
        }

        private bool IsCorrectNumber(int number)
        {
            if (0 <= number && number < CharUA.alfavitLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CorrectText(StringBuilder _inputString)
        {
            int i = 0;
            Console.WriteLine(_inputString);
            Console.WriteLine(messageIsCorrect);
            Console.WriteLine(messageYes);
            Console.WriteLine(messageNo);
            while (true)
            {
                try
                {
                    int number = Int32.Parse(Console.ReadLine());
                    if (number == 1)
                    {
                        return true;
                    }else if(number == 2)
                    {
                        return false;
                    }
                    else
                    {
                        new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine(messageError);
                    i++;
                    if (i == 5)
                    {
                        return false;
                    }
                }
            }
        }

        private static StringBuilder GetFirstTenLetter(StringBuilder _inputLetter)
        {
            StringBuilder tempInputString = new StringBuilder(_inputLetter.ToString());
            return tempInputString.Remove(10, tempInputString.Length-10);
        } 
    }
}
