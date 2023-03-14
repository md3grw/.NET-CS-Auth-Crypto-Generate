using SilevenText.Cipher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText
{
    internal class main
    {
        static void Main(string[] args)
        {
            VigenereCipher cipher = new VigenereCipher();

            string result = cipher.Encrypt("why tho", "negro");

            Console.WriteLine(result);

            string decryptedResult = cipher.Decrypt(result, "negro");

            Console.WriteLine(decryptedResult);
        }
    }
}
