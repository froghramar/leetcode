public class Solution {
    public int LargestPerimeter(int[] nums)
    {
        Array.Sort(nums);
        var result = 0;
        for (var i = 2; i < nums.Length; i++)
        {
            if (nums[i - 2] + nums[i - 1] > nums[i])
            {
                result = Math.Max(result, nums[i - 2] + nums[i - 1] + nums[i]);
            }
        }

        return result;
    }
}