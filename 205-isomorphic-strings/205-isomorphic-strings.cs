public class Solution {
    public bool IsIsomorphic(string s, string t)
    {
        var map = new Dictionary<char, char>();
        var taken = new HashSet<char>();
        
        for (var i = 0; i < s.Length; i++)
        {
            if (map.ContainsKey(s[i]))
            {
                if (map[s[i]] != t[i])
                {
                    return false;
                }
            }
            else
            {
                if (taken.Contains(t[i]))
                {
                    return false;
                }

                taken.Add(t[i]);
                map[s[i]] = t[i];
            }
        }

        return true;
    }
}