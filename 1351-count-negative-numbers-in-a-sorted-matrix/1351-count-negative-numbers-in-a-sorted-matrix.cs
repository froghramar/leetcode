public class Solution {
    public int CountNegatives(int[][] grid)
    {
        return grid.Sum(row => row.Count(v => v < 0));
    }
}