public class Solution {
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
    {
        var subs = new List<int>[n];
        for (var i = 0; i < n; i++)
        {
            subs[i] = new List<int>();
        }
        
        for (var i = 0; i < manager.Length; i++)
        {
            if (i != headID)
            {
                subs[manager[i]].Add(i);
            }
        }

        return NumOfMinutesInternal(headID, subs, informTime);
    }

    private static int NumOfMinutesInternal(int manager, List<int>[] subs, int[] informTime)
    {
        if (subs.Length == 0)
        {
            return 0;
        }

        var maxInform = 0;
        foreach (var sub in subs[manager])
        {
            maxInform = Math.Max(maxInform, NumOfMinutesInternal(sub, subs, informTime));
        }

        return informTime[manager] + maxInform;
    }
}