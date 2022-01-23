public class Solution {
    public int RemoveElement(int[] nums, int val)
    {
        var k = nums.Length;

        for (var i = 0; i < k; i++)
        {
            while (nums[i] == val && i < k)
            {
                k--;
                for (var j = i; j < k; j++)
                {
                    nums[j] = nums[j + 1];
                }
            }
        }
        
        return k;
    }
}