public class Solution {
    public int FindComplement(int num)
    {
        var bits = new Stack<int>();

        while (num > 0)
        {
            var bit = num % 2;
            num /= 2;
            bits.Push(bit);
        }

        var result = 0;
        while (bits.Any())
        {
            var bit = bits.Pop();
            var complement = 1 - bit;
            result = result * 2 + complement;
        }

        return result;
    }
}