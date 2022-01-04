public class Solution {
    public bool SearchMatrix(int[][] matrix, int target)
    {
        for (var row = matrix.Length - 1; row >= 0; row--)
        {
            if (matrix[row][0] <= target)
            {
                foreach (var num in matrix[row])
                {
                    if (target == num)
                    {
                        return true;
                    }

                    if (target < num)
                    {
                        return false;
                    }
                }

                return false;
            }
        }

        return false;
    }
}