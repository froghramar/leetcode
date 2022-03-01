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
    public int MaxPathSum(TreeNode root)
    {
        var result = int.MinValue;
        FindMaxPath(root, ref result);
        return result;
    }

    private int FindMaxPath(TreeNode node, ref int result)
    {
        if (node == null)
        {
            return 0;
        }

        var leftPath = FindMaxPath(node.left, ref result);
        var rightPath = FindMaxPath(node.right, ref result);

        result = Math.Max(result, node.val + leftPath + rightPath);

        return Math.Max(0, node.val + Math.Max(leftPath, rightPath));
    }
}