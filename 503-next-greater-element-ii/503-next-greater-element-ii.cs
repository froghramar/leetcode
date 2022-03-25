public class Solution {
    public int[] NextGreaterElements(int[] nums)
    {
        var result = new int[nums.Length];
        Array.Fill(result, -1);
        
        var stack = new Stack<int>();
        for (var i = 0; i < 2 * nums.Length; i++)
        {
            var p = i % nums.Length;
            while (stack.Any() && nums[p] > nums[stack.Peek()])
            {
                var q = stack.Pop();
                result[q] = nums[p];
            }
            
            stack.Push(p);
        }

        return result;
    }
}