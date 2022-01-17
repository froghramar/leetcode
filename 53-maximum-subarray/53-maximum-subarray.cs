public class Solution {
    public int MaxSubArray(int[] nums)
    {
        var endsWithPreCalc = new int[nums.Length];
        var startsWithPreCalc = new int[nums.Length];
        
        for (var index = 0; index < nums.Length; index++)
        {
            endsWithPreCalc[index] = int.MaxValue;
            startsWithPreCalc[index] = int.MaxValue;
        }
        
        var result = nums[0];
        for (var index = 0; index < nums.Length; index++)
        {
            result = Math.Max(result,
                MaxSubArrayEndsWith(nums, index, endsWithPreCalc)
                + MaxSubArrayStartsWith(nums, index, startsWithPreCalc)
                - nums[index]);
        }

        return result;
    }

    public int MaxSubArrayEndsWith(int[] nums, int endIndex, int[] endsWithPreCalc)
    {
        if (endsWithPreCalc[endIndex] != int.MaxValue)
        {
            return endsWithPreCalc[endIndex];
        }
        
        if (endIndex == 0)
        {
            return endsWithPreCalc[endIndex] = nums[endIndex];
        }

        return endsWithPreCalc[endIndex] = Math.Max(nums[endIndex], nums[endIndex] + MaxSubArrayEndsWith(nums, endIndex - 1, endsWithPreCalc));
    }
    
    public int MaxSubArrayStartsWith(int[] nums, int startIndex, int[] startsWithPreCalc)
    {
        if (startsWithPreCalc[startIndex] != int.MaxValue)
        {
            return startsWithPreCalc[startIndex];
        }
        
        if (startIndex == nums.Length - 1)
        {
            return startsWithPreCalc[startIndex] = nums[startIndex];
        }

        return startsWithPreCalc[startIndex] = Math.Max(nums[startIndex], nums[startIndex] + MaxSubArrayStartsWith(nums, startIndex + 1, startsWithPreCalc));
    }
}