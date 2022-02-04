public class Solution {
    public int MaxPoints(int[][] points)
    {
        var result = 1;

        for (var i = 0; i < points.Length; i++)
        {
            for (var j = i + 1; j < points.Length; j++)
            {
                var count = 0;
                for (var k = 0; k < points.Length; k++)
                {
                    if (IsInSameLine(i, j, k))
                    {
                        count++;
                    }
                }

                result = Math.Max(result, count);
            }
        }

        bool IsInSameLine(int i, int j, int k)
        {
            var slope1 = GetSlope(i, j);
            var slope2 = GetSlope(i, k);

            return slope1.Item1 * slope2.Item2 == slope1.Item2 * slope2.Item1;
        }

        (int, int) GetSlope(int i, int j)
        {
            return (points[j][1] - points[i][1], points[j][0] - points[i][0]);
        }
        
        return result;
    }
}