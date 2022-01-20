public class Solution {
    public bool IncreasingTriplet(int[] nums)
    {
        var min = nums[0];
        var max = new int[nums.Length];
        max[nums.Length - 1] = nums[^1];
        
        for (var i = nums.Length - 2; i >= 0; i--)
        {
            max[i] = Math.Max(max[i + 1], nums[i]);
        }

        for (var i = 1; i < nums.Length - 1; i++)
        {
            if (nums[i] > min && nums[i] < max[i + 1])
            {
                return true;
            }

            min = Math.Min(min, nums[i]);
        }

        return false;
    }
}