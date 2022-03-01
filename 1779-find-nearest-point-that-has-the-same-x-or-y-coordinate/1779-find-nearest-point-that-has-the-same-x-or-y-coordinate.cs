public class Solution {
    public int NearestValidPoint(int x, int y, int[][] points)
    {
        int distance = int.MaxValue, res = -1;
        for (var i = 0; i < points.Length; i++)
        {
            if (points[i][0] != x && points[i][1] != y)
            {
                continue;
            }

            var d = Math.Abs(points[i][0] - x) + Math.Abs(points[i][1] - y);
            if (d < distance)
            {
                distance = d;
                res = i;
            }
        }
        return res;
    }
}