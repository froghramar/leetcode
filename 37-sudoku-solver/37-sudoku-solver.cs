public class Solution {
    public void SolveSudoku(char[][] board)
    {
        var rowFound = new bool[9, 9];
        var colFound = new bool[9, 9];
        var boxFound = new bool[9, 9];

        for (var i = 0; i < 9; i++)
        {
            for (var j = 0; j < 9; j++)
            {
                var ch = board[i][j];
                if (ch != '.')
                {
                    var val = ch - '1';
                    rowFound[i, val] = true;
                    colFound[j, val] = true;
                    
                    var box = GetBoxCoordinate(i, j);
                    boxFound[box, val] = true;
                }
            }
        }
        
        SolveSudokuInternal(board, rowFound, colFound, boxFound);
    }
    
    private bool SolveSudokuInternal(char[][] board, bool[,] rowFound, bool[,] colFound, bool[,] boxFound)
    {
        int x = -1, y = -1;
        for (var i = 0; i < 9 && x == -1; i++)
        {
            for (var j = 0; j < 9 && x == -1; j++)
            {
                if (board[i][j] == '.')
                {
                    x = i;
                    y = j;
                }
            }
        }

        if (x == -1)
        {
            return true;
        }

        for (var p = 0; p < 9; p++)
        {
            var box = GetBoxCoordinate(x, y);
            if (rowFound[x, p] || colFound[y, p] || boxFound[box, p])
            {
                continue;
            }

            rowFound[x, p] = true;
            colFound[y, p] = true;
            boxFound[box, p] = true;
            board[x][y] = (char)('1' + p);
            
            if (SolveSudokuInternal(board, rowFound, colFound, boxFound))
            {
                return true;
            }
            
            rowFound[x, p] = false;
            colFound[y, p] = false;
            boxFound[box, p] = false;
            board[x][y] = '.';
        }

        return false;
    }

    private static int GetBoxCoordinate(int i, int j)
    {
        return (i / 3) * 3 + j / 3;
    }
}