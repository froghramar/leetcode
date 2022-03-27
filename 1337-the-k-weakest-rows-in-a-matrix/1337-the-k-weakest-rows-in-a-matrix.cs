public class Solution {
    public int[] KWeakestRows(int[][] mat, int k)
    {
        return mat
            .Select((row, index) => new KeyValuePair<int, int>(index, row.Sum()))
            .OrderBy(row => row.Value)
            .Take(k)
            .Select(row => row.Key)
            .ToArray();
    }
}