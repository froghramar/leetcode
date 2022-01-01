public class Solution {
    public int MaxCoins(int[] nums)
    {
        var preCalc = new int[nums.Length][];
        for (var index = 0; index < nums.Length; index++)
        {
            preCalc[index] = new int[nums.Length];
        }
        
        for(var gap = 0; gap < preCalc.Length; gap++)
        {
            for(int startIndex = 0, endIndex = gap; endIndex < preCalc.Length; startIndex++, endIndex++)
            {
                var maxValue = int.MinValue;
                for(var index = startIndex; index <= endIndex; index++)
                {
                    var left = index == startIndex ? 0 : preCalc[startIndex][index - 1];
                    var right = index == endIndex ? 0 : preCalc[index + 1][endIndex];
                    var value = (startIndex == 0 ? 1 : nums[startIndex - 1]) * nums[index] * (endIndex == nums.Length - 1 ? 1 : nums[endIndex + 1]);
                    var total = left + right + value;
                    maxValue = Math.Max(maxValue, total);
                }
                preCalc[startIndex][endIndex] = maxValue;
            }
        }
        return preCalc[0][preCalc.Length - 1];
    }
}