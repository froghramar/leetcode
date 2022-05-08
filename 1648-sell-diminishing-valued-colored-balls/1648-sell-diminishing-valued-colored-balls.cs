public class Solution {
    public int MaxProfit(int[] inventory, int orders)
    {
        int l = 0, r = inventory.Max();
        while (l < r)
        {
            var mid = (l + r) / 2;
            var total = GetTotal(mid);
            if (total <= orders)
            {
                r = mid;
            }
            else
            {
                l = mid + 1;
            }
        }

        const int MOD = (int) 1e9 + 7;
        var remaining = orders - GetTotal(l);
        var result = (remaining * l) % MOD;
        foreach (var num in inventory)
        {
            var add = num > l ? GetSequenceSum(l + 1, num) : 0L;
            result = (result + add) % MOD;
        }

        return (int)result;
        
        long GetTotal(int m)
        {
            return inventory.Sum(num => Math.Max(0L, num - m));
        }
    }

    private long GetSequenceSum(int start, int end)
    {
        return GetSequenceSum(end) - GetSequenceSum(start - 1);
    }

    private long GetSequenceSum(int n)
    {
        return (long)n * (n + 1) / 2;
    }
}