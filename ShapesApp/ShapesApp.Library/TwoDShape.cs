namespace ShapesApp.Library
{
    public abstract class TwoDShape : Ishape
    {   
        public int Dimensions => 2;

        public abstract int Sides {get;}

        public abstract double Area{get;}

        public abstract double GetPerimeter();
}
}