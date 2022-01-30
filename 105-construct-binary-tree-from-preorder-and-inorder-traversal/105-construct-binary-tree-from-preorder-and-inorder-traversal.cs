public class Solution {
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        return BuildTreeInternal(preorder, inorder, 0, 0, inorder.Length);
    }
    
    private TreeNode BuildTreeInternal(int[] preorder, int[] inorder, int preL, int inL, int len) {
        if (len <= 0)
        {
            return null;
        }

        var rootValue = preorder[preL];
        var rootPos = FindPosition(inorder, inL, len, rootValue);
        var leftLen = rootPos - inL;

        return new TreeNode(
            rootValue,
            BuildTreeInternal(preorder, inorder, preL + 1, inL, leftLen), 
            BuildTreeInternal(preorder, inorder, preL + 1 + leftLen, inL + 1 + leftLen, len - leftLen - 1));
    }

    private int FindPosition(int[] nums, int l, int len, int target)
    {
        for (var i = 0; i < len; i++)
        {
            if (nums[l + i] == target)
            {
                return l + i;
            }
        }

        return -1;
    }
}