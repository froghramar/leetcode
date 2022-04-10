public class Solution {
    public int ArrangeCoins(int n)
    {
        int l = 1, r = n;
        while (l < r)
        {
            var m = l + (r - l + 1) / 2;
            try
            {
                var cnt = GetCount(m);
                if (cnt > n)
                {
                    r = m - 1;
                }
                else
                {
                    l = m;
                }
            }
            catch (OverflowException)
            {
                r = m - 1;
            }
        }

        return l;
    }

    private static int GetCount(int n)
    {
        if (n % 2 == 0)
        {
            return checked((n / 2) * (n + 1));
        }
        return checked(n * ((n + 1) / 2));
    }
}