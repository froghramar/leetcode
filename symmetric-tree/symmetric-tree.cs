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
    public bool IsSymmetric(TreeNode root)
    {
        Swap(root.left);

        return IsSame(root.left, root.right);
    }
    
    private void Swap(TreeNode root)
    {
        if (root == null) return;

        (root.left, root.right) = (root.right, root.left);
        
        Swap(root.left);
        Swap(root.right);
    }

    private bool IsSame(TreeNode left, TreeNode right)
    {
        if (right == null && left == null) return true;

        if (right == null || left == null) return false;

        return right.val == left.val && IsSame(left.left, right.left) && IsSame(left.right, right.right);
    }
}