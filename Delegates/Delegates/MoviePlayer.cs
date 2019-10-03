using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Delegates
{
    class MoviePlayer
    {
        //you tell it to play a movie and then an event tells you when it is done
        public string CurrentMovie { get; set; }

        //type for handling the event
        public delegate void MovieFinishedHandler(); //defines a delegate TYPE for return = void, param = none
        //functions with same shape can be SUBCRIBED to this delegate

        //the event member
        public event MovieFinishedHandler MovieFinished;

        //method to play movie
        public void PlayMovie()
        {
            Console.WriteLine($"Playing {CurrentMovie}");

            Thread.Sleep(3000); //wait 3 seconds

            //trigger(fire) the event - calls all subscribing delegates

            //if there are no subscribers, event is "null"ish and this throws an exception
            MovieFinished?.Invoke(); //invoke is != null shorthand
        }

    }
}
