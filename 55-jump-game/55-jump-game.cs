public class Solution {
    public bool CanJump(int[] nums)
    {
        var reachableIndex = nums.Length - 1;
        for (var i = nums.Length - 2; i >= 0; i--)
        {
            if (nums[i] >= reachableIndex - i)
            {
                reachableIndex = i;
            }
        }

        return reachableIndex == 0;
    }
}