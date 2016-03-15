using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarsCipher
{

    class CaesarsCipher
    {
        private string AlphabetString;
        private Dictionary<char, char> Alphabet;

        public CaesarsCipher (string inputAlphabet)
        {
            this.AlphabetString = inputAlphabet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public void GenerateAlphabets(string inputText, int offset)
        {
            inputText = inputText.ToLower();

            var cipher = new Dictionary<char, char>();
            char[] charArray = inputText.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                char letter = charArray[i];
                int newIndex = i + offset;
                if ( newIndex >= charArray.Length)
                {
                    newIndex = newIndex - charArray.Length;
                }
                if ( newIndex < 0)
                {
                    newIndex = newIndex + charArray.Length;
                }
                char newLetter = charArray[newIndex];
                cipher[letter] = newLetter;
            }
            this.Alphabet = cipher;
            //char[] buffer = inputText.ToCharArray();
            //for (int i = 0; i < buffer.Length; i++)
            //{
            //    char letter = buffer[i];
            //    if (letter > 'z')
            //    {
            //        letter = (char)(letter - 26);
            //    }
            //    if (letter < 'a')
            //    {
            //        letter = (char)(letter + 26);
            //    }

            //    letter = (char)(letter + offset);
            //    buffer[i] = letter;
            //}
            //return buffer;

        }
        
        public string ApplyCipher(string inputText)
        {
            inputText = inputText.ToLower();
            var newString = new char[inputText.Length];
            var charArray = inputText.ToCharArray();
            for (int i = 0; i < inputText.Length; i++)
            {
                var letter = charArray[i];
                var newLetter = this.Alphabet[letter];

                newString[i] = newLetter;
            }
            var newNewString = newString.ToString();

            return newNewString;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var caesar = new CaesarsCipher(" ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            var inputString = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            caesar.GenerateAlphabets(inputString, 3);
            var newString = caesar.ApplyCipher("Hello Leo");
            Console.WriteLine(newString);
            Console.ReadLine();
        }
    }
}
