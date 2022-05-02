public class Solution
{
    private const int MOD = (int) 1e9 + 7;

    public int RangeSum(int[] nums, int n, int left, int right)
    {
        var sums = new List<int>();

        for (var i = 0; i < n; i++)
        {
            var sum = 0;
            for (var j = i; j < n; j++)
            {
                sum = (sum + nums[j]) % MOD;
                sums.Add(sum);
            }
        }
        
        sums.Sort();

        var result = 0;
        for (var i = left - 1; i < right; i++)
        {
            result = (result + sums[i]) % MOD;
        }

        return result;
    }
}