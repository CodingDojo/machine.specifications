using System;
using System.Collections;
using System.Collections.Generic;

namespace Machine.Specifications.Comparisons
{
    public class ComparerEnumerable<T> : ComposableComparer<T>
    {
        public ComparerEnumerable(IComparer<T> comparer)
            : base(comparer)
        {
        }

        protected override int? CompareObjects(T x, T y)
        {
            IEnumerable enumerableX = x as IEnumerable;
            IEnumerable enumerableY = y as IEnumerable;

            if (enumerableX != null && enumerableY != null)
            {
                IEnumerator enumeratorX = enumerableX.GetEnumerator();
                IEnumerator enumeratorY = enumerableY.GetEnumerator();

                while (true)
                {
                    bool hasNextX = enumeratorX.MoveNext();
                    bool hasNextY = enumeratorY.MoveNext();

                    if (!hasNextX || !hasNextY)
                    {
                        return (hasNextX == hasNextY ? 0 : -1);
                    }

                    if (!object.Equals(enumeratorX.Current, enumeratorY.Current))
                    {
                        return -1;
                    }
                }
            }

            return null;
        }
    }
}