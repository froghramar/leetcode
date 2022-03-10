public class Solution {
    public bool IsBipartite(int[][] graph)
    {
        var n = graph.Length;
        var colors = new int[n];
        var result = true;
        var op = new List<int>[n];
        for (var i = 0; i < n; i++)
        {
            op[i] = new List<int>();
        }

        for (var i = 0; i < n; i++)
        {
            foreach (var j in graph[i])
            {
                op[i].Add(j);
            }
        }
        
        for (var i = 0; i < n; i++)
        {
            if (colors[i] == 0)
            {
                PossibleBipartitionInternal(i, 1, colors, op, ref result);
            }
        }
        return result;
    }

    private static void PossibleBipartitionInternal(int i, int color, int[] colors, List<int>[] op, ref bool result)
    {
        if (colors[i] != 0)
        {
            if (colors[i] != color)
            {
                result = false;
            }
            
            return;
        }

        colors[i] = color;

        var otherColor = color == 1 ? 2 : 1;
        foreach (var j in op[i])
        {
            PossibleBipartitionInternal(j, otherColor, colors, op, ref result);
        }
    }
}