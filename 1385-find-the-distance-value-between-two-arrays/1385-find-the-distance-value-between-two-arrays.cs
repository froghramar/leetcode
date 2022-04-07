public class Solution {
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
    {
        return arr1.Count(v1 => arr2.All(v2 => Math.Abs(v1 - v2) > d));
    }
}