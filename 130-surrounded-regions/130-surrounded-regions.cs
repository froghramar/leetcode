public class Solution
{
    public void Solve(char[][] board)
    {
        var m = board.Length;
        var n = board[0].Length;
        var visited = new bool[m, n];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (board[i][j] == 'O' && ConnectedToBoundary(board, i, j))
                {
                    Dfs(board, visited, i, j);
                }
            }
        }

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (board[i][j] == 'O')
                {
                    board[i][j] = 'X';
                }
                else if (board[i][j] == 'C')
                {
                    board[i][j] = 'O';
                }
            }
        }
    }

    private bool ConnectedToBoundary(char[][] board, int i, int j)
    {
        return i == 0 || i == board.Length - 1 || j == 0 || j == board[0].Length - 1;
    }

    private void Dfs(char[][] board, bool[,] visited, int i, int j)
    {
        if (i >= 0 && i < board.Length && j >= 0 && j < board[0].Length && !visited[i, j] && board[i][j] == 'O')
        {
            visited[i, j] = true;
            board[i][j] = 'C';
            Dfs(board, visited, i - 1, j);
            Dfs(board, visited, i + 1, j);
            Dfs(board, visited, i, j - 1);
            Dfs(board, visited, i, j + 1);
        }
    }
}