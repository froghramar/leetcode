/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public IList<int> Preorder(Node root)
    {
        var result = new List<int>();
        Traverse(root, result);
        return result;
    }

    void Traverse(Node node, IList<int> result)
    {
        if (node == null)
        {
            return;
        }
        
        result.Add(node.val);

        foreach (var child in node.children)
        {
            Traverse(child, result);
        }
    }
}