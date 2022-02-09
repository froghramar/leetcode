/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public IList<IList<int>> LevelOrder(Node root)
    {
        var result = new List<IList<int>>();
        if (root == null)
        {
            return result;
        }

        var queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Any())
        {
            var next = new List<Node>();
            var current = new List<int>();
            
            while (queue.Any())
            {
                var node = queue.Dequeue();
                current.Add(node.val);

                if (node.children is not null)
                {
                    next.AddRange(node.children);
                }
            }
            
            result.Add(current);
            foreach (var node in next)
            {
                queue.Enqueue(node);
            }
        }

        return result;
    }
}