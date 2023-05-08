using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Cipher
{
    internal class MECipher : ICipher
    {
        //This cipher is really similar to Caesar's one, but it has N additional chars;
        readonly string chars = "1A $# B45 C7 SH 890- D_+)( OK *& YES ^E$ F CK #@! KJ ~` KK F}[]'><., DK /,! D1 №1 2345678912345678901234567890;% AR :? KJ *";

        private void AddSymbols(ref string text, int value)
        {
            Random random = new Random();

            for (int k = 0; k < value; k++)
            {
                text += chars[random.Next(chars.Length)];
            }
        }

        public string Encrypt(string text, string receivedKey)
        {
            int key = 3;

            if (CheckShift(receivedKey)) { key = int.Parse(receivedKey); }
            else { return "INCORRECT KEY"; }

            if (key < 0) { key = 0; }
            Random random = new Random();

            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    char _ch = char.IsUpper(text[i]) ? 'A' : 'a';
                    result += (char)((text[i] + 5 - _ch) % 26 + _ch);
                }

                else
                {
                    result += text[i];
                }

                for (int k = 0; k < key; k++)
                {
                    result += chars[random.Next(chars.Length)];
                }
            }



            return result;
        }

        public string Decrypt(string text, string receivedKey)
        {
            int key = 3;

            if (CheckShift(receivedKey)) { key = int.Parse(receivedKey); }
            else { return "INCORRECT KEY"; }

            if (key < 0) { key = 0; }
            key++;

            string result = "";

            for (int i = 0; i < text.Length; i += key)
            {
                if (char.IsLetter(text[i]))
                {
                    char _ch = char.IsUpper(text[i]) ? 'A' : 'a';
                    result += (char)((text[i] + 21 - _ch) % 26 + _ch);
                }

                else
                {
                    result += text[i];
                }
            }

            return result;
        }

        private bool CheckShift(string shift)
        {
            try { int.Parse(shift); }
            catch { return false; }
            return true;
        }
    }
}
