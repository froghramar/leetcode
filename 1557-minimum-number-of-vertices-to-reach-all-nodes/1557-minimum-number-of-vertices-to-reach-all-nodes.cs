public class Solution {
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
    {
        var hasEdgesTo = new bool[n];
        foreach (var edge in edges)
        {
            hasEdgesTo[edge[1]] = true;
        }

        var result = new List<int>();

        for (var i = 0; i < n; i++)
        {
            if (hasEdgesTo[i] is false)
            {
                result.Add(i);
            }
        }
        
        return result;
    }
}