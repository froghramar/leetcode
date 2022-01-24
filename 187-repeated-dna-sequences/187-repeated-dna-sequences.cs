public class Solution {
    public IList<string> FindRepeatedDnaSequences(string s)
    {
        var count = new Dictionary<string, int>();
        
        for (var i = 9; i < s.Length; i++)
        {
            var subString = s.Substring(i - 9, 10);

            if (count.ContainsKey(subString))
            {
                count[subString]++;
            }
            else
            {
                count[subString] = 1;
            }
        }

        return count.Where(kv => kv.Value > 1).Select(kv => kv.Key).ToList();
    }
}