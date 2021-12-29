/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    
    public Node Connect(Node root)
    {
        if (root == null)
        {
            return null;
        }
        
        var nodes = new List<Node>();
        var queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Any())
        {
            var node = queue.Dequeue();
            nodes.Add(node);

            if (node.left != null)
            {
                queue.Enqueue(node.left);
            }

            if (node.right != null)
            {
                queue.Enqueue(node.right);
            }
        }
        
        for (var nodeIndex = 0; nodeIndex < nodes.Count; nodeIndex++)
        {
            nodes[nodeIndex].next = LastNodeOfLevel(nodeIndex + 1) ? null : nodes[nodeIndex + 1];
        }

        return root;
    }

    private static bool LastNodeOfLevel(int nodeIndex)
    {
        // Check if all bits are 1.
        return ((nodeIndex + 1) & nodeIndex) == 0;
    }
}