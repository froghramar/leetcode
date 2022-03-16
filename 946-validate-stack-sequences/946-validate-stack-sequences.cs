public class Solution {
    public bool ValidateStackSequences(int[] pushed, int[] popped)
    {
        var stack = new Stack<int>();
        int pushPos = 0, popPos = 0;
        while (popPos < popped.Length)
        {
            if (stack.Any() && stack.Peek() == popped[popPos])
            {
                stack.Pop();
                popPos++;
                continue;
            }

            if (pushPos == pushed.Length)
            {
                return false;
            }
            
            stack.Push(pushed[pushPos]);
            pushPos++;
        }

        return true;
    }
}