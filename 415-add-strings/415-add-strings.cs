using System.Text;

public class Solution {
    public string AddStrings(string num1, string num2)
    {
        var result = new StringBuilder();
        var len = Math.Max(num1.Length, num2.Length);
        var current = 0;

        for (var i = 0; i < len; i++)
        {
            if (i < num1.Length)
            {
                current += num1[num1.Length - i - 1] - '0';
            }
            
            if (i < num2.Length)
            {
                current += num2[num2.Length - i - 1] - '0';
            }

            result.Append((char) ('0' + current % 10));
            current /= 10;
        }

        if (current > 0)
        {
            result.Append((char) ('0' + current));
        }

        var charArray = result.ToString().ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}