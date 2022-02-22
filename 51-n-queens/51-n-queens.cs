using System.Text;

public class Solution {
    public IList<IList<string>> SolveNQueens(int n)
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

        var result = new List<IList<string>>();
        Solve(grid, 0, 0, result, qRow, qCol, qPlus, qMinus, 0);
        return result;
    }

    private void Solve(
        IList<StringBuilder> grid, int i, int j, IList<IList<string>> result,
        bool[] qRow, bool[] qCol, bool[] qPlus, bool[] qMinus, int qCount)
    {
        var n = grid.Count;
        if (qCount == n)
        {
            var copy = new List<string>();
            foreach (var s in grid)
            {
                copy.Add(s.ToString());
            }
            result.Add(copy);
            return;
        }

        if (i < 0 || i >= n || j < 0 || j >= n)
        {
            return;
        }

        var valid = !(qRow[i] || qCol[j] || qPlus[i + j] || qMinus[j - i + n]);
        
        int nextX = i, nextY = j + 1;
        if (nextY == n)
        {
            nextX++;
            nextY = 0;
        }
        Solve(grid, nextX, nextY, result, qRow, qCol, qPlus, qMinus, qCount);

        if (valid)
        {
            grid[i][j] = 'Q';
            qRow[i] = true;
            qCol[j] = true;
            qPlus[i + j] = true;
            qMinus[j - i + n] = true;
            
            Solve(grid, nextX, nextY, result, qRow, qCol, qPlus, qMinus, qCount + 1);

            grid[i][j] = '.';
            qRow[i] = false;
            qCol[j] = false;
            qPlus[i + j] = false;
            qMinus[j - i + n] = false;
        }
    }
}