public class Solution {
    public int EraseOverlapIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (interval1, interval2) => interval1[1] - interval2[1]);

        var lastEnd = int.MinValue;
        var result = 0;

        foreach (var interval in intervals)
        {
            if (interval[0] >= lastEnd)
            {
                lastEnd = interval[1];
            }
            else
            {
                result++;
            }
        }

        return result;
    }
}