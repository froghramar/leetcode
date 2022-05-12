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
    public IList<string> BinaryTreePaths(TreeNode root) {
        if (root == null)
        {
            return new List<string>();
        }

        if (root.left == null && root.right == null)
        {
            return new List<string> {root.val.ToString()};
        }

        var result = new List<string>();
        result.AddRange(BinaryTreePaths(root.left));
        result.AddRange(BinaryTreePaths(root.right));

        return result.Select(r => $"{root.val}->{r}").ToList();
    }
}