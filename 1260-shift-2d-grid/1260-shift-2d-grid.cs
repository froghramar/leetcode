public class Solution {
    public IList<IList<int>> ShiftGrid(int[][] grid, int k)
    {
        var res = new int[grid.Length][];
        var cnt = grid.Length * grid[0].Length;

        for (var i = 0; i < grid.Length; i++)
        {
            res[i] = new int[grid[i].Length];
        }

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                var l = (i * grid[0].Length + j + k) % cnt;
                var (idx, idy) = (l / grid[0].Length, l % grid[0].Length);
                res[idx][idy] = grid[i][j];
            }
        }
        return res;
    }
}