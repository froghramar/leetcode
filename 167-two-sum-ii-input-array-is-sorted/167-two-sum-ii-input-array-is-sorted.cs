public class Solution {
    public int[] TwoSum(int[] numbers, int target)
    {
        var indices = new int[2005];

        for (var i = 0; i < numbers.Length; i++)
        {
            var num2 = numbers[i];
            var num1 = target - num2 + 1000;
            if (indices[num1] != 0)
            {
                return new[] {indices[num1], i + 1};
            }

            indices[num2 + 1000] = i + 1;
        }

        return new[] {-1, -1};
    }
}