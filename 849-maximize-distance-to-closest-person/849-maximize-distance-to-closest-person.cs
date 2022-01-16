public class Solution {
    public int MaxDistToClosest(int[] seats)
    {
        int lastTaken = -1, maxGap = 0;

        for (var i = 0; i < seats.Length; i++)
        {
            if (seats[i] == 0)
            {
                continue;
            }

            var gap = lastTaken == -1 ? 2 * i :  i - lastTaken;
            maxGap = Math.Max(maxGap, gap);

            lastTaken = i;
        }

        return Math.Max(maxGap / 2, seats.Length - 1 - lastTaken);
    }
}