public class Solution {
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        int result = 0, product = 1, left = 0;

        for (var right = 0; right < nums.Length; right++)
        {
            product *= nums[right];

            while (left <= right && product >= k)
            {
                product /= nums[left];
                left++;
            }
            
            if (product < k)
            {
                result += right - left + 1;
            }
        }
        
        return result;
    }
}
