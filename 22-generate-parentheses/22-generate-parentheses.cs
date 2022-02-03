public class Solution {
    public IList<string> GenerateParenthesis(int n)
    {
        var result = GenerateParenthesisInternal(n, 0, 0, string.Empty);
        return result;
    }

    private List<string> GenerateParenthesisInternal(int n, int left, int right, string pre)
    {
        if (left + right == 2 * n)
        {
            return new List<string> {pre};
        }

        var result = new List<string>();
        if (left < n)
        {
            result.AddRange(GenerateParenthesisInternal(n, left + 1, right, pre + "("));
        }
        
        if (right < left)
        {
            result.AddRange(GenerateParenthesisInternal(n, left, right + 1, pre + ")"));
        }

        return result;
    }
}