public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        var count = new int[51];
        foreach (var candidate in candidates)
        {
            count[candidate]++;
        }
        
        var result = new List<IList<int>>();
        Traverse(count, 1, new List<int>(), target, result);

        return result;
    }

    private void Traverse(int[] count, int i, IList<int> current, int remaining, IList<IList<int>> result)
    {
        if (remaining == 0)
        {
            result.Add(current);
            return;
        }

        if (i == 51)
        {
            return;
        }

        var next = current;
        var j = 0;

        while (remaining >= 0 && j <= count[i])
        {
            Traverse(count, i + 1, next.ToList(), remaining, result);
            remaining -= i;
            next.Add(i);
            j++;
        }
    }
}