public class Solution {
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
    {
        var n = difficulty.Length;
        var jobs = new Tuple<int, int>[n];
        for (var i = 0; i < n; i++)
        {
            jobs[i] = new Tuple<int, int>(profit[i], difficulty[i]);
        }
        
        Array.Sort(jobs, (job1, job2) =>
            job1.Item1 == job2.Item1 ? job1.Item2.CompareTo(job2.Item2) : job1.Item1.CompareTo(job2.Item1));

        var prev = jobs[^1];
        for (var i = jobs.Length - 2; i >= 0; i--)
        {
            if (jobs[i].Item2 > prev.Item2)
            {
                jobs[i] = null;
            }
            else
            {
                prev = jobs[i];
            }
        }

        jobs = jobs.Where(job => job is not null).ToArray();

        var totalProfit = 0;
        foreach (var w in worker)
        {
            int l = 0, r = jobs.Length - 1;
            while (l < r)
            {
                var m = (l + r + 1) / 2;
                if (jobs[m].Item2 <= w)
                {
                    l = m;
                }
                else
                {
                    r = m - 1;
                }
            }

            if (jobs[l].Item2 <= w)
            {
                totalProfit += jobs[l].Item1;
            }
        }

        return totalProfit;
    }
}