public class Solution {
    public int[] SearchRange(int[] nums, int target)
    {
        if (nums.Length == 0)
        {
            return new int[] {-1, -1};
        }
        
        var start = FindFirst(nums, target);

        if (start == -1)
        {
            return new int[] {-1, -1};
        }
        
        if (nums[start] > target)
        {
            return new int[] { -1, -1 };
        }

        var end = FindFirst(nums, target + 1);
        if (end == -1)
        {
            end = nums.Length;
        }

        return new int[] {start, end - 1 };
    }

    int FindFirst(int[] nums, int target)
    {
        int l = 0, r = nums.Length - 1;
        while (l < r)
        {
            var mid = (l + r) / 2;
            if (nums[mid] >= target)
            {
                r = mid;
            }
            else
            {
                l = mid + 1;
            }
        }

        if (nums[l] >= target)
        {
            return l;
        }

        return -1;
    }
}