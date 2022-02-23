public class Solution {
    public int LengthOfLastWord(string s)
    {
        var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return words[^1].Length;
    }
}