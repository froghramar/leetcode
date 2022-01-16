using System.Text;

public class Solution {
    public string ReverseWords(string s)
    {
        var words = s.Split(' ');
        var result = new StringBuilder();

        result.Append(Reverse(words[0]));
        for (var i = 1; i < words.Length; i++)
        {
            result.Append(' ');
            result.Append(Reverse(words[i]));
        }

        return result.ToString();
    }

    private string Reverse(string s)
    {
        var charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}