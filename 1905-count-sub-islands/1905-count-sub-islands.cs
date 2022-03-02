public class Solution {
    public int CountSubIslands(int[][] grid1, int[][] grid2)
    {
        var color = 0;
        var colors = new int[grid2.Length, grid2[0].Length];
        var visited = new bool[grid2.Length, grid2[0].Length];

        for (var i = 0; i < grid2.Length; i++)
        {
            for (var j = 0; j < grid2[i].Length; j++)
            {
                if (grid2[i][j] == 1 && visited[i, j] is false)
                {
                    Traverse(i, j, grid2, color++, colors, visited);
                }
            }
        }

        var subIsland = new bool[color];
        Array.Fill(subIsland, true);

        for (var i = 0; i < grid2.Length; i++)
        {
            for (var j = 0; j < grid2[i].Length; j++)
            {
                if (grid2[i][j] == 1 && grid1[i][j] == 0)
                {
                    subIsland[colors[i, j]] = false;
                }
            }
        }
        
        return subIsland.Count(s => s);
    }

    private void Traverse(int i, int j, int[][] grid, int color, int[,] colors, bool[,] visited)
    {
        if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == 0 || visited[i, j])
        {
            return;
        }

        colors[i, j] = color;
        visited[i, j] = true;
        
        Traverse(i, j - 1, grid, color, colors, visited);
        Traverse(i, j + 1, grid, color, colors, visited);
        Traverse(i - 1, j, grid, color, colors, visited);
        Traverse(i + 1, j, grid, color, colors, visited);
    }
}