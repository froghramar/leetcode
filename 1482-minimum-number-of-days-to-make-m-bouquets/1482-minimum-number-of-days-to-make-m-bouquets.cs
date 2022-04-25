public class Solution {
    public int MinDays(int[] bloomDay, int m, int k)
    {
        if (m * k > bloomDay.Length)
        {
            return -1;
        }
        
        int l = 1, r = bloomDay.Max();
        while (l < r)
        {
            var mid = (l + r) / 2;
            if (CanMakeBouquets(bloomDay, m, k, mid))
            {
                r = mid;
            }
            else
            {
                l = mid + 1;
            }
        }

        return l;
    }

    private bool CanMakeBouquets(int[] bloomDay, int m, int k, int d)
    {
        int bouquetCount = 0, bloomCount = 0;
        foreach (var day in bloomDay)
        {
            if (day > d)
            {
                bloomCount = 0;
                continue;
            }

            bloomCount++;
            if (bloomCount == k)
            {
                bloomCount = 0;
                bouquetCount++;
            }
        }

        return bouquetCount >= m;
    }
}