public class Solution {
    public int LongestValidParentheses(string s)
    {
        if (s.Length == 0)
        {
            return 0;
        }
        var set = new UnionFind(s.Length);
        
        for (var i = 1; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                continue;
            }
            
            if (s[i - 1] == '(')
            {
                set.Union(i - 1, i);

                var prev = i - 2;
                if (prev < 0)
                {
                    continue;
                }
                
                var prevLength = set.GetLength(prev);
                if (prevLength == 1)
                {
                    continue;
                }
                
                set.Union(prev, i);
            }
            else
            {
                var prevLength = set.GetLength(i - 1);
                if (prevLength == 1)
                {
                    continue;
                }

                var prevLast = i - prevLength - 1;
                if (prevLast < 0 || s[prevLast] == ')')
                {
                    continue;
                }
                
                set.Union(prevLast, i - 1);
                set.Union(i - 1, i);
            }
            
            var parent = set.Find(i);
            var prevParent = parent - 1;
            if (prevParent >= 0 && set.GetLength(prevParent) > 1)
            {
                set.Union(prevParent, parent);
            }
        }

        var result = set.GetMaxLength();
        return result == 1 ? 0 : result;
    }
}

public class UnionFind
{
    private int[] _parents;
    private int[] _length;

    public UnionFind(int length)
    {
        _parents = new int[length];
        _length = new int[length];

        for (var i = 0; i < length; i++)
        {
            _parents[i] = i;
            _length[i] = 1;
        }
    }

    public int GetMaxLength()
    {
        return _length.Max();
    }

    public int GetLength(int x)
    {
        var parent = Find(x);
        return _length[parent];
    }

    public int Find(int x)
    {
        if (x == _parents[x])
        {
            return x;
        }

        return _parents[x] = Find(_parents[x]);
    }

    public void Union(int x, int y)
    {
        var rootX = Find(x);
        var rootY = Find(y);

        if (rootX == rootY)
        {
            return;
        }

        _parents[rootY] = rootX;
        
        _length[rootX] += _length[rootY];
    }
}