public class Solution
{
    private int[] _prefixSum;
    private Random _random;

    public Solution(int[] w)
    {
        _prefixSum = new int[w.Length];
        _prefixSum[0] = w[0];
        for (var i = 1; i < w.Length; i++)
        {
            _prefixSum[i] = _prefixSum[i - 1] + w[i];
        }

        _random = new();
    }
    
    public int PickIndex()
    {
        var rand = _random.NextDouble() * _prefixSum[^1];
        int l = 0, r = _prefixSum.Length - 1;
        while (l < r)
        {
            var m = (l + r) / 2;
            if (_prefixSum[m] >= rand)
            {
                r = m;
            }
            else
            {
                l = m + 1;
            }
        }

        return l;
    }
}