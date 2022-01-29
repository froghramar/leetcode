using System.Text;

public class Solution {
    public bool BackspaceCompare(string s, string t)
    {
        return Evaluate(s) == Evaluate(t);
    }

    private string Evaluate(string s)
    {
        var sb = new StringBuilder();
        foreach (var ch in s)
        {
            if (ch == '#')
            {
                if (sb.Length > 0)
                {
                    sb.Length--;
                }
            }
            else
            {
                sb.Append(ch);
            }
        }

        return sb.ToString();
    }
}