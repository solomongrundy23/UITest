using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Helpers
{
    public static class Exts
    {
        public static T Random<T>(this List<T> list) => list[new Random().Next(list.Count - 1)];
        public static string Text<T>(this List<T> list) => string.Join(Environment.NewLine, list);
    }
}
