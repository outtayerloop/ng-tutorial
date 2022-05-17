using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyStore.Core.Domain.Service.Extensions.Test.Unit
{
    public class MySelectTests
    {
        Func<Stub, int> _selector = s => s.StubProperty;

        private static readonly int _stubPropertyValue = 1;

        private static readonly Stub _stub = new Stub(_stubPropertyValue);

        private static readonly int _secondStubPropertyValue = _stubPropertyValue + 1;

        private static readonly Stub _secondsSub = new Stub(_secondStubPropertyValue);

        [Fact]
        public void EmptyEnumerable_ReturnsEmptyEnumerable()
        {
            IEnumerable<Stub> emptyEnumerator = new List<Stub>();

            IEnumerable<int> actualResult = emptyEnumerator.MySelect(_selector);

            Assert.Empty(actualResult);
        }

        [Fact]
        public void FilledEnumerable_ReturnsSameLengthEnumerable()
        {
            IEnumerable<Stub> filledEnumerator = new List<Stub> { _stub };

            IEnumerable<int> actualResult = filledEnumerator.MySelect(_selector);

            Assert.Equal(actualResult.Count(), filledEnumerator.Count());
        }

        [Fact]
        public void FilledEnumerable_ReturnsMappedElementsInOrder()
        {
            var filledEnumerator = new List<Stub>
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
            var expectedEnumerable = new List<Stub> { _stub };
            IEnumerable<Stub> actualEnumerator = expectedEnumerable;

            actualEnumerator.MySelect(_selector);

            Assert.True(expectedEnumerable.SequenceEqual(actualEnumerator));
        }
    }
}
