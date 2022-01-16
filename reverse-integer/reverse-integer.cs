public class Solution {
    public int Reverse(int x)
    {
        if (x == -2147483648)
        {
            return 0;
        }
        
        var absoluteX = Math.Abs(x);

        var result = 0;
        var digitsFromSource = GetDigits(absoluteX);
        while (absoluteX > 0)
        {
            var digit = absoluteX % 10;
            result = result * 10 + digit;
            absoluteX /= 10;
        }

        if (result < 0)
        {
            return 0;
        }

        var digitsFromResult = GetDigits(result);

        while (digitsFromResult.Count < digitsFromSource.Count)
        {
            digitsFromResult.Add(0);
        }
        
        digitsFromResult.Reverse();
        
        for (var index = 0; index < digitsFromSource.Count; index++)
        {
            if (digitsFromSource[index] != digitsFromResult[index])
            {
                return 0;
            }
        }
        
        return x < 0 ? -result: result;

        List<int> GetDigits(int n)
        {
            var digits = new List<int>();
            while (n > 0)
            {
                digits.Add(n % 10);
                n /= 10;
            }

            return digits;
        }
    }
}