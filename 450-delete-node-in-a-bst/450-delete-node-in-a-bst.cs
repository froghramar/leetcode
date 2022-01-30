public class Solution {
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        var (deleteParent, deleteNode, deleteLeft) = FindNodeToBeDeleted(root, key);
        if (deleteNode == null)
        {
            return root;
        }

        if (deleteNode.right == null)
        {
            if (deleteNode == root)
            {
                return root.left;
            }
            
            if (deleteLeft)
            {
                deleteParent.left = deleteNode.left;
            }
            else
            {
                deleteParent.right = deleteNode.left;
            }

            return root;
        }

        if (deleteNode.right.left == null)
        {
            deleteNode.val = deleteNode.right.val;
            deleteNode.right = deleteNode.right.right;
            return root;
        }

        deleteNode.val = DeleteMinimumNode(deleteNode.right);

        return root;
    }
    
    private int DeleteMinimumNode(TreeNode root)
    {
        TreeNode parent = root, current = parent.left;

        while (current.left != null)
        {
            parent = current;
            current = current.left;
        }

        parent.left = current.right;
        
        return current.val;
    }

    private (TreeNode, TreeNode, bool) FindNodeToBeDeleted(TreeNode root, int key)
    {
        TreeNode parent = null, current = root;
        var left = true;

        while (current != null)
        {
            if (current.val == key)
            {
                break;
            }

            parent = current;
            if (key < current.val)
            {
                current = current.left;
                left = true;
            }
            else
            {
                current = current.right;
                left = false;
            }
        }
        
        return (parent, current, left);
    }
}