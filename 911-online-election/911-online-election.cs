public class TopVotedCandidate
{
    private int[] _winners;
    private int[] _times;
    
    public TopVotedCandidate(int[] persons, int[] times)
    {
        _winners = new int[persons.Length];
        _times = times;
        
        var count = new int[persons.Length];
        int maxCount = 0, winner = -1;
        for (var i = 0; i < persons.Length; i++)
        {
            var person = persons[i];
            count[person]++;
            if (count[person] >= maxCount)
            {
                maxCount = count[person];
                winner = person;
            }

            _winners[i] = winner;
        }
    }
    
    public int Q(int t)
    {
        int l = 0, r = _times.Length - 1;
        while (l < r)
        {
            var m = (l + r + 1) / 2;
            if (t >= _times[m])
            {
                l = m;
            }
            else
            {
                r = m - 1;
            }
        }

        return _winners[l];
    }
}

/**
 * Your TopVotedCandidate object will be instantiated and called as such:
 * TopVotedCandidate obj = new TopVotedCandidate(persons, times);
 * int param_1 = obj.Q(t);
 */