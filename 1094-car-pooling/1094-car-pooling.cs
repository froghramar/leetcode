public class Solution {
    public bool CarPooling(int[][] trips, int capacity)
    {
        var newPassengers = new int[1001];

        foreach (var trip in trips)
        {
            newPassengers[trip[1]] += trip[0];
            newPassengers[trip[2]] -= trip[0];
        }

        var totalPassengers = 0;
        for (var i = 0; i <= 1000; i++)
        {
            totalPassengers += newPassengers[i];
            if (totalPassengers > capacity)
            {
                return false;
            }
        }

        return true;
    }
}