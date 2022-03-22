public class Solution {
    public bool FindRotation(int[][] mat, int[][] target) {
        for (var t = 0; t < 4; t++)
        {
            if (IsEqual(mat, target))
            {
                return true;
            }
            
            Rotate(mat);
        }

        return false;
    }

    private static bool IsEqual(int[][] mat, int[][] target)
    {
        for (var i = 0; i < mat.Length; i++)
        {
            for (var j = 0; j < mat.Length; j++)
            {
                if (mat[i][j] != target[i][j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static void Rotate(int[][] mat)
    {
        var copy = new int[mat.Length, mat.Length];
        for (var i = 0; i < mat.Length; i++)
        {
            for (var j = 0; j < mat.Length; j++)
            {
                copy[i, j] = mat[i][j];
            }
        }
        
        for (var i = 0; i < mat.Length; i++)
        {
            for (var j = 0; j < mat.Length; j++)
            {
                mat[j][mat.Length - i - 1] = copy[i, j];
            }
        }
    }
}