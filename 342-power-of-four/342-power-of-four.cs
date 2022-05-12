public class Solution {
    public bool IsPowerOfFour(int n)
    {
        if (n <= 0)
        {
            return false;
        }

        return DivideUntilLast(n, 4) == 1;
    }

    private static int DivideUntilLast(int n, int d)
    {
        while (n % d == 0)
        {
            n /= d;
        }

        return n;
    }
}