public class Solution {
    public int DeleteAndEarn(int[] nums)
    {
        var counts = new int[10001];
        
        foreach (var num in nums)
        {
            counts[num]++;
        }
        
        var dp = new int[counts.Length];
        dp[0] = 0;
        dp[1] = counts[1];

        for (var i = 2; i < counts.Length; i++)
        {
            dp[i] = Math.Max(dp[i - 1], i * counts[i] + dp[i - 2]);
        }

        return dp[counts.Length - 1];
    }
}