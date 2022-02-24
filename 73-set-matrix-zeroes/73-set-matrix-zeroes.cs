public class Solution {
    public void SetZeroes(int[][] matrix)
    {
        var isRow = new bool[matrix.Length];
        var isCol = new bool[matrix[0].Length];
        
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == 0)
                {
                    isRow[i] = true;
                    isCol[j] = true;
                }
            }
        }
        
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                if (isRow[i] || isCol[j])
                {
                    matrix[i][j] = 0;
                }
            }
        }
    }
}