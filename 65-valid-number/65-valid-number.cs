public class Solution {
    public bool IsNumber(string s) {
        var eIndex = s.IndexOfAny(new[] {'e', 'E'});
        if (eIndex == -1)
        {
            return IsDecimal(s) || IsInteger(s);
        }

        var first = s.Substring(0, eIndex);
        var second = s.Substring(eIndex + 1);
        return (IsDecimal(first) || IsInteger(first)) && IsInteger(second);
    }

    private bool IsDecimal(string s)
    {
        var dotIndex = s.IndexOf('.');
        if (dotIndex == -1)
        {
            return false;
        }

        var start = 0;
        if (s[0] == '+' || s[0] == '-')
        {
            start = 1;
        }

        var first = s.Substring(start, dotIndex - start);
        var second = s.Substring(dotIndex + 1);

        if (first.Length == 0 && second.Length == 0)
        {
            return false;
        }

        return (first.Length == 0 || AllDigits(first)) && (second.Length == 0 || AllDigits(second));
    }

    private bool AllDigits(string s)
    {
        return s.All(char.IsDigit);
    }
    
    private bool IsInteger(string s)
    {
        var hasDigit = false;
        for (var i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                hasDigit = true;
                continue;
            }

            if (i == 0 && (s[i] == '+' || s[i] == '-'))
            {
                continue;
            }

            return false;
        }

        return hasDigit;
    }
}