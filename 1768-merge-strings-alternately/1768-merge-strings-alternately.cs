using System.Text;

public class Solution {
    public string MergeAlternately(string word1, string word2)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < word1.Length || i < word2.Length; i++)
        {
            if (i < word1.Length)
            {
                sb.Append(word1[i]);
            }
            
            if (i < word2.Length)
            {
                sb.Append(word2[i]);
            }
        }
        
        return sb.ToString();
    }
}