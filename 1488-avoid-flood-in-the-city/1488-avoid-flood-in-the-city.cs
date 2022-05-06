public class Solution
{
    public int[] AvoidFlood(int[] rains)
    {
        var n = rains.Length;
        var map = new Dictionary<int, int>();
        var zeroes = new List<int>();

        var ans = new int[n];

        for (var i = 0; i < n; i++)
        {
            if (rains[i] == 0)
            {
                zeroes.Add(i);
                ans[i] = 1;
            }
            else
            {
                var lastIdx = map.GetValueOrDefault(rains[i], -1);

                if (lastIdx == -1)
                {
                    map[rains[i]] = i;
                    ans[i] = -1;
                }
                else
                {
                    var dryIdx = BinarySearch(zeroes, lastIdx);
                    if (dryIdx == null)
                    {
                        return Array.Empty<int>();
                    }

                    ans[dryIdx.Value] = rains[i];
                    zeroes.Remove(dryIdx.Value);
                    map[rains[i]] = i;
                    ans[i] = -1;
                }
            }
        }

        return ans;
    }

    private static int? BinarySearch(List<int> zeroes, int k)
    {
        if (zeroes.Count == 0)
        {
            return null;
        }

        int si = 0, ei = zeroes.Count;
        while (si < ei)
        {
            var mid = (si + ei) / 2;
            if (zeroes[mid] > k)
            {
                ei = mid;
            }
            else
            {
                si = mid + 1;
            }
        }

        if (si == zeroes.Count)
        {
            return null;
        }

        if (si == 0 && zeroes[si] <= k)
        {
            return null;
        }

        return zeroes[si];
    }
}