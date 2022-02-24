public class Solution {
    public bool Search(int[] nums, int target)
    {
        foreach (var num in nums)
        {
            if (num == target)
            {
                return true;
            }
        }
        return false;
    }
}