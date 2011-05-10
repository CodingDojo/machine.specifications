using System;
using System.Collections.Generic;

namespace Machine.Specifications.Comparisons
{
    public class CompareGenericComparable<T> : ComposableComparer<T>
    {
        public CompareGenericComparable(IComparer<T> comparer) : base(comparer)
        {
        }

        protected override int? CompareObjects(T x, T y)
        {
            IComparable<T> comparable1 = x as IComparable<T>;

            if (comparable1 != null)
            {
                return comparable1.CompareTo(y);
            }
            return null;

        }
    }
}