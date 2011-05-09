namespace Machine.Specifications
{
    public class TypeComparer<T> : AssertComparerHandler<T>
    {
        public override int Compare(T x, T y)
        {
            if (x.GetType() != y.GetType())
                return -1;

            return Proccessing(x, y);
        }
    }
}
