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
public class Solution {
    public TreeNode IncreasingBST(TreeNode root)
    {
        var (first, _) = IncreasingBSTInternal(root);
        return first;
    }

    private (TreeNode first, TreeNode last) IncreasingBSTInternal(TreeNode root)
    {
        TreeNode first = root, last = root;
        if (root.left is not null)
        {
            var (leftFirst, leftLast) = IncreasingBSTInternal(root.left);
            root.left = null;
            first = leftFirst;
            leftLast.right = root;
        }

        if (root.right is not null)
        {
            var (rightFirst, rightLast) = IncreasingBSTInternal(root.right);
            root.right = rightFirst;
            last = rightLast;
        }
        
        return (first, last);
    }
}