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
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        return BuildTreeInternal(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
    }

    private TreeNode BuildTreeInternal(int[] inorder, int inOrderL, int inOrderR, int[] postorder, int postOrderL, int postOrderR)
    {
        if (inOrderL > inOrderR)
        {
            return null;
        }

        var rootVal = postorder[postOrderR];
        var root = new TreeNode(rootVal);
        var rootPos = Array.FindIndex(inorder, inOrderL, x => x == rootVal);
        var leftLength = rootPos - inOrderL;

        root.left = BuildTreeInternal(inorder, inOrderL, inOrderL + leftLength - 1, postorder, postOrderL,
            postOrderL + leftLength - 1);
        root.right = BuildTreeInternal(inorder, inOrderL + leftLength + 1, inOrderR, postorder,
            postOrderL + leftLength, postOrderR - 1);

        return root;
    }
    
}