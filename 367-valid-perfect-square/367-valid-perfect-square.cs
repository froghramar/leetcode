public class Solution {
    public bool IsPerfectSquare(int num)
    {
        int l = 1, r = num;
        while (l < r)
        {
            var m = l + (r - l + 1) / 2;
            try
            {
                var sq = checked(m * m);
                if (sq > num)
                {
                    r = m - 1;
                }
                else
                {
                    l = m;
                }
            }
            catch (OverflowException)
            {
                r = m - 1;
            }
        }

        try
        {
            return checked(l * l) == num;
        }
        catch (OverflowException)
        {
            return false;
        }
    }
}