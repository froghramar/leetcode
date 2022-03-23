public class Solution {
    public int[][] KClosest(int[][] points, int k)
    {
        var pointList = points.ToList();
        pointList.Sort((p1, p2) =>
        {
            var distance1 = p1[0] * p1[0] + p1[1] * p1[1];
            var distance2 = p2[0] * p2[0] + p2[1] * p2[1];
            return distance1 - distance2;
        });

        return pointList.Take(k).ToArray();
    }
}