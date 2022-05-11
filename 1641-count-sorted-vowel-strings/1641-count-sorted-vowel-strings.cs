public class Solution {
    public int CountVowelStrings(int n)
    {
        var dp = new int[n, 5];
        for (var i = 0; i < 5; i++)
        {
            dp[0, i] = 1;
        }

        for (var i = 1; i < n; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                for (var k = 0; k <= j; k++)
                {
                    dp[i, j] += dp[i - 1, k];
                }
            }
        }

        var result = 0;
        for (var i = 0; i < 5; i++)
        {
            result += dp[n - 1, i];
        }

        return result;
    }
}