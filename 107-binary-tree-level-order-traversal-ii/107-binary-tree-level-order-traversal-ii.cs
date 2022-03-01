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
    public IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        var result = new List<IList<int>>();
        Traverse(root, 0, result);
        result.Reverse();
        return result;
    }

    private void Traverse(TreeNode node, int level, IList<IList<int>> result)
    {
        if (node == null)
        {
            return;
        }

        while (level >= result.Count)
        {
            result.Add(new List<int>());
        }
        
        result[level].Add(node.val);
        
        Traverse(node.left, level + 1, result);
        Traverse(node.right, level + 1, result);
    }
}