public class Solution {
    public int FindJudge(int n, int[][] trust)
    {
        var result = -1;
        int[] trustedByCount = new int[n + 1], trusts = new int[n + 1];
        
        foreach (var t in trust)
        {
            trustedByCount[t[1]]++;
            trusts[t[0]]++;
        }

        for (var p = 1; p <= n; p++)
        {
            if (trustedByCount[p] == n - 1 && trusts[p] == 0)
            {
                if (result == -1)
                {
                    result = p;
                }
                else
                {
                    return -1;
                }
            }
        }

        return result;
    }
}