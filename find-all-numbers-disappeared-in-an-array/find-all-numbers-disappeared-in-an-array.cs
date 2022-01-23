public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        for (var i = 0; i < nums.Length; i++)
        {
            Reposition(nums, nums[i] - 1);
        }

        var result = new List<int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != i + 1)
            {
                result.Add(i + 1);
            }
        }

        return result;
    }

    private static void Reposition(int[] nums, int i)
    {
        if (nums[i] == i + 1)
        {
            return;
        }

        var x = nums[i] - 1;
        nums[i] = i + 1;
        Reposition(nums, x);
    }
}