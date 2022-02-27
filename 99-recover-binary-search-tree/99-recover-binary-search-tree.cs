/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    private TreeNode _first;
    private TreeNode _lastSeen;
    private TreeNode _second;

    public void RecoverTree(TreeNode root)
    {
        _lastSeen = new TreeNode(int.MinValue);

        Traverse(root);

        (_second.val, _first.val) = (_first.val, _second.val);
    }

    private void Traverse(TreeNode node)
    {
        if (node == null)
        {
            return;
        }

        Traverse(node.left);

        if (node.val >= _lastSeen.val)
        {
            _lastSeen = node;
        }
        else
        {
            if (_first == null)
            {
                _first = _lastSeen;
                _second = node;
                _lastSeen = node;
            }
            else
            {
                _second = node;
                return;
            }
        }

        Traverse(node.right);
    }
}