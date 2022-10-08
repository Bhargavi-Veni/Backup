using System;

namespace SwapNum
{
    public class Swap
    {
        (int, int) num = swap(30, 40);
        public static (int, int) swap(int a, int b)
        {
            return (b, a);
        }

        public static (int, int) swap()
        {
            var a = 2;
            var b = 3;
            return (b, a);
        }
    }
}
