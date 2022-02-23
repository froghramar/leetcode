public class Solution {
    public IList<int> SpiralOrder(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        var visited = new bool[m, n];
        var (i, j, d) = (0, 0, 0);

        var result = new List<int>();
        while (IsValid(i, j, m, n) && visited[i, j] is false)
        {
            result.Add(matrix[i][j]);
            visited[i, j] = true;

            var (ri, rj) = FindNext(i, j, d);
            if (!IsValid(ri, rj, m, n) || visited[ri, rj])
            {
                d = (d + 1) % 4;
                (ri, rj) = FindNext(i, j, d);
            }

            (i, j) = (ri, rj);
        }

        return result;
    }

    private bool IsValid(int i, int j, int m, int n)
    {
        return i >= 0 && i < m && j >= 0 && j < n;
    }

    private (int, int) FindNext(int i, int j, int d)
    {
        return d switch
        {
            0 => (i, j + 1),
            1 => (i + 1, j),
            2 => (i, j - 1),
            3 => (i - 1, j),
        };
    }
}