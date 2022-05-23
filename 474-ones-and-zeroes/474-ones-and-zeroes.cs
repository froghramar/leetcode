public class Solution {
    public int FindMaxForm(string[] strs, int m, int n) {
        var dp = new int[m + 1][];
        for (var i = 0; i <= m; i++)
        {
            dp[i] = new int[n + 1];
        }
        
        foreach (var str in strs)
        {
            var zeroes = str.Count(ch => ch == '0');
            var ones = str.Count(ch => ch == '1');
            
            for (var i = m; i >= zeroes; i--)
            {
                for (var j = n; j >= ones; j--)
                {
                    dp[i][j] = Math.Max(dp[i][j], 1 + dp[i - zeroes][j - ones]);
                }
            }
        }
        return dp[m][n];
    }
}