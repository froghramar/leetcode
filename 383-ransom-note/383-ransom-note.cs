public class Solution {
    public bool CanConstruct(string ransomNote, string magazine)
    {
        const int englishLetterCount = 26;
        int[] ransomNoteCount = new int[englishLetterCount], magazineCount = new int[englishLetterCount];

        foreach (var ch in ransomNote)
        {
            ransomNoteCount[ch - 'a']++;
        }

        foreach (var ch in magazine)
        {
            magazineCount[ch - 'a']++;
        }

        for (int i = 0; i < englishLetterCount; i++)
        {
            if (ransomNoteCount[i] > magazineCount[i])
            {
                return false;
            }
        }

        return true;
    }
}