using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Class1
    {
        public delegate void delegTest(string str);
        public event delegTest OnTest;
        public void TestEvent(string str)
        {
            OnTest(str);
        }
    }
   
}
