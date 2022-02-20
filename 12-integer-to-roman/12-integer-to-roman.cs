public class Solution {
    public string IntToRoman(int num)
    {
        var map = new Dictionary<int, string>
        {
            { 1, "I" },
            { 4, "IV" },
            { 5, "V" },
            { 9, "IX" },
            { 10, "X" },
            { 40, "XL" },
            { 50, "L" },
            { 90, "XC" },
            { 100, "C" },
            { 400, "CD" },
            { 500, "D" },
            { 900, "CM" },
            { 1000, "M" },
        };

        var result = string.Empty;

        while (num > 0)
        {
            var maxDeduction = 1;
            foreach (var (key, value) in map)
            {
                if (key <= num)
                {
                    maxDeduction = Math.Max(maxDeduction, key);
                }
            }

            result += map[maxDeduction];
            num -= maxDeduction;
        }
        
        return result;
    }
}