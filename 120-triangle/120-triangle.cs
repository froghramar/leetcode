public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        for (var i = triangle.Count - 2; i >= 0; i--)
        {
            for (var j = 0; j < triangle[i].Count; j++)
            {
                triangle[i][j] = triangle[i][j] + Math.Min(triangle[i + 1][j], triangle[i + 1][j + 1]);
            }
        }
        return triangle[0][0];
    }
}