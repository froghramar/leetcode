using System.Text;

public class Solution {
    public string MinRemoveToMakeValid(string s)
    {
        var sb = new StringBuilder(s);
        var stack = new Stack<int>();
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                stack.Push(i);
            }
            else if (s[i] == ')')
            {
                if (stack.Any())
                {
                    stack.Pop();
                }
                else
                {
                    sb[i] = '.';
                }
            }
        }

        while (stack.Any())
        {
            sb[stack.Pop()] = '.';
        }

        return sb.Replace(".", "").ToString();
    }
}