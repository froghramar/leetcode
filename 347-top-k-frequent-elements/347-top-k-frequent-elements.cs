public class Solution {
    public int[] TopKFrequent(int[] nums, int k)
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

        var list = count.ToList();
        list.Sort((v1, v2) => v2.Value - v1.Value);

        return list.Take(k).Select(v => v.Key).ToArray();
    }
}