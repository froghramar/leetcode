public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
    {
        var visited = new bool[image.Length, image[0].Length];
        FloodFill(image, sr, sc, image[sr][sc], newColor, visited);
        return image;
    }
    
    private void FloodFill(int[][] image, int r, int c, int oldColor, int newColor, bool[,] visited)
    {
        if (r < 0 || r >= image.Length || c < 0 || c >= image[0].Length || visited[r,c] || image[r][c] != oldColor)
        {
            return;
        }

        image[r][c] = newColor;
        visited[r, c] = true;

        FloodFill(image, r, c - 1, oldColor, newColor, visited);
        FloodFill(image, r, c + 1, oldColor, newColor, visited);
        FloodFill(image, r - 1, c, oldColor, newColor, visited);
        FloodFill(image, r + 1, c, oldColor, newColor, visited);
    }
}