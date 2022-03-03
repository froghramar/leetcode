public class Solution {
    public int MaxDistance(int[][] grid)
    {
        var distance = new int[grid.Length, grid[0].Length];
        var queue = new Queue<Tuple<int,int>>();

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    queue.Enqueue(new Tuple<int, int>(i, j));
                }
            }
        }

        while (queue.Any())
        {
            var (i, j) = queue.Dequeue();
            var d = distance[i, j] + 1;
            Traverse(i, j - 1, d);
            Traverse(i, j + 1, d);
            Traverse(i - 1, j, d);
            Traverse(i + 1, j, d);
        }

        void Traverse(int i, int j, int d)
        {
            if (i >= 0 && i < grid.Length && j >= 0 && j < grid[i].Length && grid[i][j] == 0 && distance[i, j] == 0)
            {
                distance[i, j] = d;
                queue.Enqueue(new Tuple<int, int>(i, j));
            }
        }

        var res = -1;
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 0)
                {
                    res = Math.Max(res, distance[i, j]);
                }
            }
        }

        return res == 0 ? -1 : res;
    }
}