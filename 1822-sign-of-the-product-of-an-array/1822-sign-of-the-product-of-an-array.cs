public class Solution {
    public int ArraySign(int[] nums)
    {
        var result = 1;
        foreach (var num in nums)
        {
            result *= num switch
            {
                < 0 => -1,
                > 0 => 1,
                0 => 0,
            };
        }

        return result;
    }
}