public class Solution {
    public int MinimumEffortPath(int[][] heights)
    {
        int m = heights.Length, n = heights[0].Length;
        var d = new int[m][];
        for (var i = 0; i < m; i++)
        {
            d[i] = new int[n];
            Array.Fill(d[i], int.MaxValue);
        }

        var queue = new Queue<Tuple<int, int>>();
        queue.Enqueue(new Tuple<int, int>(0, 0));
        d[0][0] = 0;

        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();
            AddToQueue(x, y, x - 1, y);
            AddToQueue(x, y, x + 1, y);
            AddToQueue(x, y, x, y - 1);
            AddToQueue(x, y, x, y + 1);
        }

        void AddToQueue(int x1, int y1, int x2, int y2)
        {
            if (x2 < 0 || x2 >= m || y2 < 0 || y2 >= n)
            {
                return;
            }
            
            var effort = Math.Max(d[x1][y1], Math.Abs(heights[x2][y2] - heights[x1][y1]));
            if (effort >= d[x2][y2])
            {
                return;
            }

            d[x2][y2] = effort;
            queue.Enqueue(new Tuple<int, int>(x2, y2));
        }

        return d[m - 1][n - 1];
    }
}