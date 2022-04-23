public class Solution {
    public int SmallestDivisor(int[] nums, int threshold)
    {
        int l = 1, r = nums.Max();
        while (l < r)
        {
            var m = (l + r) / 2;
            var sum = nums.Sum(num => (int) Math.Ceiling(num / (double)m));
            if (sum <= threshold)
            {
                r = m;
            }
            else
            {
                l = m + 1;
            }
        }

        return l;
    }
}