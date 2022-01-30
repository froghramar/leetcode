public class Solution {
    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        var result = new List<IList<int>>();
        if (root == null)
        {
            return result;
        }
        
        PathSumInternal(root, targetSum, new List<int>(), result);

        return result;
    }

    private void PathSumInternal(TreeNode node, int remaining, IList<int> current, IList<IList<int>> result)
    {
        if (node == null)
        {
            return;
        }

        current.Add(node.val);
        remaining -= node.val;
        
        if (node.left == null && node.right == null)
        {
            if (remaining == 0)
            {
                result.Add(current);
            }
        }
        else
        {
            PathSumInternal(node.left, remaining, current.ToList(), result);
            PathSumInternal(node.right, remaining, current.ToList(), result);
        }
    }
}