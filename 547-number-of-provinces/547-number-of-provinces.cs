public class Solution {
    public int FindCircleNum(int[][] isConnected)
    {
        var count = 0;
        var visited = new bool[isConnected.Length];

        for (var i = 0; i < isConnected.Length; i++)
        {
            CountCircleNum(isConnected, i, ref count, true, visited);
        }
        
        return count;
    }

    private void CountCircleNum(int[][] isConnected, int x, ref int count, bool startNew, bool[] visited)
    {
        if (visited[x])
        {
            return;
        }

        visited[x] = true;

        if (startNew)
        {
            count++;
        }

        for (var i = 0; i < isConnected.Length; i++)
        {
            if (x != i && isConnected[x][i] == 1) CountCircleNum(isConnected, i, ref count, false, visited);
        }
    }
}