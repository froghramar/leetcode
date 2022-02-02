public class Solution {
    public int IntegerBreak(int n)
    {
        if (n < 4)
        {
            return n - 1;
        }
        
        var dp = new int[n + 1];

        for (var i = 2; i <= n; i++)
        {
            dp[i] = i;
            for (var j = 1; j < i; j++)
            {
                dp[i] = Math.Max(dp[i], (i - j) * dp[j]);
            }
        }
        
        return dp[n];
    }
}