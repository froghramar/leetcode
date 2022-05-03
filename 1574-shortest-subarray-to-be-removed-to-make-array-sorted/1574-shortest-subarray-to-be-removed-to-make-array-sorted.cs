public class Solution
{
    public int FindLengthOfShortestSubarray(int[] arr)
    {
        var n = arr.Length;
        if (n <= 1)
        {
            return 0;
        }

        var prefix = 0;
        for (var i = 0; i < n - 1 && arr[i] <= arr[i + 1]; i++)
        {
            prefix++;
        }

        if (prefix == n - 1)
        {
            return 0;
        }

        var suffix = n - 1;
        for (var j = n - 2; j >= 0 && arr[j] <= arr[j + 1]; j--)
        {
            suffix--;
        }

        int l = 0, r = suffix, res = Math.Min(n - prefix - 1, suffix);
        while (l <= prefix && r <= n - 1)
        {
            if (arr[l] <= arr[r])
            {
                res = Math.Min(res, r - l - 1);
                l++;
            }
            else
            {
                r++;
            }
        }
        
        return res;
    }
}