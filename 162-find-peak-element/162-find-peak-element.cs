public class Solution {
    public int FindPeakElement(int[] nums)
    {
        int l = 0, r = nums.Length - 1;
        while (l < r)
        {
            var m = (l + r) / 2;

            if (nums[m] < nums[Math.Max(0, m - 1)])
            {
                r = m - 1;
            }
            else if (nums[m] < nums[Math.Min(m + 1, nums.Length - 1)])
            {
                l = m + 1;
            }
            else
            {
                return m;
            }
        }
        return l;
    }
}