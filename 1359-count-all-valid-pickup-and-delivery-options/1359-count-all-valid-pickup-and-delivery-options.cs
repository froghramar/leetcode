public class Solution {
    public int CountOrders(int n)
    {
        const int MOD = 1_000_000_007;
        
        var dp = new long[n + 1];
        dp[1] = 1;
        for (var i = 2; i <= n; i++)
        {
            var N = 2 * (i - 1) + 1;
            var multiply = (N * (N + 1)) / 2;
            
            dp[i] = (dp[i - 1] * multiply) % MOD;
        }
        
        return (int) dp[n];
    }
}