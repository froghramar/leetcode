public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        var count = new int[21];
        foreach (var num in nums)
        {
            count[num + 10]++;
        }
        
        var result = new List<IList<int>>();
        Traverse(count, 0, new List<int>(), result);
        return result;
    }

    private void Traverse(int[] count, int i, IList<int> prev, IList<IList<int>> result)
    {
        if (i == 21)
        {
            result.Add(prev);
            return;
        }

        var current = prev.ToList();
        for (var j = 0; j <= count[i]; j++)
        {
            Traverse(count, i + 1, current.ToList(), result);
            
            current.Add(i - 10);
        }
    }
}