public class Solution {
    public bool RepeatedSubstringPattern(string s) {
        for (var len = 1; len <= s.Length / 2; len++)
        {
            if (s.Length % len != 0)
            {
                continue;
            }

            var repeated = true;
            for (var i = len; i < s.Length; i++)
            {
                if (s[i] != s[i % len])
                {
                    repeated = false;
                    break;
                }
            }
            
            if (repeated)
            {
                return true;
            }
        }

        return false;
    }
}