using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.Specifications
{
    // Borrowed from XUnit, licened under MS-PL
  class AssertComparer<T> : IComparer<T>, IEqualityComparer<T>
  {
    public int Compare(T x,
                       T y)
    {
        var enumerableComparer = new EnumerableComparerHandler<T>();
        var nullableComparer = new NullableTypeComparerHandler<T>();
        var typeComparer = new TypeComparer<T>();
        var genericComparableComparer = new GenericComparableComparer<T>();
        var comparableComparererer = new ComparableComparer<T>();
        var equatableComparer = new EquatableComparer<T>();
        var objectComparer = new ObjectAssertComparer<T>();

        enumerableComparer.SetSuccessor(nullableComparer);
        nullableComparer.SetSuccessor(typeComparer);
        typeComparer.SetSuccessor(genericComparableComparer);
        genericComparableComparer.SetSuccessor(comparableComparererer);
        comparableComparererer.SetSuccessor(equatableComparer);
        equatableComparer.SetSuccessor(objectComparer);


        return enumerableComparer.Compare(x, y);
    
      
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