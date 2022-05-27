public class Solution {
    public int NumberOfSteps(int num)
    {
        var count = 0;
        while (num > 0)
        {
            if (num % 2 == 0)
            {
                num /= 2;
            }
            else
            {
                num--;
            }

            count++;
        }
        return count;
    }
}