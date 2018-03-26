using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> Except<T>(this IEnumerable<T> list, T item) => 
            list.Except(new[] { item });
    }
}
