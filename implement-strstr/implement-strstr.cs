public class Solution {
    public int StrStr(string haystack, string needle) {

        if (needle.Length == 0)
        {
            return 0;
        }
        
        for (var i = 0; i < haystack.Length - needle.Length + 1; i++)
        {
            var found = true;
            for (var j = 0; j < needle.Length; j++)
            {
                if (haystack[i + j] != needle[j])
                {
                    found = false;
                    break;
                }
            }

            if (found)
            {
                return i;
            }
        }

        return -1;
    }
}