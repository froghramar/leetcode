public class Solution {
    public int SpecialArray(int[] nums) {
        Array.Sort(nums);
        var last = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            var x = nums.Length - i;
            if (x > last && x <= nums[i])
            {
                return x;
            }

            last = nums[i];
        }

        return -1;
    }
}