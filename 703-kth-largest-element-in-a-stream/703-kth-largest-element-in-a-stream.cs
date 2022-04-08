public class KthLargest {
    private readonly int _k;
    private int[] _count;

    private const int SHIFT = 10000;

    public KthLargest(int k, int[] nums)
    {
        _k = k;
        _count = new int[20005];

        foreach (var num in nums)
        {
            _count[num + SHIFT]++;
        }
    }
    
    public int Add(int val)
    {
        _count[val + SHIFT]++;

        var t = 0;
        for (var i = 2 * SHIFT; i >= 0; i--)
        {
            t += _count[i];

            if (t >= _k)
            {
                return i - SHIFT;
            }
        }

        return -1;
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */