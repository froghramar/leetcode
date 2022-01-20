public class Solution
{
    public int SubarraySum(int[] nums, int k)
    {
        var sumToIndex = new Dictionary<int, int>();
        var sum = 0;
        var result = 0;
        foreach (var num in nums)
        {
            sum = sum + num;

            if (sum == k)
            {
                result++;
            }
            
            if (sumToIndex.ContainsKey(sum - k))
            {
                result = result + sumToIndex[sum - k];
            }

            if (sumToIndex.ContainsKey(sum))
            {
                sumToIndex[sum]++;
            }
            else
            {
                sumToIndex[sum] = 1;
            }
        }

        return result;
    }
}