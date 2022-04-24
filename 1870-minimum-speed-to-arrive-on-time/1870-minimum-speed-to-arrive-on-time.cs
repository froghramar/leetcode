public class Solution {
    public int MinSpeedOnTime(int[] dist, double hour) {
        int l = 1, r = (int)1e7;
        while (l < r)
        {
            var m = (l + r) / 2;
            if (CanTravel(dist, hour, m))
            {
                r = m;
            }
            else
            {
                l = m + 1;
            }
        }

        return CanTravel(dist, hour, l) ? l : -1;
    }

    private static bool CanTravel(int[] dist, double hour, int speed)
    {
        double total = 0;
        foreach (var d in dist)
        {
            total = Math.Ceiling(total) + d / (double) speed;
        }
        
        return total <= hour;
    }
}