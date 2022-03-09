using System.Runtime.Intrinsics.X86;

public class Solution {
    public int[] SortByBits(int[] arr)
    {
        var res = new int[arr.Length];
        Array.Copy(arr, 0, res, 0, arr.Length);
        Array.Sort(res, (a, b) =>
        {
            var popCountA = (int) Popcnt.PopCount((uint) a);
            var popCountB = (int) Popcnt.PopCount((uint) b);

            if (popCountA == popCountB)
            {
                return a - b;
            }

            return popCountA - popCountB;
        });
        return res;
    }
}