public class Solution {
    public bool IsAnagram(string s, string t)
    {
        const int englishLetterCount = 26;
        int[] sCount = new int[englishLetterCount], tCount = new int[englishLetterCount];

        foreach (var ch in s)
        {
            sCount[ch - 'a']++;
        }

        foreach (var ch in t)
        {
            tCount[ch - 'a']++;
        }

        for (var i = 0; i < englishLetterCount; i++)
        {
            if (sCount[i] != tCount[i])
            {
                return false;
            }
        }

        return true;
    }
}