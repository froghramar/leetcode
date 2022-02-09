public class Solution {
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        var result = new List<IList<int>>();
        Traverse(new List<int>{ 0 }, result, graph);
        return result;
    }

    void Traverse(IList<int> current, IList<IList<int>> result, int[][] graph)
    {
        var last = current[^1];
        if (last == graph.Length - 1)
        {
            result.Add(current);
            return;
        }

        foreach (var t in graph[last])
        {
            var newCurrent = current.ToList();
            newCurrent.Add(t);
            Traverse(newCurrent, result, graph);
        }
    }
}