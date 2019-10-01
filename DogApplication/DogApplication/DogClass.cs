using System;
using System.Collections.Generic;
using System.Text;

namespace DogApplication
{
    internal class DogClass
    {
        //access modifiers
        /*
         * public - everyone can see
         * internal - assembly can see
         * protected - subclass of class can see (even if subclass is in a different project)
         * private - class specific
         * protected internal
         * private protected
         * 
         * private is default, but always specify anyway
         */

        /*
         * Class modifiers:
         * public
         * internal
         */

        //fields
        private string name;
        private int age;

        //constructor
        public DogClass(String name, int age)
        {
            if(name == null)
            {
                throw new ArgumentNullException("name");
            }
            this.name = name;
            Age = age;
        }

        //properties
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                age = value;
            }
        }
    }
}
