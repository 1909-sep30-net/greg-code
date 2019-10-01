using System;

namespace csharpConsoleApp
{
    class CookFood
    {
        public static void donuts()
        {
            Console.WriteLine("Cook donuts.");
        }

        public static void bacon()
        {
            Console.WriteLine("Cook bacons.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Declaration of variables
            bool isOld = false;
            String name = "Greg";
            int age = 23;

            //Changing value of variables
            isOld = true;
            name = "Old Greg";
            age = age + 60;
            //age = 83

            //Output variables to console
            Console.WriteLine($"{name} is {age} years old. Is he old? {isOld}.");

            for (int i = 1; i <= 10; i++)
            {
                Console.Write(i);
            }
            Console.WriteLine();

            int j = 11;
            while (j < 20)
            {
                Console.Write($"{j} ");
                j++;
            }
            Console.WriteLine();

            int k = 20;
            switch (k)
            {
                case 19:
                    Console.WriteLine("k = 19");
                    break;
                case 20:
                    Console.WriteLine("k = 20");
                    break;
                default:
                    Console.WriteLine("k != 19 or 20");
                    break;

            }

            if (k == 19)
            {
                k = k + 2;
            }
            else if (k == 20)
            {
                k++;
            }
            else
            {
                k = 21;
            }
            Console.WriteLine(k);

            /*
            So far, we have printed
            1 through 21.
              How cool!
             */

             CookFood.donuts();
             var mood = "Happy"; //because we cooked donuts. Var contains a string.

        }
    }
}
