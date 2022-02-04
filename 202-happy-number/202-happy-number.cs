public class Solution {
    public bool IsHappy(int n)
    {
        int current = n, move = 0;
        while (move < 100000)
        {
            current = Move(current);
            move++;
            
            if (current == 1)
            {
                return true;
            }

            if (current == n)
            {
                return false;
            }
        }

        return false;
    }

    private static int Move(int x)
    {
        var result = 0;
        while (x > 0)
        {
            var digit = x % 10;
            result += digit * digit;
            x /= 10;
        }

        return result;
    }
}