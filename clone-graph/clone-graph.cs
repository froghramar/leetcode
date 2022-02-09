/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node)
    {
        if (node == null)
        {
            return null;
        }
        var nodes = new Node[101];
        return CloneGraphInternal(node, nodes);
    }

    private Node CloneGraphInternal(Node node, Node[] nodes)
    {
        if (nodes[node.val] != null)
        {
            return nodes[node.val];
        }

        var clone = new Node(node.val);
        nodes[node.val] = clone;
        
        var neighbors = node.neighbors.Select(n => CloneGraphInternal(n, nodes)).ToList();
        clone.neighbors = neighbors;

        return clone;
    }
    
}