public class Solution {
    public int MaximumScore(int[] nums, int[] multipliers)
    {
        var dp =  new int[multipliers.Length][];
        var visited = new bool[multipliers.Length][];

        for (var i = 0; i < multipliers.Length; i++)
        {
            dp[i] = new int[multipliers.Length];
            visited[i] = new bool[multipliers.Length];
        }
        
        return MaximumScoreInternal(nums, multipliers, 0, 0, dp, visited);
    }

    private int MaximumScoreInternal(int[] nums, int[] multipliers, int i, int l, int[][] dp, bool[][] visited)
    {
        if (i == multipliers.Length)
        {
            return 0;
        }
        
        var r = nums.Length - (i - l) - 1;

        if (visited[i][l])
        {
            return dp[i][l];
        }

        visited[i][l] = true;

        return dp[i][l] = Math.Max(
            multipliers[i] * nums[l] + MaximumScoreInternal(nums, multipliers, i + 1, l + 1, dp, visited),
            multipliers[i] * nums[r] + MaximumScoreInternal(nums, multipliers, i + 1, l, dp, visited));
    }
}