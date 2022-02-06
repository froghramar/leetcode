public class Solution {
    public int FindNumberOfLIS(int[] nums)
    {
        var dp = new int[nums.Length];
        var count = new int[nums.Length];
        var max = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            dp[i] = 1;
            count[i] = 1;
            for (var j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    var len = 1 + dp[j];
                    if (len > dp[i])
                    {
                        dp[i] = len;
                        count[i] = count[j];
                    }
                    else if (len == dp[i])
                    {
                        count[i] += count[j];
                    }
                }
            }

            max = Math.Max(max, dp[i]);
        }

        var result = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (dp[i] == max)
            {
                result += count[i];
            }
        }
        return result;
    }
}