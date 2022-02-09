public class Solution {
    public IList<string> FindItinerary(IList<IList<string>> tickets)
    {
        var places = tickets.SelectMany(ticket => ticket).Distinct().ToList();
        var placeMap = new Dictionary<string, int>();
        var n = places.Count;
        
        var visited = new bool[tickets.Count];
        var ticketsStartAt = new List<int>[n];

        for (var i = 0; i < n; i++)
        {
            ticketsStartAt[i] = new List<int>();
            placeMap[places[i]] = i;
        }

        for (var i = 0; i < tickets.Count; i++)
        {
            var ticket = tickets[i];
            var source = FindIndex(placeMap, ticket[0]);
            ticketsStartAt[source].Add(i);
        }

        for (var i = 0; i < n; i++)
        {
            ticketsStartAt[i].Sort((t1, t2) => string.CompareOrdinal(tickets[t1][1], tickets[t2][1]));
        }
        
        var path = new int[tickets.Count + 1];
        Traverse(tickets, placeMap, ticketsStartAt, path, 
            FindIndex(placeMap, "JFK"), visited, 0);
        
        var result = path.Select(p => places[p]).ToList();
        return result;
    }

    private bool Traverse(
        IList<IList<string>> tickets, Dictionary<string, int> placeMap, List<int>[] ticketsStartAt, int[] path,
        int current, bool[] visited, int pathIndex)
    {
        path[pathIndex] = current;

        if (pathIndex == tickets.Count)
        {
            return true;
        }

        foreach (var i in ticketsStartAt[current])
        {
            if (visited[i])
            {
                continue;
            }

            visited[i] = true;

            var destination = FindIndex(placeMap, tickets[i][1]);
            if (Traverse(tickets, placeMap, ticketsStartAt, path, destination, visited, pathIndex + 1))
            {
                return true;
            }
            
            visited[i] = false;
        }

        return false;
    }

    private int FindIndex(Dictionary<string, int> placeMap, string place)
    {
        return placeMap[place];
    }
}