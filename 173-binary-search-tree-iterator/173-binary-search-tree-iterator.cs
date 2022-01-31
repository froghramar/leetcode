public class BSTIterator
{
    private Stack<TreeNode> _stack;

    public BSTIterator(TreeNode root)
    {
        _stack = new Stack<TreeNode>();
        Push(root);
    }

    public int Next()
    {
        var current = _stack.Pop();
        Push(current.right);
        
        return current.val;
    }
    
    public bool HasNext()
    {
        return _stack.Any();
    }
    
    private void Push(TreeNode node)
    {
        var current = node;
        while (current != null)
        {
            _stack.Push(current);
            
            var next = current.left;
            current.left = null;
            current = next;
        }
    }
}