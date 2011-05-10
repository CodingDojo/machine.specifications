using System;
using System.Collections.Generic;

namespace Machine.Specifications.Comparisons
{
    public class CompareSimpleObjects<T> : ComposableComparer<T>
    {
        public CompareSimpleObjects() : base(null)
        {
        }

        public CompareSimpleObjects(IComparer<T> comparer) : base(comparer)
        {
        }

        protected override int? CompareObjects(T x, T y)
        {
            return object.Equals(x, y) ? 0 : -1;
        }
    }
}