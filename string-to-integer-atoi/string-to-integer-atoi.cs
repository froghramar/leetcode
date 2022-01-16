public class Solution {
    public int MyAtoi(string s)
    {
        var isMinus = false;
        var result = 0L;
        var digitStarted = false;
        var signOccured = false;

        foreach (var ch in s)
        {
            if (ch == ' ')
            {
                if (digitStarted || signOccured)
                {
                    break;
                }
            }
            else if (ch is >= '0' and <= '9')
            {
                digitStarted = true;

                result = result * 10 + ch - '0';

                result = Math.Min(result, int.MaxValue + 1L);
            }
            else if (ch == '+' || ch == '-')
            {
                if (signOccured || digitStarted)
                {
                    break;
                }
                
                signOccured = true;

                if (ch == '-')
                {
                    isMinus = true;
                }
            }
            else
            {
                break;
            }
        }

        if (isMinus)
        {
            result = -result;
        }

        result = Math.Min(result, int.MaxValue);
        result = Math.Max(result, int.MinValue);

        return (int) result;
    }
}