public class Solution {
    public Node Connect(Node root)
    {
        ConnectInternal(root, null);
        return root;
    }

    private void ConnectInternal(Node current, Node next)
    {
        if (current == null)
        {
            return;
        }

        current.next = next;

        Node nextNext = null;
        while (next != null && nextNext == null)
        {
            nextNext = next.left ?? next.right;
            next = next.next;
        }
        
        ConnectInternal(current.right, nextNext);
        ConnectInternal(current.left, current.right ?? nextNext);
    }
}