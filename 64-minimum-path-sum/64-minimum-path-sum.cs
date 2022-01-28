public class Solution {
    public int MinPathSum(int[][] grid)
    {
        for (var i = 1; i < grid.Length; i++)
        {
            grid[i][0] = grid[i - 1][0] + grid[i][0];
        }

        for (var i = 1; i < grid[0].Length; i++)
        {
            grid[0][i] = grid[0][i - 1] + grid[0][i];
        }

        for (var i = 1; i < grid.Length; i++)
        {
            for (var j = 1; j < grid[i].Length; j++)
            {
                grid[i][j] = grid[i][j] + Math.Min(grid[i][j - 1], grid[i - 1][j]);
            }
        }
        
        return grid[grid.Length - 1][grid[0].Length - 1];
    }
}