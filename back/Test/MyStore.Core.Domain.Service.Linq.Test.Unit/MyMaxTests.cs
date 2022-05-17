using System;
using System.Collections.Generic;
using Xunit;

namespace MyStore.Core.Domain.Service.Linq.Test.Unit
{
    public class MyMaxTests
    {
        [Fact]
        public void EmptyEnumerable_ThrowsInvalidOperationException()
        {
            IEnumerable<int> emptyEnumerator = new List<int>();
            Action myMaxCall = () => emptyEnumerator.MyMax();

            Assert.Throws<InvalidOperationException>(myMaxCall);
        }

        [Fact]
        public void FilledEnumerable_WithSortedPositiveElements_ReturnsMax()
        {
            int expectedResult = 5;
            IEnumerable<int> filledEnumerator = new List<int> { 0, 1, 2, 3, 4, 5 };

            int actualResult = filledEnumerator.MyMax();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FilledEnumerable_WithSortedNegativeElements_ReturnsMax()
        {
            int expectedResult = -1;
            IEnumerable<int> filledEnumerator = new List<int> { -5, -4, -3, -2, -1 };

            int actualResult = filledEnumerator.MyMax();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FilledEnumerable_WithMixedPositiveElements_ReturnsMax()
        {
            int expectedResult = 5;
            IEnumerable<int> filledEnumerator = new List<int> { 1, 0, 4, 3, 5, 2 };

            int actualResult = filledEnumerator.MyMax();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FilledEnumerable_WithMixedNegativeElements_ReturnsMax()
        {
            int expectedResult = -1;
            IEnumerable<int> filledEnumerator = new List<int> { -2, -4, -3, -1, -5 };

            int actualResult = filledEnumerator.MyMax();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FilledEnumerable_WithMixedPositiveAndNegativeElements_ReturnsMax()
        {
            int expectedResult = 5;
            IEnumerable<int> filledEnumerator = new List<int> { -2, 1, -1, 0, 3, 2, 4, -5, -3, 5, -4 };

            int actualResult = filledEnumerator.MyMax();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FilledEnumerable_WithDuplicateElements_ReturnsMax()
        {
            int expectedResult = 5;
            IEnumerable<int> filledEnumerator = new List<int> { -1, -2, -2, 0, 0, 1, 4, 4, 5, -3 };

            int actualResult = filledEnumerator.MyMax();

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
