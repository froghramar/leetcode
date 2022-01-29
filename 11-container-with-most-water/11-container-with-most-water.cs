public class Solution {
    public int MaxArea(int[] height)
    {
        var result = 0;

        for (int leftIndex = 0, rightIndex = height.Length - 1; leftIndex <= rightIndex;)
        {
            var newVolume = (rightIndex - leftIndex) * Math.Min(height[leftIndex], height[rightIndex]);
            result = Math.Max(result, newVolume);

            if (height[leftIndex] > height[rightIndex])
            {
                var newRightIndex = rightIndex - 1;
                while (newRightIndex >= leftIndex && height[newRightIndex] <= height[rightIndex])
                {
                    newRightIndex--;
                }

                rightIndex = newRightIndex;
            }
            else
            {
                var newLeftIndex = leftIndex + 1;
                while (newLeftIndex <= rightIndex && height[newLeftIndex] <= height[leftIndex])
                {
                    newLeftIndex++;
                }

                leftIndex = newLeftIndex;
            }
        }

        return result;
    }
}