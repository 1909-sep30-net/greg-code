﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sequences.Library
{
    public class StringSequence
    {
        private readonly List<string> _list = new List<string>();

        //delegation - this class implements Add by delegating the work to the basic List class
        public void Add(string item)
        {
            _list.Add(item);
        }

        public void Remove(string item)
        {
            _list.Remove(item);
        }
        /*    
        public string Get(int index)
        {
            return _list[index];
        }
        */

            //replaces public string Get
        public string this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }

        public string LongestString()
        {
            int lengthOfLongest = 0;
            foreach(string s in _list)
            {
                if (s.Length > lengthOfLongest)
                {
                    lengthOfLongest = s.Length;
                }
            }
            foreach(string s in _list)
            {
                if(s.Length == lengthOfLongest)
                {
                    return s;
                }
            }
            return "FAIL";
        }

        public string StartsWithChar(char character)
        {
            string words = "";

            foreach(string s in _list)
            {
                if(s.StartsWith(character.ToString()))
                {
                    words = words + s + " ";
                }
            }

            return words;
        }

        public string appendString(string str)
        {
            string newString = "";
            foreach(string s in _list)
            {
                newString = newString + s + str + " ";
            }
            return newString;
        }
    }
}
