using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekstraAlgorythm
{
    class DekstraException : ApplicationException
    {
        public DekstraException (string message) : base(message) { }
    }
}
