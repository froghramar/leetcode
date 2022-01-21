public class Solution {
    public int[][] UpdateMatrix(int[][] mat)
    {
        var res = new int[mat.Length][];
        for (var i = 0; i < res.Length; i++)
        {
            res[i] = new int[mat[i].Length];
        }

        var queue = new Queue<Tuple<int, int>>();
        var visited = new bool[mat.Length, mat[0].Length];
        for (var i = 0; i < mat.Length; i++)
        {
            for (var j = 0; j < mat[i].Length; j++)
            {
                if (mat[i][j] == 0)
                {
                    SetValue(i, j, 0);
                }
            }
        }

        while (queue.Any())
        {
            var (i, j) = queue.Dequeue();
            var newValue = res[i][j] + 1;
            SetValue(i, j - 1, newValue);
            SetValue(i, j + 1, newValue);
            SetValue(i - 1, j, newValue);
            SetValue(i + 1, j, newValue);
        }
        
        void SetValue(int i, int j, int value)
        {
            if (i < 0 || i >= mat.Length || j < 0 || j >= mat[0].Length || visited[i, j])
            {
                return;
            }
            
            queue.Enqueue(new Tuple<int, int>(i, j));
            res[i][j] = value;
            visited[i, j] = true;
        }

        return res;
    }
}