public class Solution {
    public int SmallestRangeII(int[] nums, int k)
    {
        if(nums.Length == 1) return 0;
        Array.Sort(nums);
        
        var minLeft = nums[0] + k;
        var maxRight = nums[^1] - k;
        
        var res = nums[^1] - nums[0];
        
        for (var i = 0; i < nums.Length - 1; i++) {
            var minLocal = Math.Min(minLeft, nums[i + 1] - k); 
            var maxLocal = Math.Max(nums[i] + k, maxRight);
            
            res = Math.Min(res, maxLocal - minLocal);
        }
        
        return res;
    }
}