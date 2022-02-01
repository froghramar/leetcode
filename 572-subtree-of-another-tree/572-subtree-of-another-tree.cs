public class Solution {
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        if (root == null && subRoot == null)
        {
            return true;
        }
        
        if (root == null ||  subRoot == null)
        {
            return false;
        }
        
        return Equal(root, subRoot) || IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

    private bool Equal(TreeNode tree1, TreeNode tree2)
    {
        if (tree1 == null && tree2 == null)
        {
            return true;
        }
        
        if (tree1 == null ||  tree2 == null)
        {
            return false;
        }

        return tree1.val == tree2.val && Equal(tree1.left, tree2.left) && Equal(tree1.right, tree2.right);
    }
}