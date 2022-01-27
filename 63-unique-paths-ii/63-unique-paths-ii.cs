public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        int m = obstacleGrid.Length, n = obstacleGrid[0].Length;
        var dp = new int[m][];
        for (var i = 0; i < m; i++)
        {
            dp[i] = new int[n];
        }

        dp[0][0] = 1 - obstacleGrid[0][0];
        for (var i = 1; i < m; i++)
        {
            dp[i][0] = (1 - obstacleGrid[i][0]) * dp[i - 1][0];
        }

        for (var i = 1; i < n; i++)
        {
            dp[0][i] = (1 - obstacleGrid[0][i]) * dp[0][i - 1];
        }

        for (var i = 1; i < m; i++)
        {
            for (var j = 1; j < n; j++)
            {
                if (obstacleGrid[i][j] == 0)
                {
                    dp[i][j] = dp[i][j - 1] + dp[i - 1][j];
                }
            }
        }

        return dp[m - 1][n - 1];
    }
}