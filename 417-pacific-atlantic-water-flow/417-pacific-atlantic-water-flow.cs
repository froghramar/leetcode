public class Solution
{
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        int m = heights.Length, n = heights[0].Length;
        bool[,] pacific = new bool[m, n], atlantic = new bool[m, n];
        
        Queue<Tuple<int, int>> pacificQueue = new (), atlanticQueue = new ();

        for (var j = 0; j < n; j++)
        {
            AddToPacific(0, j);
            AddToAtlantic(m - 1, j);
        }

        for (var i = 0; i < m; i++)
        {
            AddToPacific(i, 0);
            AddToAtlantic(i, n - 1);
        }

        var dxy = new[] {new[] {0, 1}, new[] {0, -1}, new[] {1, 0}, new[] {-1, 0}};
        while (pacificQueue.Any())
        {
            var (i, j) = pacificQueue.Dequeue();
            foreach (var d in dxy)
            {
                var (r, c) = (i + d[0], j + d[1]);
                if (r >= 0 && r < m && c >= 0 && c < n && heights[r][c] >= heights[i][j])
                {
                    AddToPacific(r, c);
                }
            }
        }

        var res = new List<IList<int>>();
        while (atlanticQueue.Any())
        {
            var (i, j) = atlanticQueue.Dequeue();
            if (pacific[i, j])
            {
                res.Add(new List<int> {i, j});
            }

            foreach (var d in dxy)
            {
                var (r, c) = (i + d[0], j + d[1]);
                if (r >= 0 && r < m && c >= 0 && c < n && heights[r][c] >= heights[i][j])
                {
                    AddToAtlantic(r, c);
                }
            }
        }

        void AddToPacific(int i, int j)
        {
            if (pacific[i, j])
            {
                return;
            }

            pacific[i, j] = true;
            pacificQueue.Enqueue(new Tuple<int, int>(i, j));
        }
        
        void AddToAtlantic(int i, int j)
        {
            if (atlantic[i, j])
            {
                return;
            }

            atlantic[i, j] = true;
            atlanticQueue.Enqueue(new Tuple<int, int>(i, j));
        }

        return res;
    }
}