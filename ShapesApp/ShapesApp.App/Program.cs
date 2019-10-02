using System;
using ShapesApp.Library;

namespace ShapesApp.App
{
    static class Program
    {
        static void Main(string[] args)
        {
            
            double length, width;
            string input;
            
            do
            {
                Console.WriteLine("Enter a length:");
                input = Console.ReadLine();
            }
            while(!double.TryParse(input, out length));

            do
            {
                Console.WriteLine("Enter a width:");
                input = Console.ReadLine();
            }
            while(!double.TryParse(input, out width));

            //var r = new Rectangle();
            //r.Length = length;
            //r.Width = width;

            //PROPERTY INITIALIZER
            var r = new Rectangle
            {
                Length = length,
                Width = width
            };

            r.PrintRect();//looks like a tag method from another class, but is actually a method written below

            var c = new ColorCircle(length,"red");

            c.PrintCirc();
        }

        public static void PrintRect(this Rectangle r)
        {
            Console.WriteLine($"{r.Length} and {r.Width} is l and w");
        }

        public static void PrintCirc(this Circle c)
        {
            Console.WriteLine($"{c.Radius} is radius, perimeter: {c.GetPerimeter()}");
        }
    }
}
