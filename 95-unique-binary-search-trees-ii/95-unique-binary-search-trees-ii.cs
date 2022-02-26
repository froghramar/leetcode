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
    public IList<TreeNode> GenerateTrees(int n)
    {
        var result = new List<TreeNode>();
        var taken = new bool[n + 1];
        for (var i = 1; i <= n; i++)
        {
            taken[i] = true;
            GenerateTrees(new TreeNode(i), result, taken);
            taken[i] = false;
        }
        return result.Distinct(new TreeNodeComparer()).ToList();
    }

    private static void GenerateTrees(TreeNode root, IList<TreeNode> result, bool[] taken)
    {
        var allTaken = true;
        for (var i = 1; i < taken.Length; i++)
        {
            if (taken[i])
            {
                continue;
            }
            
            var newRoot = Copy(root);
            Insert(newRoot, i);

            taken[i] = true;
            GenerateTrees(newRoot, result, taken);
            taken[i] = false;
            
            allTaken = false;
        }

        if (allTaken)
        {
            result.Add(root);
        }
    }

    private static void Insert(TreeNode root, int val)
    {
        if (val < root.val)
        {
            if (root.left == null)
            {
                root.left = new TreeNode(val);
            }
            else
            {
                Insert(root.left, val);
            }
        }
        else
        {
            if (root.right == null)
            {
                root.right = new TreeNode(val);
            }
            else
            {
                Insert(root.right, val);
            }
        }
    }

    private static TreeNode Copy(TreeNode root)
    {
        if (root == null)
        {
            return null;
        }

        return new TreeNode(root.val, Copy(root.left), Copy(root.right));
    }
}

public class TreeNodeComparer : IEqualityComparer<TreeNode>
{
    public bool Equals(TreeNode t1, TreeNode t2)
    {
        if (t1 == null && t2 == null)
        {
            return true;
        }

        if (t1 == null || t2 == null)
        {
            return false;
        }

        return t1.val == t2.val && Equals(t1.left, t2.left) && Equals(t1.right, t2.right);
    }

    public int GetHashCode(TreeNode obj)
    {
        var hashCode = obj.val;
        if (obj.left != null)
        {
            hashCode ^= GetHashCode(obj.left);
        }

        if (obj.right != null)
        {
            hashCode ^= GetHashCode(obj.right);
        }
        return hashCode;
    }
}