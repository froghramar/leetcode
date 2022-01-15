public class Solution {
    public void MoveZeroes(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] == 0 && nums[j] != 0)
                {
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                }
            }
        }
    }
}