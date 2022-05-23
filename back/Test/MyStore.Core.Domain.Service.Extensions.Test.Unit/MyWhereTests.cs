using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyStore.Core.Domain.Service.Extensions.Test.Unit
{
    public class MyWhereTests
    {
        private static readonly int _threshold = 0;

        private static readonly Stub _expectedResult = new Stub(_threshold + 1);

        private static readonly Stub _outlier = new Stub(_threshold - 1);

        private static readonly Func<Stub, bool> _predicate = s => s.StubProperty > _threshold;

        [Fact]
        public void EmptyEnumerable_ReturnsEmptyEnumerable()
        {
            IEnumerable<Stub> emptyEnumerator = new List<Stub>();

            IEnumerable<Stub> actualResult = emptyEnumerator.MyWhere(_predicate);

            Assert.Empty(actualResult);
        }

        [Fact]
        public void FilledEnumerable_WithAtLeastOneMatchingElement_ReturnsOnlyMatchingElements()
        {
            IEnumerable<Stub> filledEnumerator = new List<Stub> 
            { 
                _expectedResult, 
                _outlier 
            };

            IEnumerable <Stub> actualResult = filledEnumerator.MyWhere(_predicate);

            Assert.Collection(actualResult, s => s.Equals(_expectedResult));
        }

        [Fact]
        public void FilledEnumerable_WithNoMatchingElement_ReturnsEmptyEnumerable()
        {
            IEnumerable<Stub> filledEnumerator = new List<Stub> { _outlier };

            IEnumerable<Stub> actualResult = filledEnumerator.MyWhere(_predicate);

            Assert.Empty(actualResult);
        }

        [Fact]
        public void FilledEnumerable_WithAtLeastOneMatchingElement_DoesNotModifyInitialEnumerable()
        {
            var expectedEnumerable = new List<Stub> 
            { 
                _expectedResult, 
                _outlier 
            };
            IEnumerable<Stub> actualEnumerator = expectedEnumerable;

            actualEnumerator.MyWhere(_predicate);

            Assert.True(expectedEnumerable.SequenceEqual(actualEnumerator));
        }

        [Fact]
        public void FilledEnumerable_WithAtLeastOneMatchingElement_ReturnsElementInOrder()
        {
            var secondExpectedResult = new Stub(_expectedResult.StubProperty + 1);
            var filledEnumerator = new List<Stub>
            {
                _expectedResult,
                _outlier,
                secondExpectedResult
            };

            IEnumerable<Stub> actualResult = filledEnumerator.MyWhere(_predicate);

            Assert.Collection(actualResult, 
                s => s.Equals(_expectedResult),
                s => s.Equals(secondExpectedResult));
        }
    }
}