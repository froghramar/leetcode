public class Solution {
    public int KthSmallest(TreeNode root, int k)
    {
        var result = new List<int>();
        Traverse(root, result);
        return result[k - 1];
    }

    void Traverse(TreeNode root, List<int> result)
    {
        if (root == null)
        {
            return;
        }
        
        Traverse(root.left, result);
        result.Add(root.val);
        Traverse(root.right, result);
    }
}