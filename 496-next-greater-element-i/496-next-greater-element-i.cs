public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        var pos = new int[10005];
        for (var i = 0; i < nums2.Length; i++)
        {
            pos[nums2[i]] = i;
        }
        
        var res = new int[nums1.Length];
        for (var i = 0; i < nums1.Length; i++)
        {
            res[i] = -1;
            for (var j = pos[nums1[i]] + 1; j < nums2.Length; j++)
            {
                if (nums2[j] > nums1[i])
                {
                    res[i] = nums2[j];
                    break;
                }
            }
        }
        
        return res;
    }
}