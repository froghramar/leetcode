public class Solution {
    public int ChalkReplacer(int[] chalk, int k)
    {
        var n = chalk.Length;
        var cum = new long[n];
        cum[0] = chalk[0];
        for (var i = 1; i < n; i++)
        {
            cum[i] = cum[i - 1] + chalk[i];
        }

        k = (int) (k % cum[^1]);

        int l = 0, r = chalk.Length - 1;
        while (l < r)
        {
            var m = (l + r) / 2;
            if (cum[m] > k)
            {
                r = m;
            }
            else
            {
                l = m + 1;
            }
        }
        return l;
    }
}