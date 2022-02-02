public class Solution {
    public int NumSquares(int n)
    {
        var dp = new int[n + 1];
        dp[1] = 1;

        for (var i = 2; i <= n; i++)
        {
            var sqrt = (int) Math.Sqrt(i);
            dp[i] = int.MaxValue;
            
            for (var j = 1; j <= sqrt; j++)
            {
                dp[i] = Math.Min(dp[i], 1 + dp[i - j * j]);
            }
        }

        return dp[n];
    }
}