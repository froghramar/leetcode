public class Solution {
    public void ReverseString(char[] s) {
        for (var i = 0; i < s.Length / 2; i++)
        {
            var otherIndex = s.Length - i - 1;
            (s[i], s[otherIndex]) = (s[otherIndex], s[i]);
        }
    }
}