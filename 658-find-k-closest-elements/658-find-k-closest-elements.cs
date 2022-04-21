public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        Array.Sort(arr, (p1, p2) =>
        {
            var diff = Math.Abs(x - p1) - Math.Abs(x - p2);
            return diff == 0 ? p1 - p2 : diff;
        });
        var result = arr.Take(k).ToList();
        result.Sort();
        return result;
    }
}