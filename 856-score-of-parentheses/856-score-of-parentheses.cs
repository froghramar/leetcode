public class Solution {
    public int ScoreOfParentheses(string s)
    {
        var stack = new Stack<int>();
        foreach (var ch in s)
        {
            switch (ch)
            {
                case '(':
                    stack.Push(-1);
                    break;
                case ')':
                    var sum = 0;
                    while (stack.Peek() != -1)
                    {
                        sum += stack.Pop();
                    }

                    stack.Pop();
                    
                    stack.Push(sum == 0 ? 1 : 2 * sum);
                    break;
            }
        }

        return stack.Sum();
    }
}