public class Solution {
    public int HIndex(int[] citations) {
        Array.Sort(citations);

        int l = 0, r = citations.Length;
        while (l < r)
        {
            var m = (l + r + 1) / 2;
            var highCount = citations.Count(c => c >= m);

            if (highCount >= m)
            {
                l = m;
            }
            else
            {
                r = m - 1;
            }
        }

        return l;
    }
}