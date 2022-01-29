public class Solution {
    public int WiggleMaxLength(int[] nums)
    {
        int positive = 1, negative = 1, lastPositive = nums[0], lastNegative = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            var newPositive = positive;
            var newLastPositive = lastPositive;
            if (nums[i] > lastNegative && negative + 1 > positive)
            {
                newPositive = negative + 1;
                newLastPositive = nums[i];
            }
            else if (nums[i] > lastPositive)
            {
                newLastPositive = nums[i];
            }

            var newNegative = negative;
            var newLastNegative = lastNegative;
            if (nums[i] < lastPositive && positive + 1 > negative)
            {
                newNegative = positive + 1;
                newLastNegative = nums[i];
            }
            else if (nums[i] < lastNegative)
            {
                newLastNegative = nums[i];
            }

            positive = newPositive;
            lastPositive = newLastPositive;

            negative = newNegative;
            lastNegative = newLastNegative;
        }

        return Math.Max(positive, negative);
    }
}