public class Solution
{
    public int MinAbsoluteSumDiff(int[] nums1, int[] nums2)
    {
        var numsSorted = new int[nums1.Length];
        Array.Copy(nums1, 0, numsSorted, 0, nums1.Length);
        Array.Sort(numsSorted);
        
        int diffMinimize = 0, diffIndex = 0;
        for (var i = 0; i < nums1.Length; i++)
        {
            var prev = GetPrev(numsSorted, nums2[i]);
            var next = GetNext(numsSorted, nums2[i]);

            var currentDiff = Math.Abs(nums1[i] - nums2[i]);
            var prevDiffMinimize = currentDiff - Math.Abs(nums2[i] - prev);
            if (prevDiffMinimize > diffMinimize)
            {
                diffMinimize = prevDiffMinimize;
                diffIndex = i;
            }
            
            var nextDiffMinimize = currentDiff - Math.Abs(nums2[i] - next);
            if (nextDiffMinimize > diffMinimize)
            {
                diffMinimize = nextDiffMinimize;
                diffIndex = i;
            }
        }

        var total = 0;
        const int MOD = (int) 1e9 + 7;
        for (var i = 0; i < nums1.Length; i++)
        {
            var currentDiff = Math.Abs(nums1[i] - nums2[i]);
            if (i == diffIndex)
            {
                currentDiff -= diffMinimize;
            }
            
            total = (total + currentDiff) % MOD;
        }

        return total;
    }

    private static int GetPrev(int[] nums, int k)
    {
        int l = 0, r = nums.Length - 1;
        while (l < r)
        {
            var m = (l + r + 1) / 2;
            if (nums[m] <= k)
            {
                l = m;
            }
            else
            {
                r = m - 1;
            }
        }
        return nums[l];
    }
    
    private static int GetNext(int[] nums, int k)
    {
        int l = 0, r = nums.Length - 1;
        while (l < r)
        {
            var m = (l + r) / 2;
            if (nums[m] >= k)
            {
                r = m;
            }
            else
            {
                l = m + 1;
            }
        }
        return nums[l];
    }
}