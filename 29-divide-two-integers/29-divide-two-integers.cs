using System.Text;

public class Solution {

    public int Divide(int dividend, int divisor)
    {
        return DivideInternal(dividend, divisor).Item1;
    }

    private static (int, int) DivideInternal(int dividend, int divisor)
    {
        var skip = false;

        if (divisor == int.MinValue)
        {
            return (dividend == int.MinValue ? 1 : 0, dividend);
        }
        
        if (dividend == int.MinValue)
        {
            if (divisor == 1)
            {
                return (int.MinValue, 0);
            }

            if (divisor == -1)
            {
                return (int.MaxValue, 0);
            }

            skip = true;
            dividend++;
        }

        var isNegative = (dividend < 0) ^ (divisor < 0);
        dividend = Math.Abs(dividend);
        divisor = Math.Abs(divisor);

        int l = 0, r = int.MaxValue;
        while (l < r)
        {
            var mid = l + ((r - l) >> 1) + 1;

            try
            {
                var product = MultiplyStringWithoutOperator(mid.ToString(), divisor);
                if (product > dividend)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid;
                }
            }
            catch (OverflowException)
            {
                r = mid - 1;
            }
        }
        
        int ans = l, rem = 0;
        try
        {
            var product = MultiplyStringWithoutOperator(ans.ToString(), divisor);
            if (skip && dividend - product == divisor - 1)
            {
                ans++;
            }
            else
            {
                rem = dividend - product;
            }
        }
        catch (OverflowException)
        {
        }

        return (isNegative ? -ans : ans, rem);
    }
    
    private static (int, int) DivideByTen(int x)
    {
        if (x < 10)
        {
            return (0, x);
        }
        var str = x.ToString();
        return (int.Parse(str.Substring(0, str.Length - 1)), str[^1] - '0');
    }
    
    private static int MultiplyStringWithoutOperator(string x, int y)
    {
        var result = new StringBuilder();
        var remaining = 0;
        for (var i = x.Length - 1; i >= 0; i--)
        {
            var digit = x[i] - '0';
            var m = checked(MultiplyIntWithoutOperator(y, digit) + remaining);
            var (d1, d2) = DivideByTen(m);
            result.Append((char) (d2 + '0'));
            remaining = d1;
        }

        if (remaining > 0)
        {
            result.Append(Reverse(remaining.ToString()));
        }

        return int.Parse(Reverse(result.ToString()));
    }
    
    private static int MultiplyIntWithoutOperator(int x, int y)
    {
        var result = 0;
        while (y > 0)
        {
            checked
            {
                result += x;
            }
            y--;
        }
        return result;
    }
    
    private static string Reverse(string s)
    {
        var charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}