using System;
using System.Collections;
using System.Collections.Generic;

namespace Machine.Specifications.Comparisons
{
    public abstract class ComposableComparer<T> : IComparer<T>
    {
        readonly IComparer<T> _comparer;

        public ComposableComparer(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public int Compare(T x, T y)
        {
            var result = CompareObjects(x, y);
            if (result.HasValue)
                return result.Value;
            return _comparer != null ? _comparer.Compare(x, y) : 0;
        }

        protected abstract int? CompareObjects(T x, T y);
    }
}