using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Cipher
{
    internal class CaesarCipher
    {
        //this cipher is very weak
        //shift - variable that represents the number of positions by which each letter in the
        //plain text message is shifted to generate the cipher text message.

        public string encrypt(string text, int shift)
        {
            char[] result = text.ToCharArray();

            for (int i = 0; i < result.Length; i++)
            {
                char ch = result[i];

                if (char.IsLetter(ch))
                {
                    char _ch = char.IsUpper(ch) ? 'A' : 'a';
                    result[i] = (char)((ch + shift - _ch) % 26 + _ch);
                }
            }

            return new string(result);
        }

        public string decrypt(string text, int shift)
        {
            shift = 26 - shift;
            char[] result = text.ToCharArray();

            for (int i = 0; i < result.Length; i++)
            {
                char ch = result[i];

                if (char.IsLetter(ch))
                {
                    char _ch = char.IsUpper(ch) ? 'A' : 'a';
                    result[i] = (char)((ch + shift - _ch) % 26 + _ch);
                }
            }

            return new string(result);
        }
    }
}
