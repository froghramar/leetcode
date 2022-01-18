public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var nums1Copy = new int[m];
        Array.Copy(nums1, nums1Copy, m);

        int nums1Index = 0, nums2Index = 0, rIndex = 0;
        while (true)
        {
            if (nums1Index == m)
            {
                if (nums2Index == n)
                {
                    break;
                }

                nums1[rIndex++] = nums2[nums2Index++];
            }
            else
            {
                if (nums2Index == n)
                {
                    nums1[rIndex++] = nums1Copy[nums1Index++];
                }
                else
                {
                    if (nums1Copy[nums1Index] <= nums2[nums2Index])
                    {
                        nums1[rIndex++] = nums1Copy[nums1Index++];
                    }
                    else
                    {
                        nums1[rIndex++] = nums2[nums2Index++];
                    }
                }
            }
        }
    }
}