using System;
using System.Collections.Generic;

namespace Machine.Specifications.Comparisons
{
    public class CompareNonGenericComparable<T> : ComposableComparer<T>
    {
        public CompareNonGenericComparable(IComparer<T> comparer) : base(comparer)
        {

        }

        protected override int? CompareObjects(T x, T y)
        {
            IComparable comparable2 = x as IComparable;

            if (comparable2 != null)
            {
                return comparable2.CompareTo(y);
            }
            return null;

        }
    }
}