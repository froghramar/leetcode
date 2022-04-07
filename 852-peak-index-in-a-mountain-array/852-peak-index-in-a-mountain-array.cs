public class Solution {
    public int PeakIndexInMountainArray(int[] arr)
    {
        int l = 1, r = arr.Length - 2;
        while (true)
        {
            var m = l + (r - l) / 2;
            if (arr[m] > arr[m - 1] && arr[m] > arr[m + 1])
            {
                return m;
            }

            if (arr[m] > arr[m - 1])
            {
                l = m + 1;
            }
            else
            {
                r = m - 1;
            }
        }
    }
}