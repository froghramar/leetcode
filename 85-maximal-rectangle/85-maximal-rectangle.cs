public class Solution {
    public int MaximalRectangle(char[][] matrix)
    {
        var left = new int[matrix.Length, matrix[0].Length];
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == '1')
                {
                    left[i, j] = 1 + (j == 0 ? 0 : left[i, j - 1]);
                }
            }
        }

        var result = 0;
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                var width = int.MaxValue;
                for (var k = i; k < matrix.Length; k++)
                {
                    width = Math.Min(width, left[k, j]);
                    result = Math.Max(result, width * (k - i + 1));
                }
            }
        }
        return result;
    }
}