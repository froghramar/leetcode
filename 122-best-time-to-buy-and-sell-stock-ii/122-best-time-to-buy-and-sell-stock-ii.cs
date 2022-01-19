public class Solution {
    public int MaxProfit(int[] prices)
    {
        int result = 0, prevMin = int.MaxValue;
        
        foreach (var price in prices)
        {
            if (price <= prevMin)
            {
                prevMin = price;
            }
            else
            {
                result += price - prevMin;
                prevMin = price;
            }
        }

        return result;
    }
}