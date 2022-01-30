public class Solution {
    public IList<int> RightSideView(TreeNode root)
    {
        var result = new List<int>();
        RightSideViewInternal(root, 0, result);
        return result;
    }

    private void RightSideViewInternal(TreeNode node, int level, IList<int> result)
    {
        if (node == null)
        {
            return;
        }
        
        if (level == result.Count)
        {
            result.Add(node.val);
        }
        else
        {
            result[level] = node.val;
        }

        RightSideViewInternal(node.left, level + 1, result);
        RightSideViewInternal(node.right, level + 1, result);
    }
}