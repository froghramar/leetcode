public class Solution {
    public int TitleToNumber(string columnTitle)
    {
        int multiply = 1, res = 0;
        for (var i = columnTitle.Length - 1; i >= 0; i--)
        {
            res += (columnTitle[i] - 'A' + 1) * multiply;
            multiply *= 26;
        }

        return res;
    }
}