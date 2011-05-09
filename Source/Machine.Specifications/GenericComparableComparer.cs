using System;

namespace Machine.Specifications
{
    public class GenericComparableComparer<T>  : AssertComparerHandler<T>
    {
        public override int Compare(T x, T y)
        {
            IComparable<T> comparable1 = x as IComparable<T>;

            if (comparable1 != null)
                return comparable1.CompareTo(y);

            return Proccessing(x, y);
        }
    }
}