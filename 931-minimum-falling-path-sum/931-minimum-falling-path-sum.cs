public class Solution {
    public int MinFallingPathSum(int[][] matrix) {
        for (var i = matrix.Length - 2; i >= 0; i--)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                matrix[i][j] += GetMin(
                    j > 0 ? matrix[i + 1][j - 1] : int.MaxValue,
                    matrix[i + 1][j], 
                    j < matrix[i].Length - 1 ? matrix[i + 1][j + 1] : int.MaxValue);
            }
        }

        var result = int.MaxValue;
        for (var i = 0; i < matrix[0].Length; i++)
        {
            result = Math.Min(result, matrix[0][i]);
        }

        return result;
    }

    private static int GetMin(int x, int y, int z)
    {
        return Math.Min(x, Math.Min(y, z));
    }
}