public class Solution {
    public int MaxFrequency(int[] nums, int k) {
        Array.Sort(nums);
        
        var prefixSum = new long[nums.Length];
        prefixSum[0] = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + nums[i];
        }

        var res = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            var count = GetCount(i, nums[i], prefixSum, k);
            res = Math.Max(res, count);
        }
        return res;
    }

    private static int GetCount(int pos, int val, long[] prefixSum, int k)
    {
        int l = 0, r = pos;
        while (l < r)
        {
            var m = (l + r) / 2;
            var total = prefixSum[pos] - (m == 0 ? 0 : prefixSum[m - 1]);
            var len = pos - m + 1;
            var totalToMake = val * (long) len;
            if (totalToMake - total > k)
            {
                l = m + 1;
            }
            else
            {
                r = m;
            }
        }

        return pos - l + 1;
    }
}