public class Solution
{
    private bool[,] _visited = new bool[25, 25];
    
    public void Rotate(int[][] matrix)
    {
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix.Length; j++)
            {
                var (newI, newJ) = GetRowColumnAfterRotation(i, j, matrix.Length);
                Rotate(matrix, newI, newJ, matrix[i][j]);
            }
        }
    }

    private void Rotate(int[][] matrix, int i, int j, int newValue)
    {
        if (_visited[i, j])
        {
            return;
        }

        _visited[i, j] = true;
        
        var current = matrix[i][j];
        matrix[i][j] = newValue;
        
        var (newI, newJ) = GetRowColumnAfterRotation(i, j, matrix.Length);
        Rotate(matrix, newI, newJ, current);
    }

    private (int, int) GetRowColumnAfterRotation(int i, int j, int n)
    {
        return (j, n - i - 1);
    }
}