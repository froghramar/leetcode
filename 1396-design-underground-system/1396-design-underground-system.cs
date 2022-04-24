public class UndergroundSystem
{

    private Dictionary<int, Tuple<string, int>> _starts = new();
    private Dictionary<string, Dictionary<string, Tuple<long, int>>> _distances = new();

    public UndergroundSystem() {
        
    }
    
    public void CheckIn(int id, string stationName, int t) {
        _starts.Add(id, new Tuple<string, int>(stationName, t));
    }
    
    public void CheckOut(int id, string stationName, int t)
    {
        var (startStation, startTime) = _starts[id];

        if (_distances.ContainsKey(startStation) is false)
        {
            _distances[startStation] = new Dictionary<string, Tuple<long, int>>();
        }

        if (_distances[startStation].ContainsKey(stationName) is false)
        {
            _distances[startStation].Add(stationName, new Tuple<long, int>(t - startTime, 1));
        }
        else
        {
            var (totalDistance, count) = _distances[startStation][stationName];
            _distances[startStation][stationName] = new Tuple<long, int>(totalDistance + t - startTime, count + 1);
        }

        _starts.Remove(id);
    }
    
    public double GetAverageTime(string startStation, string endStation) {
        var (totalDistance, count) = _distances[startStation][endStation];
        return totalDistance / (double) count;
    }
}

/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */