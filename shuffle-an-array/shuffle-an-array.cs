public class Solution
{
    private int[] _original, _numbers;
    private Random _generator;
    public Solution(int[] nums)
    {
        _original = new int[nums.Length];
        _numbers = new int[nums.Length];
        _generator = new Random();
        Array.Copy(nums, _original, nums.Length);
        Array.Copy(nums, _numbers, nums.Length);
    }
    
    public int[] Reset() {
        Array.Copy(_original, _numbers, _original.Length);
        return _numbers;
    }
    
    public int[] Shuffle()
    {
        var n = _numbers.Length;
        while (n > 1)
        {
            var k = _generator.Next(n);
            (_numbers[n - 1], _numbers[k]) = (_numbers[k], _numbers[n - 1]);
            n--;
        }

        return _numbers;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int[] param_1 = obj.Reset();
 * int[] param_2 = obj.Shuffle();
 */