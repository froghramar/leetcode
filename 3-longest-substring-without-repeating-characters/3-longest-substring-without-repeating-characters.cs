public class Solution {
    public int LengthOfLongestSubstring(string s)
    {
        var occurrences = new Dictionary<char, int>();
        var numberOfCharactersWithMultipleOccurrences = 0;
        var backwardPointer = 0;
        var result = 0;

        for (var forwardPointer = 0; forwardPointer < s.Length; forwardPointer++)
        {
            var currentChar = s[forwardPointer];
            
            AddOccurrence(currentChar);

            while (numberOfCharactersWithMultipleOccurrences > 0)
            {
                RemoveOccurrence(s[backwardPointer]);
                backwardPointer++;
            }

            result = Math.Max(result, forwardPointer - backwardPointer + 1);
        }

        void AddOccurrence(char ch)
        {
            if (occurrences.ContainsKey(ch))
            {
                occurrences[ch]++;
            }
            else
            {
                occurrences[ch] = 1;
            }

            if (occurrences[ch] == 2)
            {
                numberOfCharactersWithMultipleOccurrences++;
            }
        }

        void RemoveOccurrence(char ch)
        {
            occurrences[ch]--;

            if (occurrences[ch] == 1)
            {
                numberOfCharactersWithMultipleOccurrences--;
            }
        }

        return result;
    }
}