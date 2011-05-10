using System;
using System.Collections;
using System.Collections.Generic;

namespace Machine.Specifications.Comparisons
{
    public class CompareTypes<T> : ComposableComparer<T>
    {
        public CompareTypes(IComparer<T> comparer)
            : base(comparer)
        {
        }

        protected override int? CompareObjects(T x, T y)
        {
            if (x.GetType() != y.GetType())
            {
                return -1;
            }

            return null;
        }
    }
}