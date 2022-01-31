public class Solution {
    public int Change(int amount, int[] coins)
    {
        var dp = new int[coins.Length][];
        var visited = new bool[coins.Length][];

        for (var i = 0; i < coins.Length; i++)
        {
            dp[i] = new int[amount + 1];
            visited[i] = new bool[amount + 1];
        }

        return ChangeInternal(amount, coins, coins.Length - 1, dp, visited);
    }

    private int ChangeInternal(int amount, int[] coins, int coinIndex, int[][] dp, bool[][] visited)
    {
        if (amount == 0)
        {
            return 1;
        }

        if (amount < 0)
        {
            return 0;
        }

        if (coinIndex < 0)
        {
            return 0;
        }

        if (visited[coinIndex][amount])
        {
            return dp[coinIndex][amount];
        }

        visited[coinIndex][amount] = true;

        return dp[coinIndex][amount] = ChangeInternal(amount, coins, coinIndex - 1, dp, visited)
                                       + ChangeInternal(amount - coins[coinIndex], coins, coinIndex, dp, visited);
    }
}