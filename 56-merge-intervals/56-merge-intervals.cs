public class Solution {
    public int[][] Merge(int[][] intervals) {
        var results = new List<Tuple<int,int>>();

        var input = intervals.ToList();
        input.Sort((x1, x2) => x1[0] - x2[0]);

        int first = -1, last = -1;
        foreach (var interval in input)
        {
            if (first == -1)
            {
                first = interval[0];
                last = interval[1];
                continue;
            }

            if (interval[0] > last)
            {
                results.Add(new Tuple<int,int>( first, last ));
                first = interval[0];
                last = interval[1];
                continue;
            }

            last = Math.Max(last, interval[1]);
        }

        results.Add(new Tuple<int,int>( first, last ));

        return results.Select(r => new[] { r.Item1, r.Item2 }).ToArray();
    }
}