public class Solution {
    public string FreqAlphabets(string s) {
        for (var i = 25; i >= 0; i--)
        {
            var key = (i + 1).ToString();
            if (i >= 9)
            {
                key += "#";
            }
            
            s = s.Replace(key, $"{(char)('a' + i)}");
        }

        return s;
    }
}