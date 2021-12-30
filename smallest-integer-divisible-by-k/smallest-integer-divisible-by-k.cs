public class Solution {
    public int SmallestRepunitDivByK(int k)
    {
        var number = 0;

        for (var digit = 1; digit <= k; digit++)
        {
            number = (number * 10 + 1) % k;

            if (number == 0)
            {
                return digit;
            }
        }

        return -1;
    }
}