public class Solution {
    public int NthUglyNumber(int n, int a, int b, int c)
    {
        int l = 1, r = (int) 2e9;
        while (l < r)
        {
            var m = (int)(((long)l + r) / 2);
            if (NumberOfUglyNumbers(m, a, b, c) >= n)
            {
                r = m;
            }
            else
            {
                l = m + 1;
            }
        }

        return l;
    }

    private static int NumberOfUglyNumbers(int n, int a, int b, int c)
    {
        return (int)(n / a + n / b + n / c - n / LCM(a, b) - n / LCM(b, c) - n / LCM(c, a) + n / LCM(a, b, c));
    }
    
    private static long LCM(int n1, int n2, int n3)
    {
        return LCM(n1, LCM(n2, n3));
    }

    private static long LCM(long n1, long n2)
    {
        return n1 * n2 / GCD(n1, n2);
    }
    
    private static long GCD(long n1, long n2)
    {
        return n2 == 0 ? n1 : GCD(n2, n1 % n2);
    }
}