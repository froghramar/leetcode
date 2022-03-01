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
    public void Flatten(TreeNode root) {
        FlattenInternal(root);
    }

    private TreeNode FlattenInternal(TreeNode root)
    {
        if (root == null)
        {
            return null;
        }

        var rootLeft = root.left;
        var leftEnd = FlattenInternal(root.left);

        var rootRight = root.right;
        var rightEnd = FlattenInternal(root.right);

        var rootEnd = root;
        
        AddToRoot(rootLeft, leftEnd);
        AddToRoot(rootRight, rightEnd);
        root.left = null;

        void AddToRoot(TreeNode start, TreeNode end)
        {
            if (start == null)
            {
                return;
            }

            rootEnd.right = start;
            rootEnd = end;
        }

        return rootEnd;
    }
}