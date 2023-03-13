using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Cipher
{
    public interface ICipher
    {
        string encrypt(string text, int key);
        string decrypt(string text, int key);
    }
}
