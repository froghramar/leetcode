using System.Text;

public class Solution {
    public string RemoveDuplicateLetters(string s)
    {
        var taken = new bool[26];
        var last = new int[26];
        Array.Fill(last, -1);

        var sb = new StringBuilder();
        var pos = -1;

        for (var i = 0; i < s.Length; i++)
        {
            last[s[i] - 'a'] = i;
        }
        
        for (var i = 0; i < s.Length; i++)
        {
            if (taken[s[i] - 'a'])
            {
                continue;
            }
            
            while (pos > -1 && s[i] < sb[pos] && last[sb[pos] - 'a'] > i)
            {
                taken[sb[pos] - 'a'] = false;
                pos--;
            }

            if (pos + 1 >= sb.Length)
            {
                sb.Append(s[i]);
                pos++;
            }
            else
            {
                sb[++pos] = s[i];
            }

            taken[s[i] - 'a'] = true;
        }

        return sb.ToString();
    }
}