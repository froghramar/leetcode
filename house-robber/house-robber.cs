public class Solution {
    public int Rob(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }
        
        var dp = new int[nums.Length];
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[1], nums[0]);

        for (var i = 2; i < nums.Length; i++)
        {
            dp[i] = Math.Max(dp[i - 1], nums[i] + dp[i - 2]);
        }

        return dp[nums.Length - 1];
    }
}