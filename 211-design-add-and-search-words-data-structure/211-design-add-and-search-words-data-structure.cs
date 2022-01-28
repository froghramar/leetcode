public class WordDictionary
{
    private TrieNode _trie;

    public WordDictionary()
    {
        _trie = new TrieNode();
    }
    
    public void AddWord(string word) {
        _trie.Insert(word);
    }
    
    public bool Search(string word)
    {
        return _trie.Search(word);
    }
}

public class TrieNode
{
    private const int R = 26;
    private TrieNode[] _links;
    private bool _isEnd = false;

    public TrieNode()
    {
        _links = new TrieNode[R];
    }

    public void Insert(string str, int charIndex = 0)
    {
        if (charIndex == str.Length)
        {
            _isEnd = true;
        }
        else
        {
            var linkIndex = str[charIndex] - 'a';
            _links[linkIndex] ??= new TrieNode();
            _links[linkIndex].Insert(str, charIndex + 1);
        }
    }

    public bool Search(string str, int charIndex = 0)
    {
        if (charIndex == str.Length)
        {
            return _isEnd;
        }

        var ch = str[charIndex];
        if (ch != '.')
        {
            var link = _links[ch - 'a'];
            return link != null && link.Search(str, charIndex + 1);
        }
        
        for (var i = 0; i < R; i++)
        {
            var link = _links[i];
            if (link != null && link.Search(str, charIndex + 1))
            {
                return true;
            }
        }
        
        return false;
    }
}