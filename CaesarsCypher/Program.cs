using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarsCipher
{
    public class CaesarsCipher
    {
        private string alphabet;
        private int offset;

        /// <summary>
        /// Constructor for CaesarsCipher that takes alphabet (string to be turned into char array)
        /// and offset (in int). 
        /// </summary>
        /// <param name="alphabet"></param>
        /// <param name="offset"></param>
        public CaesarsCipher(string alphabet, int offset)
        {
            this.alphabet = alphabet;
            this.offset = offset;
        }
        
        /// <summary>
        /// Encoding transforms the inputText (string) by transforming each character according to the 
        /// offset and alphabet mapping provided in the CaesarsCipher constructor. It returns a transformed
        /// string as an ouput. It assumes a circular alphabet and takes the mod of the alphabet length,
        /// so if the index of a shifted letter is > the length of the alphabet, the index will wrap back 
        /// to the beginning of the alphabet. 
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public string Encode(string inputText)
        {
            var outputText = "";
            char[] charArray = inputText.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                var index = alphabet.IndexOf(charArray[i]);
                if (index < 0)
                {
                    Console.WriteLine("One or more letters in your input string are not in the cipher");
                    Console.ReadLine();
                    break;
                }
                outputText += alphabet[(alphabet.IndexOf(charArray[i]) + offset) % alphabet.Length];
            }

            return outputText;
        }
        
        /// <summary>
        /// Decode reverses the transformation that Encode() does. It uses the same offset that was 
        /// used to transformed the original string in Encode(), which means decoding an encoded 
        /// string should return the original string. 
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public string Decode(string inputText)
        {
            var outputText = "";
            char[] charArray = inputText.ToArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                outputText += alphabet[(alphabet.IndexOf(charArray[i]) - offset) % alphabet.Length];
            }
            return outputText;
        }

        class Program
        {
            static void Main(string[] args)
            {
                var caesar = new CaesarsCipher(" ABCDEFGHIJKLMNOPQRSTUVWXYZ", 3);

                var output = caesar.Encode("HELLO LEO");
                var decodedOutput = caesar.Decode(output);
                Console.WriteLine(output);
                Console.WriteLine(decodedOutput);
                Console.ReadLine();
            }
        }
    }
}
