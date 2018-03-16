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
        public int Key { get; set; }

        public CeazarCode(int _key)
        {
            Key = _key;
        }

        public string EncodingUK(string inputText)
        {
            string outputString = "";
            for (int i = 0; i < inputText.Length; i++)
            {
                if (Char.IsLetter(inputText[i]))
                {
                    int temp = (int)inputText[i] + Key;
                    outputString += (char)(temp);
                }
                else
                {
                    outputString += inputText[i];
                }
            }
            return outputString;
        }

        public string DecodingUK(string inputText)
        {
            string outputString = "";
            for (int i = 0; i < inputText.Length; i++)
            {
                if (Char.IsLetter(inputText[i]))
                {
                    int temp = (int)inputText[i] - Key;
                    outputString += (char)(temp);
                }
                else
                {
                    outputString += inputText[i];
                }
            }
            return outputString;
        }

        public StringBuilder EncodingUA(StringBuilder inputText)
        {
            StringBuilder outputString = new StringBuilder();
            for (int i = 0; i < inputText.Length; i++)
            {
                if (Char.IsLetter(inputText[i]))
                {
                    int temp = CharUA.GetNumber(inputText[i]);
                    if (temp != -1)
                    {
                        temp += Key;
                        if (temp < CharUA.length)
                        {
                            outputString.Append(CharUA.GetChar(temp));
                        }
                        else
                        {
                            outputString.Append(CharUA.GetChar(CharUA.length - temp));
                        }
                    }
                    else
                    {
                        outputString = new StringBuilder("Error");
                        break;
                    }
                }
            }
            return outputString;
        }

        public StringBuilder DecodingUA(StringBuilder inputText)
        {
            StringBuilder outputString = new StringBuilder();
            for (int i = 0; i < inputText.Length; i++)
            {
                if (Char.IsLetter(inputText[i]))
                {
                    int temp = CharUA.GetNumber(inputText[i]);
                    if (temp != -1)
                    {

                        temp -= Key;
                        if (temp >= 0)
                        {
                            outputString.Append(CharUA.GetChar(temp));
                        }
                        else
                        {
                            outputString.Append(CharUA.GetChar(CharUA.length + temp));
                        }
                    }
                    else
                    {
                        outputString.Append(inputText[i]);
                    }
                }
            }
            return outputString;
        }
        private StringBuilder MoveString(StringBuilder _inputSting, int _key,TypeCoding typeCoding)
        {
            StringBuilder outputString = new StringBuilder();

            int tempKey = _key;
            if(typeCoding == TypeCoding.DECODING)
            {
                tempKey = -tempKey;
            }

            for (int i = 0; i < _inputSting.Length; i++)
            {
                if (Char.IsLetter(_inputSting[i]))
                {
                    int temp = CharUA.GetNumber(_inputSting[i]);
                    if (IsExist(temp))
                    {
                        temp += tempKey;
                        if (IsCorrectNumber(temp))
                        {
                            outputString.Append(CharUA.GetChar(temp));
                        }
                        else
                        {
                            outputString.Append(CharUA.GetChar(CharUA.length - tempKey));
                        }
                    }
                    else
                    {
                        outputString.Append(_inputSting[i]);
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
            }else
            {
                return false;
            }
        }
        private bool IsCorrectNumber(int number)
        {
            if(0 <= number && number > CharUA.length)
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
