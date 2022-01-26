public class Solution {
    public int SingleNumber(int[] nums)
    {
        var result = 0;
        foreach (var num in nums)
        {
            result = result ^ num;
        }

        return result;
    }
}