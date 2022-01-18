public class Solution {
    public int GetMaxLen(int[] nums)
    {
        int result = 0, positive = 0, negative = 0;
        foreach (var num in nums)
        {
            if (num == 0)
            {
                positive = 0;
                negative = 0;
            }
            else if (num < 0)
            {
                (positive, negative) = (negative > 0 ? negative + 1 : 0, positive + 1);
            }
            else
            {
                (positive, negative) = (positive + 1, negative > 0 ? negative + 1 : 0);
            }

            result = Math.Max(result, positive);
        }

        return result;
    }
}