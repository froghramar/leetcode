public class Solution {
    public int MinSubArrayLen(int target, int[] nums)
    {
        int sum = 0, left = 0, result = int.MaxValue;

        for (var right = 0; right < nums.Length; right++)
        {
            sum += nums[right];

            while (left <= right && sum >= target)
            {
                result = Math.Min(result, right - left + 1);
                
                sum -= nums[left];
                left++;
            }
        }
        
        return result == int.MaxValue ? 0 : result;
    }
}