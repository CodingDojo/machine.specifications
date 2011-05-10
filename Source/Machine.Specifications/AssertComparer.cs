using System;
using System.Collections;
using System.Collections.Generic;

using Machine.Specifications.Comparisons;

namespace Machine.Specifications
{
    // Borrowed from XUnit, licened under MS-PL
    class AssertComparer<T> : IComparer<T>, IEqualityComparer<T>
    {
        IComparer<T> _comparer;
        
        public AssertComparer()
        {
            _comparer = new CompareSimpleObjects<T>();
            _comparer = new CompareEquatable<T>(_comparer);
            _comparer = new CompareNonGenericComparable<T>(_comparer);
            _comparer = new CompareGenericComparable<T>(_comparer);
            _comparer = new CompareTypes<T>(_comparer);
            _comparer = new CompareNulls<T>(_comparer);
            _comparer = new ComparerEnumerable<T>(_comparer);
        }

        public int Compare(T x,
                           T y)
        {
            return _comparer.Compare(x, y);
        }

        public bool Equals(T x, T y)
        {
            return Compare(x, y) == 0;
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }
}