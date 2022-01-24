public class Solution {
    public IList<IList<int>> Generate(int numRows)
    {
        var result = new List<IList<int>>();

        for (var r = 0; r < numRows; r++)
        {
            result.Add(new List<int>());
            for (var c = 0; c <= r; c++)
            {
                if (c == 0)
                {
                    result[r].Add(1);
                }
                else if (c == r)
                {
                    result[r].Add(1);
                }
                else
                {
                    result[r].Add(result[r - 1][c - 1] + result[r - 1][c]);
                }
            }
        }

        return result;
    }
}