public class Solution {
    public IList<IList<int>> Permute(int[] nums)
    {
        return PermuteInternal(nums, new List<int>());
    }
    
    private IList<IList<int>> PermuteInternal(int[] nums, IList<int> previous) {
        if (previous.Count == nums.Length)
        {
            return new List<IList<int>> {previous};
        }

        var result = new List<IList<int>>();

        foreach (var num in nums)
        {
            if (previous.Contains(num))
            {
                continue;
            }

            var newList = previous.ToList();
            newList.Add(num);
            
            result.AddRange(PermuteInternal(nums, newList));
        }

        return result;
    }
}