public class Solution {
    public int Search(int[] nums, int target)
    {
        var k = FindPivot(nums);
        return BinarySearch(nums, target, k);
    }

    private int BinarySearch(int[] nums, int target, int k)
    {
        int l = 0, r = nums.Length - 1;

        while (l < r)
        {
            var m = (l + r) / 2;
            var val = Get(m);
            
            if (target <= val)
            {
                r = m;
            }
            else
            {
                l = m + 1;
            }
        }

        if (Get(l) == target)
        {
            return (l - k + nums.Length) % nums.Length;
        }

        return -1;
        
        int Get(int i)
        {
            return nums[(i - k + nums.Length) % nums.Length];
        }
    }

    private int FindPivot(int[] nums)
    {
        if (nums[^1] > nums[0])
        {
            return 0;
        }
        
        int l = 0, r = nums.Length - 1;
        while (l < r)
        {
            var m = (l + r) / 2;
            if (nums[m] < nums[0])
            {
                r = m;
            }
            else
            {
                l = m + 1;
            }
        }

        return nums.Length - l;
    }
}