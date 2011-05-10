using System;
using System.Collections;
using System.Collections.Generic;

namespace Machine.Specifications.Comparisons
{
    public class CompareNulls<T> : ComposableComparer<T>
    {
        public CompareNulls(IComparer<T> comparer)
            : base(comparer)
        {
        }

        protected override int? CompareObjects(T x, T y)
        {
            Type type = typeof(T);

            if (!type.IsValueType ||
                (type.IsGenericType && type.GetGenericTypeDefinition().IsAssignableFrom(typeof(Nullable<>))))
            {
                if (object.Equals(x, default(T)))
                {
                    if (object.Equals(y, default(T)))
                    {
                        return 0;
                    }
                    return -1;
                }

                if (object.Equals(y, default(T)))
                {
                    return -1;
                }
            }

            return null;

        }
    }
}