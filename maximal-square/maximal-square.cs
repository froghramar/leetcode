public class Solution {
    public int MaximalSquare(char[][] matrix)
    {
        var dp = new int[matrix.Length][];
        for (var i = 0; i < matrix.Length; i++)
        {
            dp[i] = new int[matrix[i].Length];

            for (var j = 0; j < matrix[i].Length; j++)
            {
                dp[i][j] = Get(i, j - 1) + Get(i - 1, j) - Get(i - 1, j - 1) + matrix[i][j] - '0';
            }
        }

        var result = 0;
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                var len = Math.Max(matrix.Length - i, matrix[i].Length - j);
                for (var k = 0; k < len; k++)
                {
                    int ri = i + k, rj = j + k;
                    var current = Get(ri, rj) - Get(i - 1, rj) - Get(ri, j - 1) + Get(i - 1, j - 1);
                    if (current == (k + 1) * (k + 1))
                    {
                        result = Math.Max(result, current);
                    }
                }
            }
        }

        int Get(int i, int j)
        {
            if (i < 0 || i >= matrix.Length || j < 0 || j >= matrix[i].Length)
            {
                return 0;
            }

            return dp[i][j];
        }

        return result;
    }
}