namespace ShapesApp.Library
{
    public class Rectangle : Ishape
    {
        //Properties
        public double Length {get;set;}
        public double Width {get;set;}


        public double Area
        {
            get
            {
                return Length*Width;
            }
        }

        public int Dimensions
        {
            get {return 2;}
        }
        public int Sides => 4; //Shorthand, same as dimensions above.

        public double GetPerimeter()
        {
            return (Length + Width) * 2;
        }
    }
}