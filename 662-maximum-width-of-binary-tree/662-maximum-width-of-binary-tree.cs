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
    public int WidthOfBinaryTree(TreeNode root)
    {
        var min = new List<int>();
        var max = new List<int>();
        Traverse(root, 0, 0, min, max);

        var result = 0;
        for (var i = 0; i < min.Count; i++)
        {
            result = Math.Max(result, max[i] - min[i] + 1);
        }
        return result;
    }

    private static void Traverse(TreeNode node, int n, int level, IList<int> min, IList<int> max)
    {
        if (node == null)
        {
            return;
        }

        while (level >= min.Count)
        {
            min.Add(n);
            max.Add(n);
        }

        max[level] = n;
        
        Traverse(node.left, 2 * n, level + 1, min, max);
        Traverse(node.right, 2 * n + 1, level + 1, min, max);
    }
}