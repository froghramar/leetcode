public class Solution {
    public int ClosedIsland(int[][] grid)
    {
        var visited = new bool[grid.Length, grid[0].Length];
        var colors = new int[grid.Length, grid[0].Length];
        var color = 0;

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (!visited[i, j] && grid[i][j] == 0)
                {
                    Traverse(grid, i, j, visited, color++, colors);
                }
            }
        }

        var open = new bool[color];
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    continue;
                }

                CheckIfOpen(i, j, 0, 1);
                CheckIfOpen(i, j, 0, -1);
                CheckIfOpen(i, j, 1, 0);
                CheckIfOpen(i, j, -1, 0);
            }
        }

        void CheckIfOpen(int i, int j, int dx, int dy)
        {
            int r = i + dx, c = j + dy;
            if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length)
            {
                open[colors[i, j]] = true;
            }
        }

        return open.Count(o => o is false);
    }
    
    private void Traverse(int[][] grid, int r, int c, bool[,] visited, int color, int[,] colors)
    {
        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || visited[r, c] || grid[r][c] == 1)
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