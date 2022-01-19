public class Solution {
    public bool SearchMatrix(int[][] matrix, int target)
    {
        foreach (var arr in matrix)
        {
            var index = BinarySearch(arr, target);
            if (arr[index] == target)
            {
                return true;
            }
        }

        return false;
    }

    private int BinarySearch(int[] arr, int target)
    {
        int l = 0, r = arr.Length - 1;
        while (l < r)
        {
            var mid = (l + r + 1) / 2;
            if (target >= arr[mid])
            {
                l = mid;
            }
            else
            {
                r = mid - 1;
            }
        }

        return l;
    }
}