using System.Text;

public class Solution {
    public string FrequencySort(string s)
    {
        var dictionary = new Dictionary<char, int>();
        foreach (var ch in s)
        {
            if (dictionary.ContainsKey(ch))
            {
                dictionary[ch]++;
            }
            else
            {
                dictionary[ch] = 1;
            }
        }

        var list = dictionary.ToList();
        list.Sort((v1, v2) => v2.Value - v1.Value);
        
        var result = new StringBuilder();
        foreach (var (ch, count) in list)
        {
            result.Append(new string(ch, count));
        }

        return result.ToString();
    }
}