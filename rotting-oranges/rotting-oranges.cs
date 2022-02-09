public class Solution {
    public int OrangesRotting(int[][] grid)
    {
        var res = new int[grid.Length][];
        for (var i = 0; i < res.Length; i++)
        {
            res[i] = new int[grid[i].Length];
        }

        var queue = new Queue<Tuple<int, int>>();
        var visited = new bool[grid.Length, grid[0].Length];
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 2)
                {
                    SetValue(i, j, 0);
                }
            }
        }

        var ans = 0;
        while (queue.Any())
        {
            var (i, j) = queue.Dequeue();
            var newValue = res[i][j] + 1;
            SetValue(i, j - 1, newValue);
            SetValue(i, j + 1, newValue);
            SetValue(i - 1, j, newValue);
            SetValue(i + 1, j, newValue);
        }
        
        void SetValue(int i, int j, int value)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || visited[i, j] || grid[i][j] == 0)
            {
                return;
            }
            
            queue.Enqueue(new Tuple<int, int>(i, j));
            res[i][j] = value;
            visited[i, j] = true;
            ans = value;
        }

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[0].Length; j++)
            {
                if (visited[i, j] is false && grid[i][j] == 1)
                {
                    return -1;
                }
            }
        }

        return ans;
    }
}