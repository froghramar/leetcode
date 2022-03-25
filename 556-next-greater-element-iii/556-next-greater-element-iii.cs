public class Solution {
    public int NextGreaterElement(int n)
    {
        var digits = n.ToString().ToCharArray().Select(ch => ch - '0').ToArray();
        var br = FindBreak(digits);
        if (br == -1)
        {
            return -1;
        }

        var nextBig = NextBig(digits, br);
        (digits[br], digits[nextBig]) = (digits[nextBig], digits[br]);
        
        Array.Sort(digits, br + 1, digits.Length - br - 1);

        var result = 0;
        foreach (var digit in digits)
        {
            try
            {
                result = checked(result * 10 + digit);
            }
            catch (OverflowException)
            {
                return -1;
            }
        }
        
        return result;
    }

    private static int FindBreak(int[] digits)
    {
        for (var i = digits.Length - 1; i > 0; i--)
        {
            if (digits[i] > digits[i - 1])
            {
                return i - 1;
            }
        }

        return -1;
    }

    private static int NextBig(int[] digits, int i)
    {
        var min = i + 1;
        for (var j = i + 2; j < digits.Length; j++)
        {
            if (digits[j] > digits[i] && digits[j] < digits[min])
            {
                min = j;
            }
        }

        return min;
    }
}