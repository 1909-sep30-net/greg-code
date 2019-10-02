using System;

namespace ShapesApp.Library
{
    public class ColorCircle : Circle
    {
        //every child class constructor calls parent class constructor first : base(radius) saves us from copying and pasting the radius code from parent circle class
        public ColorCircle(double radius, string color) : base(radius)
        {
            Color = color;
        }

        public string Color{get;set;}

        public override double GetPerimeter()//virtual in Circle, adds 'color' to writeline
        {
            Console.WriteLine("calculating perimeter for a color circle");
            return base.GetPerimeter();//reuses the original code from circle
        }


    }
}