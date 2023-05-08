using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Cipher
{
    internal class CaesarCipher : ICipher
    {
        //this cipher is very weak
        //shift - variable that represents the number of positions by which each letter in the
        //plain text message is shifted to generate the cipher text message.

        public string Encrypt(string text, string receivedShift)
        {
            int shift = 3;
            
            if (CheckShift(receivedShift)) { shift = int.Parse(receivedShift); }
            else { return "INCORRECT KEY"; }

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

        public string Decrypt(string text, string receivedShift)
        {
            int shift = 3;

            if (CheckShift(receivedShift)) { shift = int.Parse(receivedShift); }
            else { return "INCORRECT KEY"; }

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

        private bool CheckShift(string shift)
        {
            try { int.Parse(shift); }
            catch { return false; }
            return true;
        }
    }
}
