using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Menu
{
    internal class EscapeException : Exception
    {
        public EscapeException() { }
        public EscapeException(string message) : base(message) { }
    }
}
