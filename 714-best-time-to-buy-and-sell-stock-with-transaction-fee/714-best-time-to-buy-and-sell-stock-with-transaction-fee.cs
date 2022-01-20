public class Solution {
    public int MaxProfit(int[] prices, int fee)
    {
        var profitAfterLastBuy = - prices[0] - fee;
        var profitAfterLastSell = 0;

        var result = 0;
        for (var i = 1; i < prices.Length; i++)
        {
            var price = prices[i];
            
            (profitAfterLastBuy, profitAfterLastSell) = GetNewProfits(
                profitAfterLastBuy, profitAfterLastSell, price, fee);

            result = Math.Max(result, profitAfterLastBuy);
            result = Math.Max(result, profitAfterLastSell);
        }

        return result;
    }

    private (int, int) GetNewProfits(
        int profitAfterLastBuy,
        int profitAfterLastSell,
        int price,
        int fee)
    {
        var newProfitAfterLastBuy = Math.Max(profitAfterLastBuy, profitAfterLastSell - price - fee);

        var newProfitAfterLastSell = Math.Max(profitAfterLastSell, profitAfterLastBuy + price);
        
        return (newProfitAfterLastBuy, newProfitAfterLastSell);
    }
}