public class Solution {
    public bool IsMonotonic(int[] nums)
    {
        var dir1 = new HashSet<bool>();
        var dir2 = new HashSet<bool>();
        
        for (var i = 1; i < nums.Length; i++)
        {
            dir1.Add(nums[i] >= nums[i - 1]);
            dir2.Add(nums[i] <= nums[i - 1]);
        }
        
        return dir1.Count < 2 || dir2.Count < 2;
    }
}