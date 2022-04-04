public class AuthenticationManager {
    private readonly int _timeToLive;
    private Dictionary<string, int> _tokenStore = new ();

    public AuthenticationManager(int timeToLive)
    {
        _timeToLive = timeToLive;
    }
    
    public void Generate(string tokenId, int currentTime)
    {
        _tokenStore[tokenId] = currentTime + _timeToLive;
    }
    
    public void Renew(string tokenId, int currentTime) {
        if (_tokenStore.ContainsKey(tokenId) && currentTime < _tokenStore[tokenId])
        {
            _tokenStore[tokenId] = currentTime + _timeToLive;
        }
    }
    
    public int CountUnexpiredTokens(int currentTime)
    {
        return _tokenStore.Count(kv => kv.Value > currentTime);
    }
}

/**
 * Your AuthenticationManager object will be instantiated and called as such:
 * AuthenticationManager obj = new AuthenticationManager(timeToLive);
 * obj.Generate(tokenId,currentTime);
 * obj.Renew(tokenId,currentTime);
 * int param_3 = obj.CountUnexpiredTokens(currentTime);
 */