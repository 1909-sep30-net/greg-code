using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateTest
{
    class OtherClass
    {
        public string gamma;

        public event Action<string> Beta;

        public void Function()
        {
            Beta()?.Invoke(gamma);
        }
    }
}
