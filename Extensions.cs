﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public static class Extensions
    {
        public static void Deconstruct<T>(this IList<T> list, out T first, out T second) 
        {
            first = list.Count > 0 ? list[0] : default!;
            second = list.Count > 1 ? list[1] : default!; 
        }

        public static void Deconstruct<T>(this IList<T> list, out T first, out T second, out IList<T> rest) 
        {
            first = list.Count > 0 ? list[0] : default!; 
            second = list.Count > 1 ? list[1] : default!;
            rest = list.Skip(2).ToList();
        }
    }
}
