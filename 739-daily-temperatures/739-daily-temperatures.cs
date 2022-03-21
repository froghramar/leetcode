public class Solution {
    public int[] DailyTemperatures(int[] temperatures)
    {
        var answer = new int[temperatures.Length];
        var stack = new Stack<int>();
        for (var i = 0; i < temperatures.Length; i++)
        {
            while (stack.Any() && temperatures[i] > temperatures[stack.Peek()])
            {
                var top = stack.Pop();
                answer[top] = i - top;
            }
            stack.Push(i);
        }

        return answer;
    }
}