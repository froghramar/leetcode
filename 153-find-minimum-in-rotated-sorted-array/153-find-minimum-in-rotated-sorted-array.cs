public class Solution {
    public int FindMin(int[] nums)
    {
        int l = 0, r = nums.Length - 1;

        if (nums[r] > nums[0])
        {
            return nums[0];
        }

        while (l < r)
        {
            var m = (l + r) / 2;
            if (nums[m] >= nums[0])
            {
                l = m + 1;
            }
            else
            {
                r = m;
            }
        }

        return nums[l];
    }
}