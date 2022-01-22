public class Solution {
    public bool WinnerSquareGame(int n)
    {
        var squares = GetAllSquares(n);
        var dp = new bool[n + 1];
        dp[0] = false;

        for (var i = 1; i <= n; i++)
        {
            for (var j = 0; j < squares.Length && squares[j] <= i; j++)
            {
                if (dp[i - squares[j]] == false)
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[n];
    }

    private int[] GetAllSquares(int n)
    {
        var result = new List<int>();
        var lastNumber = (int) Math.Sqrt(n);
        for (var i = 1; i <= lastNumber; i++)
        {
            result.Add(i * i);
        }

        return result.ToArray();
    }
}