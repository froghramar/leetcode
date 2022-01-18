public class Solution {
    public bool CheckInclusion(string s1, string s2)
    {
        var expectedCount = new int[26];

        foreach (var ch in s1)
        {
            expectedCount[ch - 'a']++;
        }

        var currentCount = new int[26];
        int aheadCount = 0, behindCount = 0;
        for (var i = 0; i < 26; i++)
        {
            if (expectedCount[i] != 0)
            {
                behindCount++;
            }
        }

        var back = 0;
        for (var i = 0; i < s2.Length; i++)
        {
            AddChar(s2[i]);

            while (back < i && aheadCount > 0)
            {
                RemoveChar(s2[back++]);
            }

            if (behindCount == 0)
            {
                return true;
            }
        }

        void AddChar(char ch)
        {
            var i = ch - 'a';

            if (currentCount[i] == expectedCount[i])
            {
                aheadCount++;
            }
            else if (currentCount[i] == expectedCount[i] - 1)
            {
                behindCount--;
            }

            currentCount[i]++;
        }
        
        void RemoveChar(char ch)
        {
            var i = ch - 'a';
            
            if (currentCount[i] == expectedCount[i])
            {
                behindCount++;
            }
            else if (currentCount[i] == expectedCount[i] + 1)
            {
                aheadCount--;
            }
            
            currentCount[i]--;
        }

        return false;
    }
}