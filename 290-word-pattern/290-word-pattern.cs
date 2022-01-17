public class Solution {
    public bool WordPattern(string pattern, string s)
    {
        var dictionary = new Dictionary<string, char>();
        var taken = new HashSet<char>();

        var words = s.Split(' ');

        if (words.Length != pattern.Length)
        {
            return false;
        }

        for (var i = 0; i < pattern.Length; i++)
        {
            if (dictionary.ContainsKey(words[i]))
            {
                if (dictionary[words[i]] != pattern[i])
                {
                    return false;
                }
            }
            else
            {
                if (taken.Contains(pattern[i]))
                {
                    return false;
                }

                taken.Add(pattern[i]);
                dictionary[words[i]] = pattern[i];
            }
        }

        return true;
    }
}