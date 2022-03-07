public class Solution {
    public int FindPairs(int[] nums, int k) {
        Array.Sort(nums);

        var set = new HashSet<int>();

        int result = 0, lastTake = int.MaxValue;
        foreach (var num in nums)
        {
            if (lastTake == num)
            {
                continue;
            }

            if (set.Contains(num - k))
            {
                result++;
                lastTake = num;
            }

            set.Add(num);
        }

        return result;
    }
}