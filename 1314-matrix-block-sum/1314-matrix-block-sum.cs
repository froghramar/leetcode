public class Solution {
    public int[][] MatrixBlockSum(int[][] mat, int k)
    {
        var res = new int[mat.Length][];

        for (var i = 0; i < mat.Length; i++)
        {
            res[i] = new int[mat[i].Length];
        }

        for (var i = 0; i < res.Length; i++)
        {
            for (var j = 0; j < res[i].Length; j++)
            {
                for (var r = i - k; r <= i + k; r++)
                {
                    for (var c = j - k; c <= j + k; c++)
                    {
                        if (r >= 0 && r < res.Length && c >= 0 && c < res[r].Length)
                        {
                            res[i][j] += mat[r][c];
                        }
                    }
                }
            }
        }

        return res;
    }
}