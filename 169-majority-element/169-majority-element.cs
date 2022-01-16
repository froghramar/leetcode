public class Solution {
    public int MajorityElement(int[] nums)
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

        int maxKey = 0, maxValue = 0;
        foreach (var (key, value) in count)
        {
            if (value > maxValue)
            {
                maxKey = key;
                maxValue = value;
            }
        }

        return maxKey;
    }
}