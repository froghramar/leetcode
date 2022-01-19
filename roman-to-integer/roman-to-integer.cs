using System.Collections.Generic;

public class Solution {
    public int RomanToInt(string s) {
        var dictionary = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

        var result = 0;

        for (int index = 0; index < s.Length; index++)
        {
            if (index != 0 && dictionary[s[index - 1]] < dictionary[s[index]])
            {
                result += dictionary[s[index]] - 2 * dictionary[s[index - 1]];
            }
            else
            {
                result += dictionary[s[index]];
            }
        }

        return result;
    }
}