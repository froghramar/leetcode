public class Solution {
    public bool IsScramble(string s1, string s2)
    {
        var mem = new Dictionary<string, bool>();
        return IsScrambleInternal(s1, s2, mem);
    }

    private static bool IsScrambleInternal(string s1, string s2, Dictionary<string, bool> mem)
    {
        var key = s1 + "-" + s2;

        if (mem.ContainsKey(key))
        {
            return mem[key];
        }

        if (HasEqualCharacters(s1, s2) is false)
        {
            return mem[key] = false;
        }

        if (string.Equals(s1, s2))
        {
            return mem[key] = true;
        }

        for (var i = 1; i < s1.Length; i++)
        {
            if (IsScrambleInternal(s1.Substring(0, i), s2.Substring(0, i), mem) &&
                IsScrambleInternal(s1.Substring(i), s2.Substring(i), mem))
            {
                return mem[key] = true;
            }
            
            if (IsScrambleInternal(s1.Substring(0, i), s2.Substring(s2.Length - i), mem) &&
                IsScrambleInternal(s1.Substring(i), s2.Substring(0, s2.Length - i), mem))
            {
                return mem[key] = true;
            }
        }

        return mem[key] = false;
    }

    private static bool HasEqualCharacters(string s1, string s2)
    {
        return s1.Length == s2.Length && GetSortedCharacters(s1) == GetSortedCharacters(s2);
    }

    private static string GetSortedCharacters(string s)
    {
        var arr = s.ToCharArray();
        Array.Sort(arr);
        return new string(arr);
    }
}