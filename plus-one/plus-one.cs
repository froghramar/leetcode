public class Solution {
    public int[] PlusOne(int[] digits)
    {
        var result = new LinkedList<int>();
        var carriage = 1;

        for (var i = digits.Length - 1; i >= 0; i--)
        {
            var current = (digits[i] + carriage) % 10;
            carriage = (digits[i] + carriage) / 10;

            result.AddFirst(current);
        }

        if (carriage > 0)
        {
            result.AddFirst(carriage);
        }

        return result.ToArray();
    }
}