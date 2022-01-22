public class Solution {
    public int NumDecodings(string s)
    {
        var dp = new int[s.Length];
        var visited = new bool[s.Length];
        return NumberDecodingsInternal(s, 0, dp, visited);
    }

    private int NumberDecodingsInternal(string s, int i, int[] dp, bool[] visited)
    {
        if (i >= s.Length)
        {
            return 1;
        }

        if (visited[i])
        {
            return dp[i];
        }

        visited[i] = true;

        if (s[i] == '0')
        {
            return dp[i] = 0;
        }

        if (i == s.Length - 1)
        {
            return dp[i] = 1;
        }

        if (s[i] == '1' || (s[i] == '2' && s[i + 1] <= '6'))
        {
            return dp[i] = NumberDecodingsInternal(s, i + 1, dp, visited)
                           + NumberDecodingsInternal(s, i + 2, dp, visited);
        }

        return dp[i] = NumberDecodingsInternal(s, i + 1, dp, visited);
    }
}