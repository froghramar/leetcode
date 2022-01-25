public class Solution {
    public int LongestCommonSubsequence(string text1, string text2)
    {
        var dp = new int[text1.Length][];

        for (var i = 0; i < text1.Length; i++)
        {
            dp[i] = new int[text2.Length];

            for (var j = 0; j < text2.Length; j++)
            {
                if (text1[i] == text2[j])
                {
                    dp[i][j] = 1 + Get(i - 1, j - 1);
                }
                else
                {
                    dp[i][j] = Math.Max(Get(i, j - 1), Get(i - 1, j));
                }
            }
        }

        int Get(int i, int j)
        {
            if (i < 0 || i >= text1.Length || j < 0 || j >= text2.Length)
            {
                return 0;
            }

            return dp[i][j];
        }

        return dp[text1.Length - 1][text2.Length - 1];
    }
}