using System.Text;

public class Solution {
    public string GetSmallestString(int n, int k)
    {
        var sb = new StringBuilder();
        var canMake = n * 26;

        while (n-- > 0)
        {
            canMake -= 26;
            var code = Math.Max(k - canMake, 1);
            sb.Append((char) (code + 'a' - 1));
            k -= code;
        }
        
        return sb.ToString();
    }
}