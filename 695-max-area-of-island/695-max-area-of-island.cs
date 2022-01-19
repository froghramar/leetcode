public class Solution {
    public int MaxAreaOfIsland(int[][] grid)
    {
        var visited = new bool[grid.Length, grid[0].Length];
        var color = 0;
        var area = new int[grid.Length * grid[0].Length];

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (!visited[i, j])
                {
                    Traverse(grid, i, j, visited, color++, area);
                }
            }
        }
        
        var result = 0;
        for (var i = 0; i < color; i++)
        {
            result = Math.Max(result, area[i]);
        }

        return result;
    }
    
    private void Traverse(int[][] grid, int r, int c, bool[,] visited, int color, int[] area)
    {
        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || visited[r, c] || grid[r][c] == 0)
        {
            return;
        }

        visited[r, c] = true;
        area[color]++;

        Traverse(grid, r, c - 1, visited, color, area);
        Traverse(grid, r, c + 1, visited, color, area);
        Traverse(grid, r - 1, c, visited, color, area);
        Traverse(grid, r + 1, c, visited, color, area);
    }
}