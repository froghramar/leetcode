public class Solution {
    public int SplitArray(int[] nums, int m)
    {
        int l = nums.Max(), r = 1_000_000_000;
        while (l < r)
        {
            var mid = (l + r) / 2;

            if (Valid(nums, m, mid))
            {
                r = mid;
            }
            else
            {
                l = mid + 1;
            }
        }

        return l;
    }

    private static bool Valid(int[] nums, int m, int maxSum)
    {
        int current = 1, currentSum = 0;
        foreach (var num in nums)
        {
            currentSum += num;

            if (currentSum > maxSum)
            {
                currentSum = num;
                current++;
            }
        }

        return current <= m;
    }
}