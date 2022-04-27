public class Solution {
    public int SingleNonDuplicate(int[] nums)
    {
        int l = 0, r = nums.Length - 1;
        while (l < r)
        {
            var m = (l + r) / 2;
            if (m % 2 == 0 &&m != nums.Length - 1 && nums[m] == nums[m + 1])
            {
                l = m + 1;
            }
            else if (m % 2 == 1 && nums[m] == nums[m - 1])
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