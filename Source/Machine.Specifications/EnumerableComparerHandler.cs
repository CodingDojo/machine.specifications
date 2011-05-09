using System.Collections;

namespace Machine.Specifications
{
    public class EnumerableComparerHandler<T> : AssertComparerHandler<T>
    {
        public override int Compare(T x, T y)
        {
            var enumerableX = x as IEnumerable;
            var enumerableY = y as IEnumerable;

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

                    if (!Equals(enumeratorX.Current, enumeratorY.Current))
                    {
                        return -1;
                    }
                }
            }
            return Proccessing(x, y);
        }
    }
}