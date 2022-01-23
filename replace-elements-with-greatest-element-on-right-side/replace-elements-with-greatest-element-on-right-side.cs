public class Solution {
    public int[] ReplaceElements(int[] arr)
    {
        var max = -1;
        for (var i = arr.Length - 1; i >= 0; i--)
        {
            var current = arr[i];
            arr[i] = max;
            max = Math.Max(max, current);
        }
        return arr;
    }
}