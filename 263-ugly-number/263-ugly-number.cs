public class Solution {
    public bool IsUgly(int n)
    {
        if (n == 0)
        {
            return false;
        }
        
        foreach (var d in new [] {2, 3, 5})
        {
            n = DivideUntilLast(n, d);
        }

        return n == 1;
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