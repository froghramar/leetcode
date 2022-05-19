public class Solution {
    public int LongestIncreasingPath(int[][] matrix)
    {
        var dp = new int[matrix.Length][];
        for (var i = 0; i < matrix.Length; i++)
        {
            dp[i] = new int[matrix[0].Length];
            Array.Fill(dp[i], -1);
        }

        var result = 0;
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[0].Length; j++)
            {
                result = Math.Max(result, Get(i, j, matrix, dp));
            }
        }
        return result;
    }

    private static int Get(int x, int y, int[][] matrix, int[][] dp)
    {
        if (dp[x][y] != -1)
        {
            return dp[x][y];
        }

        var result = 1;

        Consider(x, y - 1);
        Consider(x, y + 1);
        Consider(x - 1, y);
        Consider(x + 1, y);

        void Consider(int x1, int y1)
        {
            if (x1 >= 0 && x1 < matrix.Length && y1 >= 0 && y1 < matrix[0].Length && matrix[x1][y1] > matrix[x][y])
            {
                result = Math.Max(result, 1 + Get(x1, y1, matrix, dp));
            }
        }
        
        return dp[x][y] = result;
    }
}