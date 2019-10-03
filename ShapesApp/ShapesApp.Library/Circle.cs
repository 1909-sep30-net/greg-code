namespace ShapesApp.Library
{
    
    public class Circle : TwoDShape, Ishape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }


        public static double pi = 3.14159;
        //public int Dimensions => 2;     insert by TwoDShape

        public override int Sides => 0;
        

        public override double Area => pi * Radius * Radius;

        public double Radius {get;set;}

        public override double GetPerimeter() => 2 * pi * Radius; //overridden in Colorcircle with write line
    }
}