public class Solution {
    public int WaysToSplit(int[] nums)
    {
        var n = nums.Length;
        var prefixSum = new int[n];
        prefixSum[0] = nums[0];
        for (var i = 1; i < n; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + nums[i];
        }

        long result = 0;
        for (var left = 0; left < n - 1; left++)
        {
            var minMid = GetMinMid(left, prefixSum);

            if (minMid > n - 2 || prefixSum[minMid] - prefixSum[left] < prefixSum[left])
            {
                continue;
            }

            if (prefixSum[n - 1] - prefixSum[minMid] < prefixSum[minMid] - prefixSum[left])
            {
                continue;
            }

            var count = GetCount(left, minMid, prefixSum);
            result += count;
        }

        return (int)(result % 1000_000_007);
    }

    private static int GetMinMid(int left, int[] prefixSum)
    {
        int l = left + 1, n = prefixSum.Length, r = n - 1;
        while (l < r)
        {
            var m = (l + r) / 2;
            if (prefixSum[m] - prefixSum[left] >= prefixSum[left])
            {
                r = m;
            }
            else
            {
                l = m + 1;
            }
        }

        return l;
    }

    private static int GetCount(int left, int minMid, int[] prefixSum)
    {
        int l = minMid, n = prefixSum.Length, r = n - 2;
        while (l < r)
        {
            var m = (l + r + 1) / 2;
            if (prefixSum[m] - prefixSum[left] <= prefixSum[n - 1] - prefixSum[m])
            {
                l = m;
            }
            else
            {
                r = m - 1;
            }
        }

        return l - minMid + 1;
    }
}