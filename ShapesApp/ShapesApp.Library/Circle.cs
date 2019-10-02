namespace ShapesApp.Library
{
    
    public class Circle : Ishape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }


        public static double pi = 3.14159;
        public int Dimensions => 2;

        public int Sides => 0;

        public double Area => pi * Radius * Radius;

        public double Radius {get;set;}

        public virtual double GetPerimeter() => 2 * pi * Radius; //overridden in Colorcircle with write line
    }
}