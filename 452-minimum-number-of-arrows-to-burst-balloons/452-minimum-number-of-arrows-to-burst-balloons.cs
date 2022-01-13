public class Solution {
    public int FindMinArrowShots(int[][] points)
    {
        Array.Sort(points, (p1, p2) =>
        {
            if (p1[1] > p2[1])
            {
                return 1;
            }

            if (p1[1] < p2[1])
            {
                return -1;
            }

            return 0;
        });
        
        var result = 1;
        var end = points[0][1];

        foreach (var point in points)
        {
            if (point[0] > end)
            {
                result++;
                end = point[1];
            }
        }

        return result;
    }
}