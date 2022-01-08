public class Solution {
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();

        foreach (var ch in s)
        {
            if (ch == '(' || ch == '{' || ch == '[')
            {
                stack.Push(ch);
            }
            else
            {
                if (stack.Any() is false)
                {
                    return false;
                }

                var top = stack.Pop();
                if (IsPair(top, ch) is false)
                {
                    return false;
                }
            }
        }

        return stack.Any() is false;
    }

    private static bool IsPair(char left, char right)
    {
        return right switch
        {
            ')' => left == '(',
            '}' => left == '{',
            ']' => left == '[',
        };
    }
}