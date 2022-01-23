public class Solution {
    public int FindNumbers(int[] nums)
    {
        var result = 0;
        foreach (var num in nums)
        {
            if (HasEvenNumberOfDigits(num))
            {
                result++;
            }
        }

        return result;
    }

    private static bool HasEvenNumberOfDigits(int n)
    {
        var even = true;

        while (n > 0)
        {
            even = !even;
            n /= 10;
        }
        
        return even;
    }
}