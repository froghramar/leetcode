public class Solution {
    public int MaxProduct(int[] nums)
    {
        int result = nums[0], pMin = nums[0], pMax = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] < 0)
            {
                (pMin, pMax) = (pMax, pMin);
            }

            pMax = Math.Max(nums[i], nums[i] * pMax);
            pMin = Math.Min(nums[i], nums[i] * pMin);

            result = Math.Max(result, pMax);
        }

        return result;
    }
}