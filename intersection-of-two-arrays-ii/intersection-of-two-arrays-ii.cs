public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        int[] count1 = new int[1001], count2 = new int[1001];
        var result = new List<int>();

        foreach (var num in nums1)
        {
            count1[num]++;
        }
        
        foreach (var num in nums2)
        {
            count2[num]++;
        }
        
        for (var index = 0; index <= 1000; index++)
        {
            var count = Math.Min(count1[index], count2[index]);
            while (count > 0)
            {
                result.Add(index);
                count--;
            }
        }

        return result.ToArray();
    }
}