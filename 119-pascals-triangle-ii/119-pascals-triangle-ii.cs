public class Solution {
    public IList<int> GetRow(int rowIndex)
    {
        if (rowIndex == 0)
        {
            return new[] { 1 };
        }
        
        var triangle = new int[rowIndex + 1][];
        triangle[0] = new[] { 1 };
        triangle[1] = new[] { 1, 1 };
        for (var i = 2; i <= rowIndex; i++)
        {
            triangle[i] = new int[i + 1];
            
            triangle[i][0] = 1;

            for (var j = 1; j < i; j++)
            {
                triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
            }
            
            triangle[i][i] = 1;
        }

        return triangle[rowIndex];
    }
}