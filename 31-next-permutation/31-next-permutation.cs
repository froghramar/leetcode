public class Solution {
    public void NextPermutation(int[] nums)
    {
        var pos = -1;
        for (var i = nums.Length - 2; i >= 0; i--)
        {
            if (nums[i] < nums[i + 1])
            {
                pos = i;
                break;
            }
        }

        if (pos == -1)
        {
            Array.Reverse(nums);
            return;
        }

        var nextBig = pos + 1;
        for (var i = pos + 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[pos] && nums[i] < nums[nextBig])
            {
                nextBig = i;
            }
        }

        (nums[pos], nums[nextBig]) = (nums[nextBig], nums[pos]);
        
        Array.Sort(nums, pos + 1, nums.Length - pos - 1);
    }
}
