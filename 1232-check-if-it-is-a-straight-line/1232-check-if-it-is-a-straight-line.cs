public class Solution {
    public bool CheckStraightLine(int[][] coordinates)
    {
        for (var i = 2; i < coordinates.Length; i++)
        {
            if (IsInLine(
                    coordinates[0][0], coordinates[0][1], 
                    coordinates[1][0], coordinates[1][1], 
                    coordinates[i][0], coordinates[i][1]) is false)
            {
                return false;
            }
        }
        return true;
    }

    private static bool IsInLine(int x1, int y1, int x2, int y2, int x3, int y3)
    {
        return (x1 - x2) * (y2 - y3) == (y1 - y2) * (x2 - x3);
    }
}