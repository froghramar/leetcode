public class Solution {
    public int MaximalNetworkRank(int n, int[][] roads)
    {
        var count = new int[n];
        var isConnected = new bool[n, n];
        foreach (var road in roads)
        {
            count[road[0]]++;
            count[road[1]]++;

            isConnected[road[0], road[1]] = true;
            isConnected[road[1], road[0]] = true;
        }

        var result = 0;
        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                var sum = count[i] + count[j];
                if (isConnected[i, j])
                {
                    sum--;
                }

                result = Math.Max(result, sum);
            }
        }
        return result;
    }
}