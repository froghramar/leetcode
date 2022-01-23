public class Solution {
    public IList<string> LetterCasePermutation(string s) {
        return LetterCasePermutationInternal(s, string.Empty);
    }
    
    private IList<string> LetterCasePermutationInternal(string s, string previous) {
        if (previous.Length == s.Length)
        {
            return new List<string> { previous };
        }

        if (char.IsDigit(s[previous.Length]))
        {
            return LetterCasePermutationInternal(s, previous + s[previous.Length]);
        }
        
        var result = new List<string>();
        result.AddRange(LetterCasePermutationInternal(s, previous + char.ToUpper(s[previous.Length])));
        result.AddRange(LetterCasePermutationInternal(s, previous + char.ToLower(s[previous.Length])));

        return result;
    }
}