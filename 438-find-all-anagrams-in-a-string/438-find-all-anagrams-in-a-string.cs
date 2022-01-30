public class Solution {
    public IList<int> FindAnagrams(string s, string p)
    {
        int[] expectedCount = new int[26], currentCount = new int[26];
        int aheadCount = 0, behindCount = 0, left = 0;
        var result = new List<int>();

        foreach (var ch in p)
        {
            expectedCount[ch - 'a']++;
        }

        for (var i = 0; i < 26; i++)
        {
            if (expectedCount[i] > 0)
            {
                behindCount++;
            }
        }

        for (var right = 0; right < s.Length; right++)
        {
            var rightIndex = s[right] - 'a';
            currentCount[rightIndex]++;

            if (currentCount[rightIndex] == expectedCount[rightIndex])
            {
                behindCount--;
            }
            else if (currentCount[rightIndex] == expectedCount[rightIndex] + 1)
            {
                aheadCount++;
            }

            while (left <= right && aheadCount > 0)
            {
                var leftIndex = s[left] - 'a';
                currentCount[leftIndex]--;
                
                if (currentCount[leftIndex] == expectedCount[leftIndex])
                {
                    aheadCount--;
                }
                else if (currentCount[leftIndex] == expectedCount[leftIndex] - 1)
                {
                    behindCount++;
                }

                left++;
            }

            if (aheadCount == 0 && behindCount == 0)
            {
                result.Add(left);
            }
        }

        return result;
    }
}