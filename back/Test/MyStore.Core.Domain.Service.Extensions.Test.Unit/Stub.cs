using System;

namespace MyStore.Core.Domain.Service.Extensions.Test.Unit
{
    internal sealed class Stub: IComparable<Stub>
    {
        public int StubProperty { get; }

        public Stub(int stubProperty)
            => StubProperty = stubProperty;

        public int CompareTo(Stub? other)
        {
            if (other == null) throw new ArgumentNullException($"The other compared {nameof(Stub)} provided instance was null");
            return StubProperty - other.StubProperty;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Stub stub)
                return false;
            return stub.StubProperty == StubProperty;
        }

        public override int GetHashCode()
            => base.GetHashCode();
    }
}
