public class Solution {
    public int EvalRPN(string[] tokens)
    {
        var stack = new Stack<int>();
        foreach (var token in tokens)
        {
            if (token is "+" or "-" or "/" or "*")
            {
                var (operand2, operand1) = (stack.Pop(), stack.Pop());
                stack.Push(Calculate(operand1, operand2, token[0]));
            }
            else
            {
                stack.Push(int.Parse(token));
            }
        }

        return stack.Pop();
    }

    private static int Calculate(int operand1, int operand2, char @operator)
    {
        return @operator switch
        {
            '+' => operand1 + operand2,
            '-' => operand1 - operand2,
            '*' => operand1 * operand2,
            '/' => operand1 / operand2,
        };
    }
}