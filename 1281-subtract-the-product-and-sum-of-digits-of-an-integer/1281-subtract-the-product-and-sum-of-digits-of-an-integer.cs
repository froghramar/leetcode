public class Solution {
    public int SubtractProductAndSum(int n)
    {
        var digits = n.ToString().Select(ch => ch - '0');
        int sum = 0, product = 1;
        foreach (var digit in digits)
        {
            sum += digit;
            product *= digit;
        }
        
        return product - sum;
    }
}