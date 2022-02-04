public class Solution {
    public int FindMaxLength(int[] nums)
    {
        var max = 100000;
        var first = new int[2 * max + 1];
        
        Array.Fill(first, -2);
        first[max] = -1;
        
        int current = 0, result = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            current += nums[i] == 1 ? 1 : -1;

            if (first[current + max] == -2)
            {
                first[current + max] = i;
            }
            else
            {
                result = Math.Max(result, i - first[current + max]);
            }
        }
        
        return result;
    }
}