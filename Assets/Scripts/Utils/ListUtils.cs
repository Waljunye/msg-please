using System;
using System.Collections.Generic;

namespace Utils
{
    public static class ListUtils
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random random = new Random();
            
            for (int i = list.Count - 1; i > 0; i--)
            {
                int randomIndex = random.Next(i + 1);
                (list[i], list[randomIndex]) = (list[randomIndex], list[i]);
            }
        }
    }
}