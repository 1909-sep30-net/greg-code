using System;
using System.Linq;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var movie = "Frozen";

            var moviePlayer = new MoviePlayer { CurrentMovie = movie };


            //
            MoviePlayer.MovieFinishedHandlerWithDetails handler = PrintMovieOver(movie);

            moviePlayer.MovieFinished += handler; //subscribe with +=, unsub with -=
            //


            moviePlayer.PlayMovie();


        }

        //lambda
        static void LambdaExpression()
        {
            Action x = () => Console.WriteLine("Movie Finished");//anonymous method?

            //add 2 numbers
            Func<int, int, int> add = (a, b) => a + b; //add is data - not just a method.

            var five = add(2, 3);

            //LINQ - Language Integrated Query
            var data = new List<string> { "hi","greg","yaaaaaaay"};
            //query linq syntax
            var firstCharactersLongerThanThree = from str in data
                                                 where str.Length > 3
                                                 select str[0];//returns ['h']
            //method Linq syntax, same as above
            data.Where(s => s.Length > 3).Select(s => s[0]);


            //importrant linq extension methods
            /*
             * Where : filters out elements that don't match specification
             * Select transforms each element to something else
             * 
             * LINQ never modifies original collection - always makes new coll
             * 
             * 3 kinds of LINQ methods;
             * 
             */
        }

        static void FuncAndAction()
        {
            Action<string> function = PrintWhichMovieOver;
            function("");

            //a void return functions that thakes an int and a string as params
            Action<int, string> x;

            //a string that takes int and return a string
            Func<int, string> y;
        }

        static void PrintMovieOver()
        {
            Console.WriteLine("Movie finished");
        }

        static void PrintMovieOver(string name)
        {
            Console.WriteLine($"Movie {name} finished");
        }
    }
}
