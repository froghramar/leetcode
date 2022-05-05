public class Solution {
    public int[] FindPeakGrid(int[][] mat)
    {
        int m = mat.Length, n = mat[0].Length, l = 0, r = m - 1;
        while (l < r)
        {
            var mid = (l + r + 1) / 2;

            var leftIndex = Math.Max(l, mid - 1);
            var rightIndex = Math.Min(r, mid + 1);
            var leftMax = mat[leftIndex].Max();
            var midMax = mat[mid].Max();
            var rightMax = mat[rightIndex].Max();
            var allMax = Math.Max(midMax, Math.Max(leftMax, rightMax));

            if (allMax == midMax)
            {
                l = r = mid;
            }
            else if (allMax == leftMax)
            {
                r = leftIndex;
            }
            else
            {
                l = rightIndex;
            }
        }

        var maxValue = mat[l].Max();
        var maxIndex = mat[l].ToList().IndexOf(maxValue);
        return new[] {l, maxIndex};
    }
}