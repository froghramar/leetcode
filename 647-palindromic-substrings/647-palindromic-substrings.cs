public class Solution {
    public int CountSubstrings(string s)
    {
        var visited = new bool[s.Length][];
        var dp = new bool[s.Length][];
        for (var i = 0; i < s.Length; i++)
        {
            dp[i] = new bool[s.Length];
            visited[i] = new bool[s.Length];
        }

        var result = 0;
        for (var i = 0; i < s.Length; i++)
        {
            for (var j = i; j < s.Length; j++)
            {
                if (IsPalindromeSubstring(s, i, j, dp, visited))
                {
                    result++;
                }
            }
        }
        
        return result;
    }
    
    private static bool IsPalindromeSubstring(string s, int l, int r, bool[][] dp, bool[][] visited) {
        if (l > r)
        {
            return true;
        }

        if (visited[l][r])
        {
            return dp[l][r];
        }

        visited[l][r] = true;
        return dp[l][r] = s[l] == s[r] && IsPalindromeSubstring(s, l + 1, r - 1, dp, visited);
    }
}