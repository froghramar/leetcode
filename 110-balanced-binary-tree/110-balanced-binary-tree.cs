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
    public bool IsBalanced(TreeNode root)
    {
        return GetHeight(root).IsBalanced;
    }

    private (int Height, bool IsBalanced) GetHeight(TreeNode node)
    {
        if (node == null)
        {
            return (0, true);
        }

        var left = GetHeight(node.left);
        var right = GetHeight(node.right);

        var height = 1 + Math.Max(left.Height, right.Height);
        var balanced = left.IsBalanced && right.IsBalanced && Math.Abs(left.Height - right.Height) <= 1;
        return (height, balanced);
    }
}