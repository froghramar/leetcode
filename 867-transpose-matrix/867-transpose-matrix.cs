public class Solution {
    public int[][] Transpose(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        var result = new int[n][];
        for (var i = 0; i < n; i++)
        {
            result[i] = new int[m];
            for (var j = 0; j < m; j++)
            {
                result[i][j] = matrix[j][i];
            }
        }
        
        return result;
    }
}