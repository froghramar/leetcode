public class Solution {
    public int FindUnsortedSubarray(int[] nums)
    {
        var n = nums.Length;
        var sorted = new int[n];
        Array.Copy(nums, sorted, n);
        Array.Sort(sorted);

        int l = 0, r = n - 1;
        while (l < n && nums[l] == sorted[l])
        {
            l++;
        }

        while (r > -1 && nums[r] == sorted[r])
        {
            r--;
        }

        return l >= r ? 0 : r - l + 1;
    }
}