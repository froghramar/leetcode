public class Solution {
    public int FindKthPositive(int[] arr, int k)
    {
        var lastFound = 0;
        foreach (var num in arr)
        {
            var gap = num - lastFound - 1;
            if (k <= gap)
            {
                return lastFound + k;
            }

            k -= gap;
            lastFound = num;
        }

        return lastFound + k;
    }
}