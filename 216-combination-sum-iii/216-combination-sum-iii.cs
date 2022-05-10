public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        var res = new List<IList<int>>();
        var taken = new bool[10];
        taken[0] = true;
        Traverse(taken, k, n, res);
        return res;
    }

    private static void Traverse(bool[] taken, int k, int n, IList<IList<int>> res)
    {
        int sum = 0, takenCount = 0;
        for (var i = 1; i < 10; i++)
        {
            if (taken[i])
            {
                sum += i;
                takenCount++;
            }
        }

        if (sum == n && takenCount == k)
        {
            var ans = new List<int>();
            for (var i = 1; i < 10; i++)
            {
                if (taken[i])
                {
                    ans.Add(i);
                }
            }
            res.Add(ans);
        }

        if (sum >= n || takenCount >= k)
        {
            return;
        }

        var last = taken.ToList().LastIndexOf(true);
        for (var i = last + 1; i < 10; i++)
        {
            if (taken[i])
            {
                continue;
            }
        
            taken[i] = true;
            Traverse(taken, k, n, res);
            taken[i] = false;
        }
    }
}