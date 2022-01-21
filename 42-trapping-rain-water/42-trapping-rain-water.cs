public class Solution {
    public int Trap(int[] height)
    {
        var n = height.Length;
        var leftMax = new int[n];
        leftMax[0] = 0;

        for (var i = 1; i < n; i++)
        {
            leftMax[i] = Math.Max(leftMax[i - 1], height[i - 1]);
        }

        var rightMax = new int[n];
        rightMax[n - 1] = 0;
        for (var i = n - 2; i >= 0; i--)
        {
            rightMax[i] = Math.Max(rightMax[i + 1], height[i + 1]);
        }

        var result = 0;

        for (var i = 0; i < n; i++)
        {
            var water = Math.Max(0, Math.Min(leftMax[i], rightMax[i]) - height[i]);
            result += water;
        }
        
        return result;
    }
}