using System;

namespace Machine.Specifications
{
    class NullableTypeComparerHandler<T> : AssertComparerHandler<T>
    {
        public override int Compare(T x, T y)
        {
            Type type = typeof(T);
            if (!type.IsValueType ||
                (type.IsGenericType && type.GetGenericTypeDefinition().IsAssignableFrom(typeof(Nullable<>))))
            {
                if (Equals(x, default(T)))
                {
                    if (Equals(y, default(T)))
                    {
                        return 0;
                    }
                    return -1;
                }

                if (Equals(y, default(T)))
                {
                    return -1;
                }
            }
            return Proccessing(x, y);
        }
    }
}