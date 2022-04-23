public class Codec
{
    private Dictionary<int, string> _urlMap = new ();
    private Random _random = new();
    private string _baseUrl = "https://tiny.url/r/";

    // Encodes a URL to a shortened URL
    public string encode(string longUrl)
    {
        var code = _random.Next(100000);
        _urlMap[code] = longUrl;
        return $"{_baseUrl}{code}";
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl) {
        var code = new Uri(shortUrl).Segments.Last();
        return _urlMap[int.Parse(code)];
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));