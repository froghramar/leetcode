public class Solution {
    public int MinDistance(string word1, string word2)
    {
        var dp = new int[word1.Length][];
        var visited = new bool[word1.Length][];
        for (var i = 0; i < word1.Length; i++)
        {
            dp[i] = new int[word2.Length];
            visited[i] = new bool[word2.Length];
        }

        return MinDistanceInternal(word1, word2, 0, 0, dp, visited);
    }

    private int MinDistanceInternal(string word1, string word2, int id1, int id2, int[][] dp, bool[][] visited)
    {
        if (id2 == word2.Length)
        {
            return word1.Length - id1;
        }

        if (id1 == word1.Length)
        {
            return word2.Length - id2;
        }

        if (visited[id1][id2])
        {
            return dp[id1][id2];
        }

        visited[id1][id2] = true;

        if (word1[id1] == word2[id2])
        {
            return dp[id1][id2] = MinDistanceInternal(word1, word2, id1 + 1, id2 + 1, dp, visited);
        }

        return dp[id1][id2] = 1 + Math.Min(
            MinDistanceInternal(word1, word2, id1, id2 + 1, dp, visited), // add
            Math.Min(MinDistanceInternal(word1, word2, id1 + 1, id2 + 1, dp, visited), // replace
                MinDistanceInternal(word1, word2, id1 + 1, id2, dp, visited))); // remove
    }
}