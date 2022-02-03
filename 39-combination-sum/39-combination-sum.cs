public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var result = new List<IList<int>>();
        Traverse(candidates, 0, new List<int>(), target, result);

        return result;
    }

    private void Traverse(int[] candidates, int i, IList<int> current, int remaining, IList<IList<int>> result)
    {
        if (remaining == 0)
        {
            result.Add(current);
            return;
        }

        if (i == candidates.Length)
        {
            return;
        }

        var next = current;

        while (remaining >= 0)
        {
            Traverse(candidates, i + 1, next.ToList(), remaining, result);
            remaining -= candidates[i];
            next.Add(candidates[i]);
        }
    }
}