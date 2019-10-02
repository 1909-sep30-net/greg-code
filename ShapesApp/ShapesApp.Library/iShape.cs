namespace ShapesApp.Library
{
    //interface is a contract for classes to declare themselves as following.
    public interface Ishape //public because in Library namespace and interfaces default to internal
    {
        int Dimensions {get;}

        int Sides {get;}

        double GetPerimeter();


    }
}