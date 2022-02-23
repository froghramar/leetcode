using System.Text;

public class Solution {
    public string GetPermutation(int n, int k)
    {
        var fact = new int[n + 1];
        fact[0] = 1;
        for (var i = 1; i <= n; i++)
        {
            fact[i] = i * fact[i - 1];
        }

        var used = new bool[n + 1];

        var res = new StringBuilder();
        k--;
        for (var i = 1; i <= n; i++)
        {
            var f = fact[n - i];
            var cur = FindNthUnused(used, k / f + 1);
            res.Append((char)(cur + '0'));
            used[cur] = true;

            k %= f;
        }
        return res.ToString();
    }

    private static int FindNthUnused(bool[] used, int n)
    {
        var cur = 0;
        while (n > 0)
        {
            cur++;
            if (used[cur] is false)
            {
                n--;
            }
        }

        return cur;
    }
}