public class Solution {
    public int HeightChecker(int[] heights)
    {
        var expected = new int[heights.Length];
        Array.Copy(heights, expected, heights.Length);
        Array.Sort(expected);

        return heights.Where((t, i) => t != expected[i]).Count();
    }
}