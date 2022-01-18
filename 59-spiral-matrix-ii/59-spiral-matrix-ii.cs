public class Solution {
    public int[][] GenerateMatrix(int n)
    {
        var result = new int[n][];

        for (var i = 0; i < n; i++)
        {
            result[i] = new int[n];
        }

        int x = 0, y = 0, d = 0;
        for (var m = 1; m <= n * n; m++)
        {
            result[x][y] = m;

            var (newX, newY) = Move();
            if (IsInRange(newX, newY) is false || result[newX][newY] != 0)
            {
                d = (d + 1) % 4;
                (x, y) = Move();
            }
            else
            {
                (x, y) = (newX, newY);
            }
        }

        (int, int) Move()
        {
            return d switch
            {
                0 => (x, y + 1),
                1 => (x + 1, y),
                2 => (x, y - 1),
                3 => (x - 1, y)
            };
        }

        bool IsInRange(int p, int q)
        {
            return p >= 0 && p < n && q >= 0 && q < n;
        }

        return result;
    }
}