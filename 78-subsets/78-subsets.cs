public class Solution {
    public IList<IList<int>> Subsets(int[] nums)
    {
        var result = new List<IList<int>>();
        Traverse(nums, 0, new List<int>(), result);
        return result;
    }

    private void Traverse(int[] nums, int i, IList<int> prev, IList<IList<int>> result)
    {
        if (i == nums.Length)
        {
            result.Add(prev);
            return;
        }

        var next = prev.ToList();
        next.Add(nums[i]);
        
        Traverse(nums, i + 1, prev.ToList(), result);
        Traverse(nums, i + 1, next, result);
    }
}