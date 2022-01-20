public class Solution {
    public int MaxProfit(int[] prices)
    {
        var profitAfterLastBuy = -prices[0];
        var lastBuyAmount = prices[0];
        var profitAfterLastSell = 0;
        var profitAfterLastCooldown = 0;

        var result = 0;
        for (var i = 1; i < prices.Length; i++)
        {
            var price = prices[i];
            
            (profitAfterLastBuy, profitAfterLastSell, profitAfterLastCooldown) = GetNewProfits(
                profitAfterLastBuy, lastBuyAmount, profitAfterLastSell, profitAfterLastCooldown, price);
            lastBuyAmount = price;

            result = Math.Max(result, profitAfterLastBuy);
            result = Math.Max(result, profitAfterLastSell);
            result = Math.Max(result, profitAfterLastCooldown);
        }

        return result;
    }

    private (int, int, int) GetNewProfits(
        int profitAfterLastBuy,
        int lastBuyAmount,
        int profitAfterLastSell,
        int profitAfterLastCooldown,
        int price)
    {
        var newProfitAfterLastBuy = profitAfterLastCooldown - price;

        var newProfitAfterLastSell = Math.Max(profitAfterLastSell + price - lastBuyAmount, profitAfterLastBuy + price);

        var newProfitAfterLastCooldown = Math.Max(profitAfterLastCooldown, profitAfterLastSell);
        
        return (newProfitAfterLastBuy, newProfitAfterLastSell, newProfitAfterLastCooldown);
    }
}