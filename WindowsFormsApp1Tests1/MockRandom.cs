using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1Tests1
{
    class MockRandom : Random
    {
        //Next
        public override int Next(int inputValue)
        {
            return inputValue;
        }
    }
}
