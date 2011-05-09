namespace Machine.Specifications
{
    public class ObjectAssertComparer<T> : AssertComparerHandler<T>
    {
        public override int Compare(T x, T y)
        {
            return object.Equals(x, y) ? 0 : -1;
        }
    }
}