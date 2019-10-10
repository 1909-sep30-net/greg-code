using System;

namespace DelegateTestWithAction
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new OtherClass();

            OtherClass.Alpha bus = Hello;

            obj.Beta += bus;

            bus = Goodbye;

            obj.Beta += bus;

            obj.Function();
        }

        static public void Hello()
        {
            Console.WriteLine("yay");
        }

        static public void Goodbye()
        {
            Console.WriteLine("boo");
        }
    }
}
