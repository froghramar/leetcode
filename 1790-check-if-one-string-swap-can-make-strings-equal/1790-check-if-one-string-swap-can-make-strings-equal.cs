public class Solution {
    public bool AreAlmostEqual(string s1, string s2)
    {
        int p1 = -1, p2 = -1;
        for (var i = 0; i < s1.Length; i++)
        {
            if (s1[i] == s2[i])
            {
                continue;
            }

            if (p1 == -1)
            {
                p1 = i;
            }
            else if (p2 == -1)
            {
                p2 = i;
            }
            else
            {
                return false;
            }
        }

        if (p1 == -1)
        {
            return true;
        }

        if (p2 == -1)
        {
            return false;
        }

        return s1[p1] == s2[p2] && s1[p2] == s2[p1];
    }
}