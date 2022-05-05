public class Solution {
    public int MaxValue(int n, int index, int maxSum)
    {
        int l = 1, r = maxSum;
        while (l < r)
        {
            var m = (l + r + 1) / 2;
            
            var sum = GetSeriesSum(m - 1, index) + m + GetSeriesSum(m - 1, n - index - 1);

            if (sum <= maxSum)
            {
                l = m;
            }
            else
            {
                r = m - 1;
            }
        }

        return l;
    }

    private static long GetSeriesSum(int start, int len)
    {
        return GetSeriesSum(start) - GetSeriesSum(Math.Max(start - len, 0)) + Math.Max(len - start, 0);
    }

    private static long GetSeriesSum(int n)
    {
        return (long)n * (n + 1) / 2;
    }
}