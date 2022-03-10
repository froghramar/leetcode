public class Solution {
    public bool PossibleBipartition(int n, int[][] dislikes)
    {
        var colors = new int[n];
        var result = true;
        var op = new List<int>[n];
        for (var i = 0; i < n; i++)
        {
            op[i] = new List<int>();
        }

        foreach (var dislike in dislikes)
        {
            op[dislike[0] - 1].Add(dislike[1] - 1);
            op[dislike[1] - 1].Add(dislike[0] - 1);
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