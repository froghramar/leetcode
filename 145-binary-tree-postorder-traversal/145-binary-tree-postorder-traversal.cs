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

    private List<int> _values;

    public IList<int> PostorderTraversal(TreeNode root)
    {
        _values = new List<int>();
        Traverse(root);
        return _values;
    }

    void Traverse(TreeNode node)
    {
        if (node == null)
        {
            return;
        }
        
        Traverse(node.left);

        Traverse(node.right);
        
        _values.Add(node.val);
    }
}