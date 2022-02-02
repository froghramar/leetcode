public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        if (grid[0][0] == 1)
        {
            return -1;
        }

        var dp = new int[grid.Length][];
        var visited = new bool[grid.Length][];

        for (var i = 0; i < grid.Length; i++)
        {
            dp[i] = new int[grid.Length];
            visited[i] = new bool[grid.Length];
        }
        
        var queue = new Queue<Tuple<int, int>>();
        queue.Enqueue(new Tuple<int, int>(0, 0) );
        dp[0][0] = 1;
        visited[0][0] = true;

        while (queue.Any())
        {
            var pos = queue.Dequeue();

            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    var newPos = (pos.Item1 + i, pos.Item2 + j);
                    if (newPos.Item1 < 0 || newPos.Item1 >= grid.Length || newPos.Item2 < 0 ||
                        newPos.Item2 >= grid.Length || visited[newPos.Item1][newPos.Item2] || grid[newPos.Item1][newPos.Item2] == 1)
                    {
                        continue;
                    }

                    queue.Enqueue(new Tuple<int, int>(newPos.Item1, newPos.Item2));
                    visited[newPos.Item1][newPos.Item2] = true;
                    dp[newPos.Item1][newPos.Item2] = 1 + dp[pos.Item1][pos.Item2];
                }
            }
        }
        
        var result = dp[grid.Length - 1][grid.Length - 1];
        return result == 0 ? -1 : result;
    }
}