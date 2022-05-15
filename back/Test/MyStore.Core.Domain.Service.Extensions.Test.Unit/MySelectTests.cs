using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyStore.Core.Domain.Service.Extensions.Test.Unit
{
    public class MySelectTests
    {
        Func<StubRecord, int> _selector = s => s.StubProperty;

        private static readonly int _stubPropertyValue = 1;

        private static readonly StubRecord _stub = new StubRecord(_stubPropertyValue);

        private static readonly int _secondStubPropertyValue = _stubPropertyValue + 1;

        private static readonly StubRecord _secondsSub = new StubRecord(_secondStubPropertyValue);

        [Fact]
        public void EmptyEnumerable_ReturnsEmptyEnumerable()
        {
            IEnumerable<StubRecord> emptyEnumerator = new List<StubRecord>();

            IEnumerable<int> actualResult = emptyEnumerator.MySelect(_selector);

            Assert.Empty(actualResult);
        }

        [Fact]
        public void FilledEnumerable_ReturnsSameLengthEnumerable()
        {
            IEnumerable<StubRecord> filledEnumerator = new List<StubRecord> { _stub };

            IEnumerable<int> actualResult = filledEnumerator.MySelect(_selector);

            Assert.Equal(actualResult.Count(), filledEnumerator.Count());
        }

        [Fact]
        public void FilledEnumerable_ReturnsMappedElementsInOrder()
        {
            var filledEnumerator = new List<StubRecord>
            {
                _stub,
                _secondsSub
            };

            IEnumerable<int> actualResult = filledEnumerator.MySelect(_selector);

            Assert.Collection(actualResult, 
                n => n.Equals(_stubPropertyValue), 
                n => n.Equals(_secondStubPropertyValue));
        }

        [Fact]
        public void FilledEnumerable_DoesNotModifyInitialEnumerable()
        {
            var expectedEnumerable = new List<StubRecord> { _stub };
            IEnumerable<StubRecord> actualEnumerator = expectedEnumerable;

            actualEnumerator.MySelect(_selector);

            Assert.True(expectedEnumerable.SequenceEqual(actualEnumerator));
        }
    }
}
