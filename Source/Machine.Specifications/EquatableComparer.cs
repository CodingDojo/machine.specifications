using System;

namespace Machine.Specifications
{
    public class EquatableComparer<T> : AssertComparerHandler<T>
    {
        public override int Compare(T x, T y)
        {

            var equatable = x as IEquatable<T>;

            if (equatable != null)
                return equatable.Equals(y) ? 0 : -1;

            return Proccessing(x, y);
        }
    }
}