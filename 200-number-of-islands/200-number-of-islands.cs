public class Solution {
    public int NumIslands(char[][] grid)
    {
        var count = 0;
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                CountIslands(grid, i, j, ref count, true);
            }
        }

        return count;
    }

    private void CountIslands(char[][] grid, int i, int j, ref int count, bool startNew)
    {
        if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length || grid[i][j] == '0')
        {
            return;
        }

        grid[i][j] = '0';

        if (startNew)
        {
            count++;
        }
        
        CountIslands(grid, i, j - 1, ref count, false);
        CountIslands(grid, i, j + 1, ref count, false);
        CountIslands(grid, i - 1, j, ref count, false);
        CountIslands(grid, i + 1, j, ref count, false);
    }
}