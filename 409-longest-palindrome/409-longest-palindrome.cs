public class Solution {
    public int LongestPalindrome(string s)
    {
        var count = new int[52];

        foreach (var ch in s)
        {
            if (char.IsUpper(ch))
            {
                count[ch - 'A']++;
            }
            else
            {
                count[ch - 'a' + 26]++;
            }
        }

        var oddCount = 0;
        for (var i = 0; i < 52; i++)
        {
            if (count[i] % 2 == 1)
            {
                oddCount++;
            }
        }

        return oddCount > 0 ? s.Length - oddCount + 1 : s.Length;
    }
}