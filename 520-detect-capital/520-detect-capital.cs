public class Solution {
    public bool DetectCapitalUse(string word)
    {
        var allCapitalized = word.ToUpper();
        var firstCapitalized = char.ToUpper(word[0]) + word.Substring(1).ToLower();
        var allLowered = word.ToLower();

        return word == allCapitalized || word == firstCapitalized || word == allLowered;
    }
}