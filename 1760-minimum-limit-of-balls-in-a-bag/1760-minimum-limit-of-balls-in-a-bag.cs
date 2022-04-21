public class Solution {
    public int MinimumSize(int[] nums, int maxOperations)
    {
        int l = 1, r = nums.Max();
        while (l < r)
        {
            var m = (l + r) / 2;
            var operations = nums.Sum(num => (int) Math.Ceiling(num / (double) m) - 1);
            if (operations > maxOperations)
            {
                l = m + 1;
            }
            else
            {
                r = m;
            }
        }
        return l;
    }
}