public class Solution {
    public IList<string> SummaryRanges(int[] nums)
    {
        var result = new List<string>();
        if (nums.Length == 0)
        {
            return result;
        }
        
        var start = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            var num = nums[i];
            if (num == nums[start] + i - start)
            {
                continue;
            }
            
            AddToResult(start, i - 1);

            start = i;
        }
        
        AddToResult(start, nums.Length - 1);

        void AddToResult(int l, int r)
        {
            if (l == r)
            {
                result.Add($"{nums[l]}");
            }
            else
            {
                result.Add($"{nums[l]}->{nums[r]}");
            }
        }
        
        return result;
    }
}