using System.Collections.Generic;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var map = new Dictionary<int, int>();

        for (var index = 0; index < nums.Length; index++)
        {
            var value = nums[index];

            if (map.ContainsKey(target - value))
            {
                return new[] { map[target - value], index };
            }

            map[value] = index;
        }

        return null;
    }
}