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
        private const string messageErrorLetter = "Помилка в букві ";
        private const string messageIsCorrect = "Цей текст можна вважати коректним?";
        private const string messageYes = "1:Yes";
        private const string messageNo = "2:No";
        private const int userSayYes = 1;
        private const int userSayNo = 2;
        private const int repeatAfterNoCorrectAns = 5;
        private const int notCorrectValue = -1;
        private const int sizePartText = 10;


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
            for (int i = 0; i < CharUA.loudLetterLenght; i++)
            {
                int numbetween = CharUA.getNumBetweenLetter(offerLetter, CharUA.GetLoudLetter(i));
                StringBuilder partText = GetFirstPart(_inputString);
                StringBuilder partTextResult = DecodingUA(partText, numbetween);
                if (CorrectText(partTextResult))
                {
                    return DecodingUA(_inputString, numbetween);
                }
            }

            return res;
        }

        private StringBuilder MoveString(StringBuilder _inputSrting, int _key, TypeCoding _typeCoding)
        {
            StringBuilder outputString = new StringBuilder();

            int tempKey = _key;
            if (_typeCoding == TypeCoding.DECODING)
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
                            if (_typeCoding == TypeCoding.DECODING)
                            {
                                outputString.Append(CharUA.GetChar(CharUA.ABCLength + tempKey));
                            }
                            else
                            {
                                outputString.Append(CharUA.GetChar(CharUA.ABCLength - tempKey));
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

        private bool IsExist(int _numberLetter)
        {
            if (_numberLetter != notCorrectValue)
            {
                return true;
            } else
            {
                return false;
            }
        }

        private bool IsCorrectNumber(int _number)
        {
            if (0 <= _number && _number < CharUA.ABCLength)
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
                    if (number == userSayYes)
                    {
                        return true;
                    }else if(number == userSayNo)
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
                    if (i == repeatAfterNoCorrectAns)
                    {
                        return false;
                    }
                }
            }
        }

        private static StringBuilder GetFirstPart(StringBuilder _inputLetter)
        {
            StringBuilder tempInputString = new StringBuilder(_inputLetter.ToString());
            return tempInputString.Remove(sizePartText, tempInputString.Length- sizePartText);
        } 
    }
}
