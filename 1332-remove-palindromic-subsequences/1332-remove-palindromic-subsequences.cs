public class Solution {
    public int RemovePalindromeSub(string s)
    {
        for (var i = 0; i < s.Length / 2; i++)
        {
            if (s[i] != s[s.Length - i - 1])
            {
                return 2;
            }
        }
        return 1;
    }
}