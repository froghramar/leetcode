public class Solution {
    public bool IsMatch(string s, string p) {
        var dp = new bool[p.Length + 1, s.Length + 1];
        dp[0, 0] = true;
        
        for (var i = 1; i <= p.Length; i++)
        {
            var ch = p[i - 1];
            dp[i, 0] = ch == '*' && dp[i - 1, 0];
            for (var j = 1; j <= s.Length; j++)
            {
                switch (ch)
                {
                    case '*':
                        dp[i, j] = dp[i, j - 1] || dp[i - 1, j - 1] || dp[i - 1, j];
                        break;
                    case '?':
                        dp[i, j] = dp[i - 1, j - 1];
                        break;
                    default:
                        dp[i, j] = p[i - 1] == s[j - 1] && dp[i - 1, j - 1];
                        break;
                }
            }
        }

        return dp[p.Length, s.Length];
    }
}