public class Solution {
    public int RemoveCoveredIntervals(int[][] intervals)
    {
        var isCovered = new bool[intervals.Length];
        for (var i = 0; i < intervals.Length; i++)
        {
            for (var j = 0; j < intervals.Length; j++)
            {
                if (i != j && intervals[i][0] <= intervals[j][0] && intervals[i][1] >= intervals[j][1])
                {
                    isCovered[j] = true;
                }
            }
        }

        return isCovered.Sum(c => c ? 0 : 1);
    }
}