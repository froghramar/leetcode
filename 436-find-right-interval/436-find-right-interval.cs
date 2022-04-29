public class Solution {
    public int[] FindRightInterval(int[][] intervals)
    {
        var starts = new KeyValuePair<int, int>[intervals.Length];
        for (var i = 0; i < intervals.Length; i++)
        {
            starts[i] = new KeyValuePair<int, int>(i, intervals[i][0]);
        }
        
        Array.Sort(starts, (s1, s2) => s1.Value.CompareTo(s2.Value));
        var result = new int[intervals.Length];
        for (var i = 0; i < intervals.Length; i++)
        {
            int l = 0, r = intervals.Length - 1;
            while (l < r)
            {
                var m = (l + r) / 2;
                if (starts[m].Value >= intervals[i][1])
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }

            if (starts[l].Value >= intervals[i][1])
            {
                result[i] = starts[l].Key;
            }
            else
            {
                result[i] = -1;
            }
        }
        
        return result;
    }
}