public class Solution {
    public int NumberOfArithmeticSlices(int[] nums)
    {
        if (nums.Length < 3)
        {
            return 0;
        }
        
        int l = 0, difference = nums[1] - nums[0], result = 0;
        for (var r = 2; r < nums.Length; r++)
        {
            var newDifference = nums[r] - nums[r - 1];
            if (newDifference == difference)
            {
                result += r - l - 1;
                continue;
            }

            difference = newDifference;
            l = r - 1;
        }

        return result;
    }
}