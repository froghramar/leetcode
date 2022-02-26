public class Solution {
    public int ShortestPathLength(int[][] graph)
    {
        var n = graph.Length;
        if (n == 1)
        {
            return 0;
        }
        
        var maskLength = 1 << n;
        var dp = new int[n, maskLength];
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < maskLength; j++)
            {
                dp[i, j] = -1;
            }
        }

        var queue = new Queue<Tuple<int, int>>();
        for (var i = 0; i < n; i++)
        {
            dp[i, maskLength - 1] = 0;
            queue.Enqueue(new Tuple<int, int>(i, maskLength - 1));
        }

        while (queue.Any())
        {
            var (i, visited) = queue.Dequeue();
            var mask = RemoveBit(visited, i);

            foreach (var j in graph[i])
            {
                if (dp[j, mask] == -1)
                {
                    dp[j, mask] = 1 + dp[i, visited];
                    queue.Enqueue(new Tuple<int, int>(j, mask));
                }
            }
        }

        var result = int.MaxValue;
        for (var i = 0; i < n; i++)
        {
            result = Math.Min(result, dp[i, 0]);
        }
        
        return result - 1;
    }
    
    private static bool HasBit(int n, int i)
    {
        return (n & (1 << i)) > 0;
    }
    
    private static int RemoveBit(int n, int i)
    {
        return HasBit(n, i) ? n - (1 << i) : n;
    }
}