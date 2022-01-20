public class Solution {
    public int MinEatingSpeed(int[] piles, int h)
    {
        int l = 1, r = 1000_000_000;
        while (l < r)
        {
            var mid = (l + r) / 2;
            if (CanFinishEating(piles, h, mid))
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

    private bool CanFinishEating(int[] piles, int h, int k)
    {
        var hoursNeeded = 0;
        foreach (var pile in piles)
        {
            hoursNeeded += (pile + k - 1) / k;
        }

        return hoursNeeded <= h;
    }
}