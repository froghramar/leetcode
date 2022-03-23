public class Solution {
    public int BrokenCalc(int startValue, int target)
    {
        if (startValue >= target)
        {
            return startValue - target;
        }

        if (target % 2 == 0)
        {
            return 1 + BrokenCalc(startValue, target / 2);
        }

        return 1 + BrokenCalc(startValue, target + 1);
    }
}