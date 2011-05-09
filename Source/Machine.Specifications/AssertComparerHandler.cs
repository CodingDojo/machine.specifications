using System;

namespace Machine.Specifications
{
    public abstract class AssertComparerHandler<T>
    {
        protected AssertComparerHandler<T> successor;

        public void SetSuccessor(AssertComparerHandler<T> successor)
        {
            this.successor = successor;
        }

        public abstract int Compare(T x, T y);

        protected int Proccessing(T x, T y)
        {
            if (successor != null)
            {
                return successor.Compare(x, y);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}