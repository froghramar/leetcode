public class Solution {
    public int ThreeSumClosest(int[] nums, int target)
    {
        const int range = 1000;
        var sumCount = new int[4 * range + 1];

        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                AddToCount(i, j, 1);
            }
        }

        var closest = 1_000_000;
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = 0; j < nums.Length; j++)
            {
                if (i != j)
                {
                    AddToCount(i, j, -1);
                }
            }

            for (var j = 0; j < sumCount.Length; j++)
            {
                if (sumCount[j] == 0)
                {
                    continue;
                }

                var sum = nums[i] + j - 2 * range;
                if (Math.Abs(sum - target) < Math.Abs(closest - target))
                {
                    closest = sum;
                }
            }
            
            for (var j = 0; j < nums.Length; j++)
            {
                if (i != j)
                {
                    AddToCount(i, j, 1);
                }
            }
        }

        void AddToCount(int i, int j, int toAdd)
        {
            sumCount[nums[i] + nums[j] + 2 * range] += toAdd;
        }

        return closest;
    }
}