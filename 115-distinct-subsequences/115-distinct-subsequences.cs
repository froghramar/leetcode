public class Solution {
    public int NumDistinct(string s, string t)
    {
        var dp = new int[s.Length + 1, t.Length + 1];
        for (var i = 0; i <= s.Length; i++)
        {
            dp[i, 0] = 1;
        }

        for (var i = 1; i <= s.Length; i++)
        {
            for (var j = 1; j <= t.Length; j++)
            {
                if (s[i - 1] == t[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j];
                }
                else
                {
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }

        return dp[s.Length, t.Length];
    }
}