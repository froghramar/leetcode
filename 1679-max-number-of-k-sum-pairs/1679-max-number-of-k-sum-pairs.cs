public class Solution {
    public int MaxOperations(int[] nums, int k)
    {
        var count = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (count.ContainsKey(num))
            {
                count[num]++;
            }
            else
            {
                count[num] = 1;
            }
        }

        var res = 0;
        foreach (var num in count.Keys)
        {
            if (count.ContainsKey(k - num))
            {
                res += Math.Min(count[num], count[k - num]);
            }
        }

        return res / 2;
    }
}