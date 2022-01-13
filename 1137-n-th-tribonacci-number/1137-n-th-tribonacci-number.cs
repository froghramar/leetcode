public class Solution {
    public int Tribonacci(int n)
    {
        var dp = new int[40];
        dp[0] = 0;
        dp[1] = 1;
        dp[2] = 1;

        for (var i = 3; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
        }

        return dp[n];
    }
}