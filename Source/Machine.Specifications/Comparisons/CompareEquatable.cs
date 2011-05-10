using System;
using System.Collections.Generic;

namespace Machine.Specifications.Comparisons
{
    public class CompareEquatable<T> : ComposableComparer<T>
    {
        public CompareEquatable(IComparer<T> comparer) : base(comparer)
        {
        }

        protected override int? CompareObjects(T x, T y)
        {
            IEquatable<T> equatable = x as IEquatable<T>;

            if (equatable != null)
            {
                return equatable.Equals(y) ? 0 : -1;
            }
            return null;

        }
    }
}