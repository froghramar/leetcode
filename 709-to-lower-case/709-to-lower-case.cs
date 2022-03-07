public class Solution {
    public string ToLowerCase(string s)
    {
        return new string(s.Select(char.ToLower).ToArray());
    }
}