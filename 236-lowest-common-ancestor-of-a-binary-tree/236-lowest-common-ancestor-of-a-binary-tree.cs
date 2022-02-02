/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution
{
    private TreeNode _result;

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        HasNode(root, p, q);
        return _result;
    }

    private bool HasNode(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null)
        {
            return false;
        }

        var left = HasNode(root.left, p, q) ? 1 : 0;
        var right = HasNode(root.right, p, q) ? 1 : 0;
        var mid = (root == p || root == q) ? 1 : 0;

        var total = left + right + mid;
        if (total >= 2)
        {
            _result = root;
        }
        
        return total > 0;
    }
}