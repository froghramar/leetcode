public class Solution {
    public int LengthOfLIS(int[] nums)
    {
        var dp = new int[nums.Length];
        dp[0] = 1;

        var result = 1;
        for (var i = 1; i < nums.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                dp[i] = Math.Max(dp[i], nums[i] > nums[j] ? 1 + dp[j] : 1);
                result = Math.Max(result, dp[i]);
            }
        }

        return result;
    }
}