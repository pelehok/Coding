using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeazarCode
{
    enum TypeCoding
    {
        ENCODING,
        DECODING
    };

    class CeazarCode
    {
        private const string _messageError = "Некоректне введення!!!";
        private const string _messageErrorLetter = "Помилка в букві ";
        private const string _messageIsCorrect = "Цей текст можна вважати коректним?";
        private const string _messageYes = "1:Так";
        private const string _messageNo = "2:Ні";
        private const int _userSayYes = 1;
        private const int _userSayNo = 2;
        private const int _repeatAfterNoCorrectAns = 5;
        private const int _notCorrectValue = -1;
        private const int _sizePartText = 10;


        public string EncodingUK(string inputText, int key){
            string outputString = "";
            for (int i = 0; i < inputText.Length; i++)
            {
                if (Char.IsLetter(inputText[i]))
                {
                    int temp = (int) inputText[i] + key;
                    outputString += (char) (temp);
                }
                else
                {
                    outputString += inputText[i];
                }
            }

            return outputString;
        }

        public string DecodingUK(string inputText, int key){
            string outputString = "";
            for (int i = 0; i < inputText.Length; i++)
            {
                if (Char.IsLetter(inputText[i]))
                {
                    int temp = (int) inputText[i] - key;
                    outputString += (char) (temp);
                }
                else
                {
                    outputString += inputText[i];
                }
            }

            return outputString;
        }

        public StringBuilder EncodingUA(StringBuilder inputText, int key){
            return MoveString(inputText, key, TypeCoding.ENCODING);
        }

        public StringBuilder DecodingUA(StringBuilder inputText, int key){
            return MoveString(inputText, key, TypeCoding.DECODING);
        }

        public StringBuilder DecodingWithoutKey(StringBuilder inputString){
            StringBuilder res = null;

            char offerLetter = TextAnalyser.GetOffenLetter(inputString);
            for (int i = 0; i < UA_Alphabet.LoudLetterLenght; i++)
            {
                int numbetween = UA_Alphabet.GetNumBetweenLetter(offerLetter, UA_Alphabet.GetLoudLetter(i));
                StringBuilder partText = GetFirstPart(inputString);
                StringBuilder partTextResult = DecodingUA(partText, numbetween);
                if (CorrectText(partTextResult))
                {
                    return DecodingUA(inputString, numbetween);
                }
            }

            return res;
        }

        private StringBuilder MoveString(StringBuilder inputSrting, int key, TypeCoding typeCoding){
            StringBuilder outputString = new StringBuilder();

            int tempKey = key;
            if (typeCoding == TypeCoding.DECODING)
            {
                tempKey = -key;
            }

            for (int i = 0; i < inputSrting.Length; i++)
            {
                if (Char.IsLetter(inputSrting[i]))
                {
                    int temp = UA_Alphabet.GetNumber(inputSrting[i]);
                    if (Exist(temp))
                    {
                        temp += tempKey;
                        if (IsCorrectNumber(temp))
                        {
                            outputString.Append(UA_Alphabet.GetChar(temp));
                        }
                        else
                        {
                            if (typeCoding == TypeCoding.DECODING)
                            {
                                outputString.Append(UA_Alphabet.GetChar(UA_Alphabet.AlphabetLength + tempKey));
                            }
                            else
                            {
                                outputString.Append(UA_Alphabet.GetChar(UA_Alphabet.AlphabetLength - tempKey));
                            }
                        }
                    }
                    else
                    {
                        outputString = new StringBuilder(_messageErrorLetter + inputSrting[i]);
                        return null;
                    }
                }
            }

            return outputString;
        }

        private bool Exist(int numberLetter){
            if (numberLetter != _notCorrectValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsCorrectNumber(int number){
            if (0 <= number && number < UA_Alphabet.AlphabetLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CorrectText(StringBuilder inputString){
            int i = 0;
            Console.WriteLine(inputString);
            Console.WriteLine(_messageIsCorrect);
            Console.WriteLine(_messageYes);
            Console.WriteLine(_messageNo);
            while (true)
            {
                try
                {
                    int number = Int32.Parse(Console.ReadLine());
                    if (number == _userSayYes)
                    {
                        return true;
                    }
                    else if (number == _userSayNo)
                    {
                        return false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine(_messageError);
                    i++;
                    if (i == _repeatAfterNoCorrectAns)
                    {
                        return false;
                    }
                }
            }
        }

        private static StringBuilder GetFirstPart(StringBuilder inputLetter){
            StringBuilder tempInputString = new StringBuilder(inputLetter.ToString());
            return tempInputString.Remove(_sizePartText, tempInputString.Length - _sizePartText);
        }
    }
}