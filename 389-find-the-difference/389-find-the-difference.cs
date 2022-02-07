public class Solution {
    public char FindTheDifference(string s, string t)
    {
        s = GetSortedString(s);
        t = GetSortedString(t);
        
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] != t[i])
            {
                return t[i];
            }
        }

        return t[s.Length];
    }

    string GetSortedString(string s)
    {
        return string.Concat(s.OrderBy(c => c));
    }
}