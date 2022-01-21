public class Solution {
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var dp = new bool[s.Length, s.Length];
        var visited = new bool[s.Length, s.Length];
        
        return CanBreak(0, s.Length - 1, s, wordDict, dp, visited);
    }

    public bool CanBreak(int i, int j, string s, IList<string> wordDict, bool[,] dp, bool[,] visited)
    {
        if (visited[i, j])
        {
            return dp[i, j];
        }

        visited[i, j] = true;
        
        if (wordDict.Contains(s.Substring(i, j - i + 1)))
        {
            return dp[i, j] = true;
        }

        for (var k = i; k < j; k++)
        {
            if (CanBreak(i, k, s, wordDict, dp, visited) && CanBreak(k + 1, j, s, wordDict, dp, visited))
            {
                return dp[i, j] = true;
            }
        }

        return dp[i, j] = false;
    }
}