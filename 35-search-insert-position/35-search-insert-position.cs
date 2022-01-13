public class Solution {
    public int SearchInsert(int[] nums, int target) {
        int left = 0, right = nums.Length - 1;

        while (left <= right)
        {
            var mid = (left + right) / 2;

            if (target > nums[mid])
            {
                left = mid + 1;
            }
            else if (target < nums[mid])
            {
                right = mid - 1;
            }
            else
            {
                return mid;
            }
        }

        return left;
    }
}
