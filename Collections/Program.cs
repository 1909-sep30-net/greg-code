using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Arrays();
            Lists();
        }

        static void Arrays()
        {
            var intArray = new int[4];
            intArray[0] = 3;
            intArray[1] = 5;

            var intArray2 = new int[] { 1,2,3,4,12};

            //jagged array
            int[][] twoD = new int[3][];
            twoD[0] = new int[] {1,2};
            twoD[1] = new int[] {5,4,1,2};

            int[,] twoDMulti = new int[3,5];
            twoDMulti[0,0] = 3;

        }

        static void Lists()
        {
            //dynamic-length collection of type object
            //good : dynamic length
            //bad : type object
            ArrayList list = new ArrayList();
            list.Add(3);
            list.Add(3.1);

            //use casting to turn object into more specific type
            int number = (int) list[0];



            //Nobody uses arrays or arraylist anymore. we use LIST, using generic types
            List<int> intList = new List<int>();
            intList.Add(1);
            int num = intList[0]; //NO TYPECASTING
        }

        static void OtherCollections()
        {
            //sets - OPTIMAL, very fast in search through all members, very fast to insert and remove
            var set = new HashSet<string> {"a","b","c"};
            Console.WriteLine(set.Contains("d")); // prints false

            var dict = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 4
            };
            var squared = dict[2];

            //you can overload operators like ==;

        }
    }
}
