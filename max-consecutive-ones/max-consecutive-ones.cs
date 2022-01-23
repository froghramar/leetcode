public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int result = 0, count = 0;
        foreach (var num in nums)
        {
            if (num == 0)
            {
                count = 0;
            }
            else
            {
                count++;
                result = Math.Max(result, count);
            }
        }

        return result;
    }
}