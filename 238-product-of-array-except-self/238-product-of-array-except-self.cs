public class Solution {
    public int[] ProductExceptSelf(int[] nums)
    {
        var prefixProduct = 1;
        var suffixProduct = new int[nums.Length];
        var result = new int[nums.Length];

        suffixProduct[nums.Length - 1] = nums[^1];
        
        for (var i = nums.Length - 2; i >= 0; i--)
        {
            suffixProduct[i] = suffixProduct[i + 1] * nums[i];
        }

        for (var i = 0; i < nums.Length; i++)
        {
            result[i] = prefixProduct * (i < nums.Length - 1 ? suffixProduct[i + 1] : 1);
            prefixProduct = prefixProduct * nums[i];
        }

        return result;
    }
}