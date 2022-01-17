class Solution
{
    public int MaxSubarraySumCircular(int[] nums)
    {
        var n = nums.Length;
        var p = 2 * n;
        var prefixSum = new int[p + 1];
        for (var i = 0; i < p; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + nums[i % n];
        }

        var result = nums[0];
        var list = new List<int> { 0 };
        var currentPos = 0;

        for (var j = 1; j <= p; j++)
        {
            if (list[currentPos] < j - n)
            {
                currentPos++;
            }

            result = Math.Max(result, prefixSum[j] - prefixSum[list[currentPos]]);

            while (list.Count > currentPos && prefixSum[j] <= prefixSum[list[^1]])
            {
                list.RemoveAt(list.Count - 1);
            }

            list.Add(j);
        }

        return result;
    }
}