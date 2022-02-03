public class Solution {
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
    {
        var dictionary = new Dictionary<int, int>();

        foreach (var num1 in nums1)
        {
            foreach (var num2 in nums2)
            {
                var sum = num1 + num2;
                if (dictionary.ContainsKey(sum))
                {
                    dictionary[sum]++;
                }
                else
                {
                    dictionary.Add(sum, 1);
                }
            }
        }

        var result = 0;

        foreach (var num3 in nums3)
        {
            foreach (var num4 in nums4)
            {
                var sum = -(num3 + num4);
                if (dictionary.ContainsKey(sum))
                {
                    result += dictionary[sum];
                }
            }
        }
        
        return result;
    }
}