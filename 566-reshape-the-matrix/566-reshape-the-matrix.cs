public class Solution {
    public int[][] MatrixReshape(int[][] mat, int r, int c)
    {
        var matR = mat.Length;
        var matC = mat[0].Length;

        if (matR * matC != r * c)
        {
            return mat;
        }

        var result = new int[r][];
        int currentR = 0, currentC = 0;
        for (var i = 0; i < r; i++)
        {
            result[i] = new int[c];
            for (var j = 0; j < c; j++)
            {
                result[i][j] = mat[currentR][currentC];
                MoveNext();
            }
        }

        void MoveNext()
        {
            if (currentC == matC - 1)
            {
                currentC = 0;
                currentR++;
            }
            else
            {
                currentC++;
            }
        }

        return result;
    }
}