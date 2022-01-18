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
    public bool IsValidBST(TreeNode root)
    {
        return IsValidBST(root, int.MinValue, int.MaxValue);
    }
    
    private static bool IsValidBST(TreeNode root, long lowerBound, long upperBound) {
        if (root == null)
        {
            return true;
        }

        if (root.val < lowerBound || root.val > upperBound)
        {
            return false;
        }

        return IsValidBST(root.left, lowerBound, root.val - 1L)
               && IsValidBST(root.right, root.val + 1L, upperBound);
    }
}