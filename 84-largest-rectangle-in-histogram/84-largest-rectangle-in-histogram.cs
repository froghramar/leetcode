public class Solution {
    public int LargestRectangleArea(int[] heights)
    {
        int result = 0, i = 0;
        var stack = new Stack<int>();

        while (i < heights.Length)
        {
            if (!stack.Any() || heights[stack.Peek()] <= heights[i])
            {
                stack.Push(i++);
            }
            else
            {
                var peek = stack.Pop();
                var areaWithTop = heights[peek] * (stack.Any() ? i - stack.Peek() - 1 : i);
                result = Math.Max(result, areaWithTop);
            }
        }
        
        while (stack.Any())
        {
            var peek = stack.Pop();
            var areaWithTop = heights[peek] * (stack.Any() ? i - stack.Peek() - 1 : i);
            result = Math.Max(result, areaWithTop);
        }  

        return result;
    }
}