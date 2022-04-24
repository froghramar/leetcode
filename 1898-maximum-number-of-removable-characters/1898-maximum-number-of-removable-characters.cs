public class Solution {
    public int MaximumRemovals(string s, string p, int[] removable)
    {
        int l = 0, r = removable.Length;
        while (l < r)
        {
            var m = l + (r - l + 1) / 2;
            if (IsSubsequence(s, p, removable, m))
            {
                l = m;
            }
            else
            {
                r = m - 1;
            }
        }

        return l;
    }

    private static bool IsSubsequence(string s, string p, int[] removable, int k)
    {
        var marked = new bool[s.Length];
        for (var i = 0; i < k; i++)
        {
            marked[removable[i]] = true;
        }

        var pPos = 0;
        for (var i = 0; i < s.Length && pPos < p.Length; i++)
        {
            if (marked[i])
            {
                continue;
            }

            if (s[i] == p[pPos])
            {
                pPos++;
            }
        }
        
        return pPos == p.Length;
    }
}