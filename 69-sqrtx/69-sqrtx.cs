public class Solution {
    public int MySqrt(int x)
    { 
        int l = 0, r = Math.Min(x, int.MaxValue - 1);
        while (l < r)
        {
            var m = l + (r - l + 1) / 2;
            try
            {
                var sq = checked(m * m);
                if (sq <= x)
                {
                    l = m;
                }
                else
                {
                    r = m - 1;
                }
            }
            catch (OverflowException)
            {
                r = m - 1;
            }
        }
        return l;
    }
}