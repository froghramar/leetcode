public class Solution {
    public int MaxSideLength(int[][] mat, int threshold)
    {
        var cum = new int[mat.Length][];
        for (var i = 0; i < mat.Length; i++)
        {
            cum[i] = new int[mat[i].Length];

            var rowSum = 0;
            for (var j = 0; j < mat[i].Length; j++)
            {
                rowSum += mat[i][j];
                cum[i][j] = rowSum + GetCum(i - 1, j);
            }
        }

        var result = 0;
        for (var i = 0; i < mat.Length; i++)
        {
            for (var j = 0; j < mat[i].Length; j++)
            {
                for (var k = 0; k < mat.Length; k++)
                {
                    int ri = i + k, rj = j + k;
                    if (ri >= mat.Length || rj >= mat[ri].Length)
                    {
                        continue;
                    }

                    var val = GetCum(ri, rj) - GetCum(ri, j - 1) - GetCum(i - 1, rj) + GetCum(i - 1, j - 1);
                    if (val <= threshold)
                    {
                        result = Math.Max(result, k + 1);
                    }
                }
            }
        }
        
        return result;

        int GetCum(int i, int j)
        {
            if (i < 0 || j < 0)
            {
                return 0;
            }

            return cum[i][j];
        }
    }
}