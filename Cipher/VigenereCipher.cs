using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Cipher
{
    internal class VigenereCipher : ICipher
    {
        //Just a Vigenere cipher, you can find out how it works in Google :)
        public string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        //key generation
        private string GetRepeatKey(string text, int length)
        {
            while (text.Length < length)
            {
                text += text;
            }
            return text.Substring(0, length);
        }

        private string EncryptDecrypt(string text, string key, bool encrypting = true)
        {
            string fullAlphabet = alphabet + alphabet.ToLower();
            string repeatedKey = GetRepeatKey(key, text.Length);
            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                var letterIndex = fullAlphabet.IndexOf(text[i]);
                var codeIndex = fullAlphabet.IndexOf(repeatedKey[i]);

                if (letterIndex < 0)
                {
                    //if the symbol is not found, then add it unchanged
                    result += text[i].ToString();
                }

                else
                {
                    result += fullAlphabet[(fullAlphabet.Length + letterIndex + ((encrypting ? 1 : -1) * codeIndex)) % fullAlphabet.Length].ToString();
                }
            }
            return result;
        }
        
        //text encryption
        public string Encrypt(string plainMessage, string key)
            => EncryptDecrypt(plainMessage, key);

        //text decryption
        public string Decrypt(string encryptedMessage, string key)
            => EncryptDecrypt(encryptedMessage, key, false);
    }
}
