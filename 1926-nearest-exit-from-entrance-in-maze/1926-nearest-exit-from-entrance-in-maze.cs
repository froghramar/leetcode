public class Solution {
    public int NearestExit(char[][] maze, int[] entrance)
    {
        var queue = new Queue<Tuple<int, int, int>>();
        var visited = new bool[maze.Length, maze[0].Length];

        var dxy = new[] {(0, 1), (0, -1), (-1, 0), (1, 0)};
        
        queue.Enqueue(new Tuple<int, int, int>(entrance[0], entrance[1], 0));
        visited[entrance[0], entrance[1]] = true;

        while (queue.Any())
        {
            var (i, j, d) = queue.Dequeue();

            foreach (var (dx, dy) in dxy)
            {
                var (r, c) = (i + dx, j + dy);
                
                if (r < 0 || r >= maze.Length || c < 0 || c >= maze[0].Length)
                {
                    if (d > 0)
                    {
                        return d;
                    }
                }
                else if (maze[r][c] == '.' && visited[r, c] is false)
                {
                    queue.Enqueue(new Tuple<int, int, int>(r, c, d + 1));
                    visited[r, c] = true;
                }
            }
        }

        return -1;
    }
}