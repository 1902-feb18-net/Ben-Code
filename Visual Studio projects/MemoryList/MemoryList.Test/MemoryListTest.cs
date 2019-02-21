using System;
using Xunit;
using ML.Library;

namespace ML.Test
{
    public class MemoryListTest
    {
        //second type of xUnit test: Tyeory
        //Facts don't allow any parameters
        //Theories accept sets of parameters, to run the test against all of them
        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(1000)]
        public void AddedItemsShouldBeContained(int value)
        {
            var list = new MemoryList<int>();

            list.Add(value);

            Assert.True(list.Contains(value));
        }

        [Theory]
        [InlineData(5)] //should return true
        [InlineData(80)] //should return true
        [InlineData(-5)] //should return false
        public void ContainsShouldBeTrueForContained(int value)
        {
            //1. arrange
            var memoryList = new MemoryList<int>();

            if (value > 0)
                memoryList.Add(value);

            //2. act
            var result = memoryList.Contains(value);

            //3. assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(5)] 
        [InlineData(1000)] 
        [InlineData(80)] 
        public void RemoveShouldTakeOutVariableIfAvailable(int value)
        {
            var memoryList = new MemoryList<int>();
            memoryList.Add(5);
            memoryList.Add(1000);
            memoryList.Add(80);

            memoryList.Remove(value);
            Assert.False(memoryList.Contains(value));

        }

        [Theory]
        [InlineData(5)] //should return true
        [InlineData(80)] //should return false
        [InlineData(-5)] //should return true
        public void ShouldReturnTrueIfValueWasEverIncluded(int value)
        {
            var memoryList = new MemoryList<int>();
            memoryList.Add(5);
            memoryList.Add(-5);
            memoryList.Remove(-5);

            var result = memoryList.HasEverContained(value);
            Assert.True(result);
        }

    }
}
