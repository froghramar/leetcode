public class Solution
{
    private int _maxLevel;
    private int _sum;
    
    public int DeepestLeavesSum(TreeNode root)
    {
        _maxLevel = 0;
        _sum = 0;
        Traverse(root, 0);
        return _sum;
    }

    private void Traverse(TreeNode root, int level)
    {
        if (root == null)
        {
            return;
        }

        if (root.left == null && root.right == null)
        {
            if (level == _maxLevel)
            {
                _sum += root.val;
            }
            else if (level > _maxLevel)
            {
                _sum = root.val;
                _maxLevel = level;
            }
            
            return;
        }
        
        Traverse(root.left, level + 1);
        Traverse(root.right, level + 1);
    }
}