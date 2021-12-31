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
    public int MaxAncestorDiff(TreeNode root)
    {
        return MaxAncestorDiff(root, root.val, root.val);
    }
    
    private int MaxAncestorDiff(TreeNode node, int maxValue, int minValue)
    {
        if (node == null)
        {
            return 0;
        }

        maxValue = Math.Max(maxValue, node.val);
        minValue = Math.Min(minValue, node.val);

        return Math.Max(
            Math.Max(maxValue - minValue, MaxAncestorDiff(node.left, maxValue, minValue)),
            MaxAncestorDiff(node.right, maxValue, minValue));
    }
}