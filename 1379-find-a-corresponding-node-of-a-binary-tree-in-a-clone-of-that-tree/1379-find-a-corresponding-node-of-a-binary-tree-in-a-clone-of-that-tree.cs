public class Solution {
    public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
    {
        var path = GetPath(original, target);
        return FindWithPath(cloned, path);
    }

    private static TreeNode FindWithPath(TreeNode root, Stack<bool> path)
    {
        if (path.Count == 0)
        {
            return root;
        }

        var left = path.Pop();
        return FindWithPath(left ? root.left : root.right, path);
    }

    private static Stack<bool> GetPath(TreeNode root, TreeNode target)
    {
        if (root == null)
        {
            return null;
        }
        
        if (root == target)
        {
            return new Stack<bool>();
        }

        var path = GetPath(root.left, target);
        if (path is null)
        {
            path = GetPath(root.right, target);
            if (path is null)
            {
                return null;
            }
            
            path.Push(false);
        }
        else
        {
            path.Push(true);
        }

        return path;
    }
}