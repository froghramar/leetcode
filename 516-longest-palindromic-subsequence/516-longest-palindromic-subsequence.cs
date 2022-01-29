public class Solution {
    public int LongestPalindromeSubseq(string s)
    {
        var dp = new int[s.Length][];

        for (var i = 0; i < s.Length; i++)
        {
            dp[i] = new int[dp.Length];
        }

        return LongestPalindromeSubseqInternal(s, 0, s.Length - 1, dp);
    }

    private int LongestPalindromeSubseqInternal(string s, int i, int j, int[][] dp)
    {
        if (i > j)
        {
            return 0;
        }

        if (i == j)
        {
            return 1;
        }

        if (dp[i][j] > 0)
        {
            return dp[i][j];
        }

        if (s[i] == s[j])
        {
            return dp[i][j] = 2 + LongestPalindromeSubseqInternal(s, i + 1, j - 1, dp);
        }

        return dp[i][j] = Math.Max(
            LongestPalindromeSubseqInternal(s, i + 1, j, dp),
            LongestPalindromeSubseqInternal(s, i, j - 1, dp));
    }
}