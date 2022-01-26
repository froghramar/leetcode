public class NumMatrix
{
    private int[][] _total;
    
    public NumMatrix(int[][] matrix)
    {
        _total = new int[matrix.Length][];

        for (var i = 0; i < matrix.Length; i++)
        {
            _total[i] = new int[matrix[i].Length];

            for (var j = 0; j < matrix[i].Length; j++)
            {
                _total[i][j] = matrix[i][j] + Get(i, j - 1) + Get(i - 1, j) - Get(i - 1, j - 1);
            }
        }
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        return Get(row2, col2) - Get(row2, col1 - 1) - Get(row1 - 1, col2) + Get(row1 - 1, col1 - 1);
    }
    
    private int Get(int i, int j)
    {
        if (i >= 0 && i < _total.Length && j >= 0 && j < _total[i].Length)
        {
            return _total[i][j];
        }

        return 0;
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */