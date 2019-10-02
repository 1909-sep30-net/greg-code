using System;
using System.Collections.Generic;
using System.Text;
using Sequences.Library;
using Xunit;

namespace Sequences.Tests
{
    public class StringSequenceTests
    {
        //unit test for String Sequence Add method
        [Theory]//allows for parameter for similar tests 
        [InlineData("abc")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("12345")]
        public void AddShouldAdd(string item)
        {
            //arrange (any setup necessary to prep for the behavior to test)
            //act (do the thing you are testing
            //assert (verify the behavior was expected)

            //arrange
            var seq = new StringSequence();

            //act
            seq.Add(item);

            //assert
            Assert.Equal(expected: item, actual: seq[0]);
        }

        [Fact]//this tells xunit that this is a test method
        public void AddShouldAddInOrder()
        {
            //arrange (any setup necessary to prep for the behavior to test)
            //act (do the thing you are testing
            //assert (verify the behavior was expected)

            //arrange
            var seq = new StringSequence();

            //act
            seq.Add("abc");
            seq.Add("def");

            //assert
            Assert.Equal(expected: "abc", actual: seq[0]);
            Assert.Equal(expected: "def", actual: seq[1]);
        }

         [Fact]
        public void AccessOutOfBoundsShouldThrow()
        {
            //arrange
            var seq = new StringSequence();

            //Action assert

            Assert.ThrowsAny<ArgumentOutOfRangeException>(() =>
            {
                var x = seq[0];
            });
        }

        [Fact]
        public void LongestStringShouldReturnLongest()
        {
            //arrange
            var seq = new StringSequence();
            seq.Add("");
            seq.Add("boogity boogity boogity amen");
            seq.Add("long, but not long enough.");
            seq.Add("short");

            //act
            string longest = seq.LongestString();

            //assert
            Assert.Equal(expected: "boogity boogity boogity amen", actual: longest);
        }
    }
}
