public class Solution {
    public int MinCostClimbingStairs(int[] cost)
    {
        var dp = new int[cost.Length + 1];
        dp[1] = cost[0];

        for (var i = 2; i <= cost.Length; i++)
        {
            dp[i] = cost[i - 1] + Math.Min(dp[i - 1], dp[i - 2]);
        }
        
        return Math.Min(dp[cost.Length], dp[cost.Length - 1]);
    }
}