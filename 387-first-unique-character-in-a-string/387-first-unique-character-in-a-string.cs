public class Solution {
    public int FirstUniqChar(string s)
    {
        var occurrence = new Dictionary<char, List<int>>();

        for (var i = 0; i < s.Length; i++)
        {
            var ch = s[i];
            if (occurrence.ContainsKey(ch))
            {
                occurrence[ch].Add(i);
            }
            else
            {
                occurrence[ch] = new List<int> {i};
            }
        }
        
        foreach (var (ch, oc) in occurrence)
        {
            if (oc.Count == 1)
            {
                return oc.First();
            }
        }

        return -1;
    }
}