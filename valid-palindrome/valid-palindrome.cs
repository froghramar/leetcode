public class Solution {
    public bool IsPalindrome(string s)
    {
        int i = 0, j = s.Length - 1;
        SkipNonAlphaNumerics();

        while (i < j)
        {
            if (char.ToUpper(s[i]) != char.ToUpper(s[j]))
            {
                return false;
            }

            i++;
            j--;
            
            SkipNonAlphaNumerics();
        }

        void SkipNonAlphaNumerics()
        {
            while (i < j && !IsAlphaNumeric(s[i])) i++;
            while (i < j && !IsAlphaNumeric(s[j])) j--;
        }

        return true;
    }

    private bool IsAlphaNumeric(char ch)
    {
        switch (ch)
        {
            case >= '0' and <= '9':
            case >= 'a' and <= 'z':
            case >= 'A' and <= 'Z':
                return true;
            default:
                return false;
        }
    }
}