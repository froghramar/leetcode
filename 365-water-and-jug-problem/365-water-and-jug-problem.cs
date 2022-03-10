public class Solution {
    public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity)
    {
        if (jug1Capacity + jug2Capacity < targetCapacity)
        {
            return false;
        }
        
        var gcd = GCD(jug1Capacity,jug2Capacity);
        return targetCapacity % gcd == 0;
    }
    
    private static int GCD(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
            {
                a %= b;
            }
            else
            {
                b %= a;
            }
        }

        return a | b;
    }
}