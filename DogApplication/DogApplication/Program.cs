using System;

namespace DogApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var dog = new DogClass("Spot", 2);
                //dog.name = "Spot";
                //dog.age = 4;
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            catch(ArgumentException ex) //Could have used ArgumentNullException, which is in DogClass, but ArgumentException is more general
            {
                Console.WriteLine("error, recovering some argument error");
            }
        }
    }
}
