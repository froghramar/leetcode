public class Solution {
    public bool ValidPalindrome(string s)
    {
        return ValidPalindromeInternal(s, 0, s.Length - 1, true);
    }
    
    private bool ValidPalindromeInternal(string s, int i, int j, bool canDelete)
    {
        if (i > j)
        {
            return true;
        }
        
        if (s[i] == s[j])
        {
            return ValidPalindromeInternal(s, i + 1, j - 1, canDelete);
        }

        if (canDelete is false)
        {
            return false;
        }

        return ValidPalindromeInternal(s, i, j - 1, false)
               || ValidPalindromeInternal(s, i + 1, j, false);
    }
}