public class Solution {
    public int MaxDistance(int[] nums1, int[] nums2)
    {
        var res = 0;
        for (var i = 0; i < nums1.Length; i++)
        {
            int l = i, r = nums2.Length - 1;
            while (l < r)
            {
                var m = l + (r - l + 1) / 2;
                if (nums2[m] >= nums1[i])
                {
                    l = m;
                }
                else
                {
                    r = m - 1;
                }
            }

            if (l < nums2.Length && nums2[l] >= nums1[i])
            {
                res = Math.Max(res, l - i);
            }
        }

        return res;
    }
}