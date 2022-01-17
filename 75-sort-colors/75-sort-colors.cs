public class Solution {
    public void SortColors(int[] nums)
    {
        var count = new int[3];
        foreach (var t in nums)
        {
            count[t]++;
        }

        var p = 0;
        for (var i = 0; i < 3; i++)
        {
            while (count[i] > 0)
            {
                nums[p++] = i;
                count[i]--;
            }
        }
    }
}