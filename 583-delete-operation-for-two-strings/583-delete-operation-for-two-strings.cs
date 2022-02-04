public class Solution {
    public int MinDistance(string word1, string word2)
    {
        var dp = new int[word1.Length][];
        for (var i = 0; i < word1.Length; i++)
        {
            dp[i] = new int[word2.Length];
        }
        
        for (var i = 0; i < word1.Length; i++)
        {
            for (var j = 0; j < word2.Length; j++)
            {
                if (word1[i] == word2[j])
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
            if (i < 0 || i >= word1.Length || j < 0 || j >= word2.Length)
            {
                return 0;
            }

            return dp[i][j];
        }
        
        return word1.Length + word2.Length - 2 * dp[word1.Length - 1][word2.Length - 1];
    }
}