public class Solution {
    public int NumPairsDivisibleBy60(int[] time)
    {
        var count = new int[60];
        var result = 0;

        foreach (var t in time)
        {
            var modulo = t % 60;
            var remainingModulo = (60 - modulo) % 60;
            result += count[remainingModulo];
            count[modulo]++;
        }

        return result;
    }
}