using System.Text;

public class Solution {
    public int TotalNQueens(int n)
    {
        var grid = new List<StringBuilder>();

        for (var i = 0; i < n; i++)
        {
            grid.Add(new StringBuilder(new string('.', n)));
        }

        var qRow = new bool[n];
        var qCol = new bool[n];
        var qPlus = new bool[2 * n];
        var qMinus = new bool[2 * n];
        
        return Solve(grid, 0, 0, qRow, qCol, qPlus, qMinus, 0);
    }

    private int Solve(
        IList<StringBuilder> grid, int i, int j,
        bool[] qRow, bool[] qCol, bool[] qPlus, bool[] qMinus, int qCount)
    {
        var n = grid.Count;
        if (qCount == n)
        {
            return 1;
        }

        if (i < 0 || i >= n || j < 0 || j >= n)
        {
            return 0;
        }

        var valid = !(qRow[i] || qCol[j] || qPlus[i + j] || qMinus[j - i + n]);
        
        int nextX = i, nextY = j + 1;
        if (nextY == n)
        {
            nextX++;
            nextY = 0;
        }
        var result = Solve(grid, nextX, nextY, qRow, qCol, qPlus, qMinus, qCount);

        if (valid)
        {
            grid[i][j] = 'Q';
            qRow[i] = true;
            qCol[j] = true;
            qPlus[i + j] = true;
            qMinus[j - i + n] = true;
            
            result += Solve(grid, nextX, nextY, qRow, qCol, qPlus, qMinus, qCount + 1);

            grid[i][j] = '.';
            qRow[i] = false;
            qCol[j] = false;
            qPlus[i + j] = false;
            qMinus[j - i + n] = false;
        }

        return result;
    }
}