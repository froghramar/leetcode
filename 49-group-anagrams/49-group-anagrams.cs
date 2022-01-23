public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var dictionary = new Dictionary<string, IList<string>>();
        
        foreach (var str in strs)
        {
            var sorted = GetSortedString(str);
            if (!dictionary.ContainsKey(sorted))
            {
                dictionary[sorted] = new List<string>();
            }
            
            dictionary[sorted].Add(str);
        }

        return dictionary.Values.ToList();
    }

    private static string GetSortedString(string s)
    {
        var charArray = s.ToCharArray();
        Array.Sort(charArray);
        return new string(charArray);
    }
}