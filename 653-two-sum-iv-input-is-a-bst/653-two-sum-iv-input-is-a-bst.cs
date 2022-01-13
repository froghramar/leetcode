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
public class Solution
{
    private HashSet<int> _numbers = new HashSet<int>();

    public bool FindTarget(TreeNode root, int k)
    {
        if (root == null)
        {
            return false;
        }

        if (_numbers.Contains(k - root.val))
        {
            return true;
        }

        _numbers.Add(root.val);
        return FindTarget(root.left, k) || FindTarget(root.right, k);
    }
}