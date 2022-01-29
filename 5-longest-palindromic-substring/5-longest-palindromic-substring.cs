public class Solution {
    public string LongestPalindrome(string s)
    {
        var length = s.Length;
        var result = -1;
        var resultStart = -1;

        var isPalindrome = new int[length][];
        for (var index = 0; index < isPalindrome.Length; index++)
        {
            isPalindrome[index] = new int[length];
        }

        for (var start = 0; start < length; start++)
        {
            for (var end = 0; end < length; end++)
            {
                if (IsPalindrome(start, end))
                {
                    var currentLength = end - start + 1;
                    if (currentLength > result)
                    {
                        resultStart = start;
                        result = currentLength;
                    }
                }
            }
        }

        bool IsPalindrome(int start, int end)
        {
            if (isPalindrome[start][end] != 0)
            {
                return isPalindrome[start][end] == 1;
            }
            
            while (start < end)
            {
                if (s[start] != s[end])
                {
                    isPalindrome[start][end] = -1;
                    return false;
                }
                start++;
                end--;
            }

            isPalindrome[start][end] = 1;
            return true;
        }

        return s.Substring(resultStart, result);
    }
}