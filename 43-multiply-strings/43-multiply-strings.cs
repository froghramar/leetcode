using System.Text;

public class Solution {
    public string Multiply(string num1, string num2)
    {
        var gap = string.Empty;
        var sum = "0";
        for (var i = num2.Length - 1; i >= 0; i--)
        {
            var current = Multiply(num1, num2[i] - '0');
            sum = Sum(sum, current + gap);

            gap += '0';
        }

        var allZero = true;
        foreach (var ch in sum)
        {
            if (ch != '0')
            {
                allZero = false;
                break;
            }
        }

        return allZero ? "0" : sum;
    }

    private string Multiply(string num, int k)
    {
        var result = new StringBuilder();
        var carriage = 0;

        for (var i = num.Length - 1; i >= 0; i--)
        {
            var x = (num[i] - '0') * k + carriage;
            result.Append((char) (x % 10 + '0'));
            carriage = x / 10;
        }

        if (carriage > 0)
        {
            result.Append((char)(carriage + '0'));
        }
        
        return Reverse(result.ToString());
    }

    private string Sum(string num1, string num2)
    {
        var len = Math.Max(num1.Length, num2.Length);
        var result = new StringBuilder();
        var carriage = 0;

        for (var i = 0; i < len; i++)
        {
            var x = carriage;

            if (i < num1.Length)
            {
                x += num1[num1.Length - i - 1] - '0';
            }

            if (i < num2.Length)
            {
                x += num2[num2.Length - i - 1] - '0';
            }
            
            result.Append((char) (x % 10 + '0'));
            carriage = x / 10;
        }
        
        if (carriage > 0)
        {
            result.Append((char)(carriage + '0'));
        }

        return Reverse(result.ToString());
    }

    private string Reverse(string s)
    {
        var charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}