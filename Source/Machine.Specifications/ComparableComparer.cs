using System;

namespace Machine.Specifications
{
    public class ComparableComparer<T> : AssertComparerHandler<T>
    {
        public override int Compare(T x, T y)
        {
            var comparable2 = x as IComparable;

            if (comparable2 != null)
                return comparable2.CompareTo(y);

            return Proccessing(x, y);
        }
    }
}