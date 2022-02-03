public class Solution {
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        var visited = new bool[rooms.Count];
        Traverse(rooms, 0, visited);

        for (var i = 0; i < rooms.Count; i++)
        {
            if (visited[i] is false)
            {
                return false;
            }
        }

        return true;
    }

    private void Traverse(IList<IList<int>> rooms, int current, bool[] visited)
    {
        if (visited[current])
        {
            return;
        }

        visited[current] = true;
        foreach (var other in rooms[current])
        {
            Traverse(rooms, other, visited);
        }
    }
}