public class Solution {
    public void GameOfLife(int[][] board)
    {
        var cpy = new int[board.Length][];
        for (var i = 0; i < board.Length; i++)
        {
            cpy[i] = new int[board[i].Length];
            Array.Copy(board[i], 0, cpy[i], 0, board[i].Length);
        }

        for (var i = 0; i < board.Length; i++)
        {
            for (var j = 0; j < board[i].Length; j++)
            {
                var live = 0;
                for (var dx = -1; dx <= 1; dx++)
                {
                    for (var dy = -1; dy <= 1; dy++)
                    {
                        var (x, y) = (i + dx, j + dy);
                        if (x >= 0 && x < board.Length && y >= 0 && y < board[x].Length)
                        {
                            live += cpy[x][y];
                        }
                    }
                }

                live -= cpy[i][j];

                if (board[i][j] == 0)
                {
                    if (live == 3)
                    {
                        board[i][j] = 1;
                    }
                    continue;
                }

                if (live is < 2 or > 3)
                {
                    board[i][j] = 0;
                }
            }
        }
    }
}