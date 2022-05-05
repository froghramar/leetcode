public class Solution
{
    public int NumSubseq(int[] nums, int target)
    {
        Array.Sort(nums);
        int count = 0, MOD = (int) 1e9 + 7;

        var pow = new int[nums.Length];
        pow[0] = 1;
        for (var k = 1; k < nums.Length; k++)
        {
            pow[k] = pow[k - 1] * 2 % MOD;
        }

        int i = 0, j = nums.Length - 1;
        while (i <= j)
        {
            var sum = nums[i] + nums[j];
            if (sum <= target)
            {
                count = (count + pow[j - i]) % MOD;
                i++;
            }
            else
            {
                j--;
            }
        }

        return count;
    }
}