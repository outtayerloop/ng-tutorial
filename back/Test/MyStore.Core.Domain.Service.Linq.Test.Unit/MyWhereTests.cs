using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyStore.Core.Domain.Service.Linq.Test.Unit
{
    public class MyWhereTests
    {
        private static readonly int _threshold = 0;

        private static readonly StubRecord _expectedResult = new StubRecord(_threshold + 1);

        private static readonly StubRecord _outlier = new StubRecord(_threshold - 1);

        private static readonly Func<StubRecord, bool> _predicate = s => s.StubProperty > _threshold;

        [Fact]
        public void EmptyEnumerable_ReturnsEmptyEnumerable()
        {
            IEnumerable<StubRecord> emptyEnumerator = new List<StubRecord>();

            IEnumerable<StubRecord> actualResult = emptyEnumerator.MyWhere(_predicate);

            Assert.Empty(actualResult);
        }

        [Fact]
        public void FilledEnumerable_WithAtLeastOneMatchingElement_ReturnsOnlyMatchingElements()
        {
            IEnumerable<StubRecord> filledEnumerator = new List<StubRecord> 
            { 
                _expectedResult, 
                _outlier 
            };

            IEnumerable <StubRecord> actualResult = filledEnumerator.MyWhere(_predicate);

            Assert.Collection(actualResult, s => s.Equals(_expectedResult));
        }

        [Fact]
        public void FilledEnumerable_WithNoMatchingElement_ReturnsEmptyEnumerable()
        {
            IEnumerable<StubRecord> filledEnumerator = new List<StubRecord> { _outlier };

            IEnumerable<StubRecord> actualResult = filledEnumerator.MyWhere(_predicate);

            Assert.Empty(actualResult);
        }

        [Fact]
        public void FilledEnumerable_WithAtLeastOneMatchingElement_DoesNotModifyInitialEnumerable()
        {
            var expectedEnumerable = new List<StubRecord> 
            { 
                _expectedResult, 
                _outlier 
            };
            IEnumerable<StubRecord> actualEnumerator = expectedEnumerable;

            actualEnumerator.MyWhere(_predicate);

            Assert.True(expectedEnumerable.SequenceEqual(actualEnumerator));
        }

        [Fact]
        public void FilledEnumerable_WithAtLeastOneMatchingElement_ReturnsElementInOrder()
        {
            var secondExpectedResult = new StubRecord(_expectedResult.StubProperty + 1);
            var filledEnumerator = new List<StubRecord>
            {
                _expectedResult,
                _outlier,
                secondExpectedResult
            };

            IEnumerable<StubRecord> actualResult = filledEnumerator.MyWhere(_predicate);

            Assert.Collection(actualResult, 
                s => s.Equals(_expectedResult),
                s => s.Equals(secondExpectedResult));
        }
    }
}