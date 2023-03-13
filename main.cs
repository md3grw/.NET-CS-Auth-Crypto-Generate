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
            ICipher cipher = new MECipher();

            string result = cipher.encrypt("I wrote my own cipher", 10);
            Console.WriteLine(result);
            
            Console.WriteLine();
            
            string decryptedRes = cipher.decrypt(result, 10);
            Console.WriteLine(decryptedRes);
        }
    }
}
