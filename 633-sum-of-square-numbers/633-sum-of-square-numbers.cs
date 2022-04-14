public class Solution {
    public bool JudgeSquareSum(int c)
    {
        var sq = Math.Sqrt(c);
        for (var i = 0; i <= sq; i++)
        {
            if (PerfectSquare(c - i * i))
            {
                return true;
            }
        }

        return false;
    }

    private static bool PerfectSquare(int n)
    {
        var sq = (int) Math.Sqrt(n);
        try
        {
            return checked(sq * sq) == n;
        }
        catch (OverflowException)
        {
            return false;
        }
    }
}