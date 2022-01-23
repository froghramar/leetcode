public class Solution {
    public int NumTrees(int n)
    {
        var dp = new int[n + 1];
        dp[0] = 1;

        for (var i = 1; i <= n; i++)
        {
            for (var j = 1; j <= i; j++)
            {
                dp[i] += dp[j - 1] * dp[i - j];
            }
        }

        return dp[n];
    }
}