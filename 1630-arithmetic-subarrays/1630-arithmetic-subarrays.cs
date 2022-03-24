public class Solution {
    public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
    {
        var result = new List<bool>();
        for (var i = 0; i < l.Length; i++)
        {
            result.Add(IsArithmetic(GetSubArray(nums, l[i], r[i])));
        }
        
        return result;
    }

    private static int[] GetSubArray(int[] nums, int i, int j)
    {
        var res = new int[j - i + 1];
        Array.Copy(nums, i, res, 0, res.Length);
        return res;
    }

    private static bool IsArithmetic(int[] nums)
    {
        Array.Sort(nums);
        for (var i = 2; i < nums.Length; i++)
        {
            if (nums[i] - nums[i - 1] != nums[1] - nums[0])
            {
                return false;
            }
        }
        
        return true;
    }
}