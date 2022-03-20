public class Solution {
    public IList<int> AddToArrayForm(int[] num, int k)
    {
        var result = new List<int>();
        for (var i = num.Length - 1; i >= 0; i--)
        {
            result.Add((num[i] + k) % 10);
            k = (num[i] + k) / 10;
        }

        while (k > 0)
        {
            result.Add(k % 10);
            k /= 10;
        }

        result.Reverse();
        return result;
    }
}