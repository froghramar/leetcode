public class Solution {
    public void MoveZeroes(int[] nums)
    {
        var k = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                nums[k++] = nums[i];
            }
        }

        while (k < nums.Length)
        {
            nums[k++] = 0;
        }
    }
}