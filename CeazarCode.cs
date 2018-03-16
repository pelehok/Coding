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

        public StringBuilder EncodingUA(StringBuilder _inputText,int _key)
        {
            return MoveString(_inputText, _key, TypeCoding.ENCODING);
        }

        public StringBuilder DecodingUA(StringBuilder _inputText, int _key)
        {
            return MoveString(_inputText, _key, TypeCoding.DECODING);
        }

        private StringBuilder MoveString(StringBuilder _inputSrting, int _key,TypeCoding typeCoding)
        {
            StringBuilder outputString = new StringBuilder();

            int tempKey = _key;
            if(typeCoding == TypeCoding.DECODING)
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
                                outputString.Append(CharUA.GetChar(CharUA.length + tempKey));
                            }
                            else
                            {
                                outputString.Append(CharUA.GetChar(CharUA.length - tempKey));
                            }
                        }
                    }
                    else
                    {
                        outputString = new StringBuilder("Error with letter "+ _inputSrting[i]);
                        break;
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
            if(0 <= number && number < CharUA.length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public StringBuilder DecodingWithoutKey(StringBuilder _inputString)
        {

        }
    }
}
