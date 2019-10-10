using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateTest
{
    class OtherClass
    {
        public delegate void Alpha();

        public event Alpha Beta;

        public void Function()
        {
            Beta();
        }
    }
}
