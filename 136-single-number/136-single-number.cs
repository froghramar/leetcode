public class Solution {
    public int SingleNumber(int[] nums)
    {
        const int ranges = 30000;
        var count = new int[2 * ranges + 1];
        
        foreach (var num in nums)
        {
            count[num + ranges]++;
        }
        
        for (var i = 0; i < count.Length; i++)
        {
            if (count[i] == 1)
            {
                return i - ranges;
            }
        }

        return -1;
    }
}