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
    public TreeNode ConvertBST(TreeNode root)
    {
        ConvertBSTInternal(root, 0);
        return root;
    }

    private int ConvertBSTInternal(TreeNode root, int seed)
    {
        if (root == null)
        {
            return 0;
        }

        var rightSum = ConvertBSTInternal(root.right, seed);
        var leftSum = ConvertBSTInternal(root.left, rightSum + seed + root.val);
        var total = rightSum + leftSum + root.val;

        root.val += rightSum + seed;
        
        return total;
    }
}