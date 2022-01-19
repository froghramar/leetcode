public class Solution {
    public int MaxScoreSightseeingPair(int[] values)
    {
        var previous = values[0] - 1;
        var result = 0;

        for (var i = 1; i < values.Length; i++)
        {
            result = Math.Max(result, values[i] + previous);
            previous = Math.Max(previous - 1, values[i] - 1);
        }
        
        return result;
    }
}