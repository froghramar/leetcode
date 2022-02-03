public class Solution {
    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0)
        {
            return new List<string>();
        }
        
        var chars = new []
        {
            string.Empty,
            string.Empty, "abc", "def",
            "ghi", "jkl", "mno",
            "pqrs", "tuv", "wxyz"
        };

        var result = new List<string> { string.Empty };

        foreach (var digitChar in digits)
        {
            var digit = digitChar - '0';

            var prev = result;
            result = new List<string>();

            foreach (var str in prev)
            {
                foreach (var ch in chars[digit])
                {
                    result.Add(str + ch);
                }
            }
        }

        return result;
    }
}