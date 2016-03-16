using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarsCipher
{
    class CaesarsCipher
    {
        private string alphabet;
        private int offset;

        public CaesarsCipher(string alphabet, int offset)
        {
            this.alphabet = alphabet;
            this.offset = offset;
        }
        
        public string Encode(string inputText)
        {
            var outputText = "";
            char[] charArray = inputText.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                outputText += alphabet[(alphabet.IndexOf(charArray[i]) + offset) % alphabet.Length];
            }

            return outputText;
        }

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
