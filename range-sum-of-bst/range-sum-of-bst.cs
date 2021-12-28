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
    public int RangeSumBST(TreeNode root, int low, int high) {
        if (root == null)
        {
            return 0;
        }

        var result = 0;
        if (root.val >= low && root.val <= high)
        {
            result += root.val;
        }

        result += RangeSumBST(root.left, low, high);
        result += RangeSumBST(root.right, low, high);

        return result;
    }
}