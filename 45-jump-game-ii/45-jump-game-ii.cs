public class Solution {
    public int Jump(int[] nums)
    {
        var dp = new int[nums.Length];
        dp[nums.Length - 1] = 0;

        for (var i = nums.Length - 2; i >= 0; i--)
        {
            var jumps = -1;
            for (var j = 1; j <= nums[i]; j++)
            {
                var index = i + j;
                if (index >= nums.Length || dp[index] == -1)
                {
                    continue;
                }

                if (jumps == -1)
                {
                    jumps = 1 + dp[index];
                }
                else
                {
                    jumps = Math.Min(jumps, 1 + dp[index]);
                }
            }

            dp[i] = jumps;
        }
        
        return dp[0];
    }
}