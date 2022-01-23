public class Solution {
    public IList<IList<int>> Combine(int n, int k)
    {
        return CombineInternal(n, k, 1, new List<int>());
    }

    private IList<IList<int>> CombineInternal(int n, int k, int l, IList<int> previous)
    {
        if (previous.Count == k)
        {
            return new List<IList<int>>{ previous };
        }

        if (l > n)
        {
            return new List<IList<int>>();
        }
        
        var result = new List<IList<int>>();
        result.AddRange(CombineInternal(n, k, l + 1, previous.ToList()));
        
        previous.Add(l);
        result.AddRange(CombineInternal(n, k, l + 1, previous.ToList()));
        
        return result;
    }
}