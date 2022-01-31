public class Solution {
    public int MaximumWealth(int[][] accounts)
    {
        var result = 0;

        foreach (var account in accounts)
        {
            result = Math.Max(result, account.Sum());
        }
        
        return result;
    }
}