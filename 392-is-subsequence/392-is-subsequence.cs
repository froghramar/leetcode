public class Solution {
    public bool IsSubsequence(string s, string t)
    {
        int sId = 0, tId = 0;

        while (sId < s.Length && tId < t.Length)
        {
            if (s[sId] == t[tId])
            {
                sId++;
            }

            tId++;
        }

        return sId == s.Length;
    }
}