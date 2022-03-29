public class Solution {
    public int FindDuplicate(int[] nums)
    {
        var exists = new bool[nums.Length];
        foreach (var num in nums)
        {
            if (exists[num])
            {
                return num;
            }

            exists[num] = true;
        }

        return -1;
    }
}