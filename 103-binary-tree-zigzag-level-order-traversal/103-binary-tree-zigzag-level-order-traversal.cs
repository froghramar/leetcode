public class Solution {
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        Traverse(root, 0, result);

        for (var i = 0; i < result.Count; i++)
        {
            if (i % 2 == 1)
            {
                result[i] = result[i].Reverse().ToList();
            }
        }

        return result;
    }

    private void Traverse(TreeNode root, int level, IList<IList<int>> result)
    {
        if (root == null)
        {
            return;
        }
        
        if (level >= result.Count)
        {
            result.Add(new List<int>());
        }
        
        result[level].Add(root.val);

        Traverse(root.left, level + 1, result);
        Traverse(root.right, level + 1, result);
    }
}