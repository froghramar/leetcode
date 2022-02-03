public class Solution {
    public bool Exist(char[][] board, string word) {
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (ExistInternal(board, word, i, j, 0))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool ExistInternal(char[][] board, string word, int i, int j, int s)
    {
        if (s == word.Length)
        {
            return true;
        }

        if (i < 0 || i >= board.Length || j < 0 || j >= board[i].Length || board[i][j] != word[s])
        {
            return false;
        }

        var ch = board[i][j];
        board[i][j] = 'X';

        var moves = new Tuple<int, int>[] { new(0, -1), new(0, 1), new(-1, 0), new(1, 0) };
        foreach (var (x, y) in moves)
        {
            if (ExistInternal(board, word, i + x, j + y, s + 1))
            {
                return true;
            }
        }

        board[i][j] = ch;
        return false;
    }
}