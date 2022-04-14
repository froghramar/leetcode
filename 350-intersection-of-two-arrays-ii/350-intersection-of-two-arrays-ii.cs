public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        const int LIMIT = 1001;
        var count1 = GetCounts(nums1, LIMIT);
        var count2 = GetCounts(nums2, LIMIT);

        var res = new List<int>();
        for (var i = 0; i < LIMIT; i++)
        {
            var cnt = Math.Min(count1[i], count2[i]);
            while (cnt > 0)
            {
                res.Add(i);
                cnt--;
            }
        }
        return res.ToArray();
    }

    private static int[] GetCounts(int[] nums, int limit)
    {
        var res = new int[limit];
        foreach (var num in nums)
        {
            res[num]++;
        }
        
        return res;
    }
}