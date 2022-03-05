public class Solution {
    public int ShortestBridge(int[][] grid)
    {
        var visited = new bool[grid.Length, grid[0].Length];
        var colors = new int[grid.Length, grid[0].Length];
        var color = 0;

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (!visited[i, j] && grid[i][j] == 1)
                {
                    Traverse(grid, i, j, visited, color++, colors);
                }
            }
        }

        var queue = new Queue<Tuple<int, int, int>>();
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                visited[i, j] = false;
                if (grid[i][j] == 1 && colors[i, j] == 0)
                {
                    AddToQueue(i, j, 0);
                }
            }
        }

        while (true)
        {
            var (i, j, d) = queue.Dequeue();
            if (colors[i, j] == 1)
            {
                return d - 1;
            }

            AddToQueue(i, j - 1, d + 1);
            AddToQueue(i, j + 1, d + 1);
            AddToQueue(i - 1, j, d + 1);
            AddToQueue(i + 1, j, d + 1);
        }

        void AddToQueue(int i, int j, int d)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length || visited[i, j])
            {
                return;
            }

            visited[i, j] = true;
            queue.Enqueue(new Tuple<int, int, int>(i, j, d));
        }
    }
    
    private void Traverse(int[][] grid, int r, int c, bool[,] visited, int color, int[,] colors)
    {
        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || visited[r, c] || grid[r][c] == 0)
        {
            return;
        }

        visited[r, c] = true;
        colors[r, c] = color;

        Traverse(grid, r, c - 1, visited, color, colors);
        Traverse(grid, r, c + 1, visited, color, colors);
        Traverse(grid, r - 1, c, visited, color, colors);
        Traverse(grid, r + 1, c, visited, color, colors);
    }
}