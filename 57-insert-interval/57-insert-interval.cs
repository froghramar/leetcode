public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var result = new List<int[]>();

        if (intervals.Length == 0)
        {
            result.Add(newInterval);
            return result.ToArray();
        }

        if (newInterval[1] < intervals[0][0])
        {
            result.Add(newInterval);
            result.AddRange(intervals);
            return result.ToArray();
        }

        if (newInterval[0] > intervals[^1][1])
        {
            result.AddRange(intervals);
            result.Add(newInterval);
            return result.ToArray();
        }
        
        var mergeStart = -1;
        bool anyCollision = false, taken = false;
        foreach (var interval in intervals)
        {
            var collision = Math.Max(interval[0], newInterval[0]) <= Math.Min(interval[1], newInterval[1]);
            if (collision is false)
            {
                if (mergeStart != -1)
                {
                    result.Add(new[] { mergeStart, newInterval[1] });
                    mergeStart = -1;
                }
                else if (anyCollision is false && taken == false && interval[0] > newInterval[1])
                {
                    result.Add(newInterval);
                    taken = true;
                }
                
                result.Add(interval);
                continue;
            }

            anyCollision = true;
            taken = true;

            if (mergeStart == -1)
            {
                if (newInterval[1] > interval[1])
                {
                    mergeStart = Math.Min(interval[0], newInterval[0]);
                }
                else
                {
                    result.Add(new[] { Math.Min(interval[0], newInterval[0]), interval[1] });
                }
            }
            else
            {
                if (newInterval[1] > interval[1])
                {
                    continue;
                }

                result.Add(new[] { mergeStart, interval[1] });
                mergeStart = -1;
            }
        }

        if (mergeStart != -1)
        {
            result.Add(new[] { mergeStart, newInterval[1] });
        }
        
        return result.ToArray();
    }
}