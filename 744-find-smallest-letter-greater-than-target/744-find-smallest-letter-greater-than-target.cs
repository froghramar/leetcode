public class Solution {
    public char NextGreatestLetter(char[] letters, char target)
    {
        int l = 0, r = letters.Length - 1;
        while (l < r)
        {
            var m = l + (r - l) / 2;
            if (IsGreater(letters[m], target))
            {
                r = m;
            }
            else
            {
                l = m + 1;
            }
        }

        return target >= letters[^1] ? letters[0] : letters[l];
    }

    private static bool IsGreater(char ch, char compare)
    {
        return ch > compare;
    }
}