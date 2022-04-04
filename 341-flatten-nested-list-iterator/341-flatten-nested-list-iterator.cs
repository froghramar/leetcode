/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class NestedIterator {
    Queue<int> _queue;

    public NestedIterator(IList<NestedInteger> nestedList)
    {
        _queue = new Queue<int>();
        Traverse(nestedList);
    }

    public bool HasNext()
    {
        return _queue.Any();
    }

    public int Next()
    {
        return _queue.Dequeue();
    }
    
    private void Traverse(IList<NestedInteger> nestedList)
    {
        foreach (var nestedInteger in nestedList)
        {
            if (nestedInteger.IsInteger()) {
                _queue.Enqueue(nestedInteger.GetInteger());
            }
            else {
                Traverse(nestedInteger.GetList());
            }
        }
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */