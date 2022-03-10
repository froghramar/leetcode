public class NumArray
{
    private int[] _cum;
    
    public NumArray(int[] nums)
    {
        _cum = new int[nums.Length];
        _cum[0] = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            _cum[i] = _cum[i - 1] + nums[i];
        }
    }
    
    public int SumRange(int left, int right) {
        if (left == 0)
        {
            return _cum[right];
        }

        return _cum[right] - _cum[left - 1];
    }
}