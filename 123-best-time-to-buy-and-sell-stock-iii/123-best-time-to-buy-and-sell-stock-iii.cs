public class Solution {
    public int MaxProfit(int[] prices)
    {
        int singleTake = 0, doubleTake = 0, minPrice = prices[0], singleTakeMinusPrice = -1_000_000;
        
        for (var i = 1; i < prices.Length; i++)
        {
            singleTake = Math.Max(singleTake, prices[i] - minPrice);
            doubleTake = Math.Max(doubleTake, prices[i] + singleTakeMinusPrice);

            minPrice = Math.Min(minPrice, prices[i]);
            singleTakeMinusPrice = Math.Max(singleTakeMinusPrice, singleTake - prices[i]);
        }
        
        return Math.Max(singleTake, doubleTake);
    }
}