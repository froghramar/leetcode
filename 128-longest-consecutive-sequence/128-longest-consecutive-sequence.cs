public class Solution {
    public int LongestConsecutive(int[] nums)
    {
        var set = new HashSet<int>(nums);
        var result = 0;
        foreach (var num in nums)
        {
            if (set.Contains(num - 1))
            {
                continue;
            }
            
            var current = num + 1;
            while (set.Contains(current))
            {
                current++;
            }

            result = Math.Max(result, current - num);
        }

        return result;
    }
}