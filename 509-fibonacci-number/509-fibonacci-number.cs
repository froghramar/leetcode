public class Solution {
    public int Fib(int n)
    {
        var dp = new int[35];
        dp[0] = 0;
        dp[1] = 1;

        for (var i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[n];
    }
}