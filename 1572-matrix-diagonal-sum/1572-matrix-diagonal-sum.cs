public class Solution {
    public int DiagonalSum(int[][] mat)
    {
        var result = 0;
        for (var i = 0; i < mat.Length; i++)
        {
            var primaryJ = i;
            var secondaryJ = mat.Length - i - 1;

            result += mat[i][primaryJ];

            if (secondaryJ != primaryJ)
            {
                result += mat[i][secondaryJ];
            }
        }

        return result;
    }
}