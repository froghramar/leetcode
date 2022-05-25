public class Solution {
    public int MaxEnvelopes(int[][] envelopes)
    {
        Array.Sort(envelopes, (a, b) => a[0] == b[0] ? b[1].CompareTo(a[1]) : a[0].CompareTo(b[0]));

        var dp = new int[envelopes.Length];
        var len = 0;
        foreach (var envelope in envelopes)
        {
            var index = Array.BinarySearch(dp, 0, len, envelope[1]);
            if (index < 0)
            {
                index = ~index;
            }

            dp[index] = envelope[1];
            if (index == len)
            {
                len++;
            }
        }
        return len;
    }
}