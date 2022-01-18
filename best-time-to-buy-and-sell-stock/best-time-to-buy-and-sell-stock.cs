public class Solution {
    public int MaxProfit(int[] prices)
    {
        var previousMin = int.MaxValue;
        var result = 0;
        
        foreach (var price in prices)
        {
            var profit = price - previousMin;
            result = Math.Max(result, profit);
            previousMin = Math.Min(previousMin, price);
        }

        return result;
    }
}