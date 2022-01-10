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
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        Traverse(result, root, 1);
        return result;
    }

    void Traverse(IList<IList<int>> result, TreeNode node, int level)
    {
        if (node == null)
        {
            return;
        }

        if (level > result.Count)
        {
            result.Add(new List<int>());
        }
        
        result[level - 1].Add(node.val);
        Traverse(result, node.left, level + 1);
        Traverse(result, node.right, level + 1);
    }
}