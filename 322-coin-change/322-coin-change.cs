public class Solution {
    public int CoinChange(int[] coins, int amount)
    {
        var dp = new int[amount + 1];
        for (var i = 1; i <= amount; i++)
        {
            dp[i] = -1;
            foreach (var coin in coins)
            {
                var last = i - coin;
                if (last < 0 || dp[last] == -1)
                {
                    continue;
                }

                dp[i] = dp[i] == -1 ? 1 + dp[last] : Math.Min(dp[i], dp[last] + 1);
            }
        }

        return dp[amount];
    }
}