using System.Text;

public class Solution {
    public string AddBinary(string a, string b)
    {
        var result = new StringBuilder();
        var carriage = 0;
        var length = Math.Max(a.Length, b.Length);
        string reversedA = Reverse(a), reverseB = Reverse(b);

        for (var index = 0; index < length; index++)
        {
            var currentValue = GetValue(reversedA, index) + GetValue(reverseB, index) + carriage;
            carriage = currentValue / 2;
            result.Append(currentValue % 2);
        }

        if (carriage > 0)
        {
            result.Append(carriage);
        }
        
        return Reverse(result.ToString());
    }

    private static int GetValue(string s, int index)
    {
        return index < s.Length ? s[index] - '0' : 0;
    }

    private static string Reverse(string s)
    {
        var charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}