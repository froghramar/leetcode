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
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return SortedArrayToBST(nums, 0, nums.Length - 1);
    }
    
    private TreeNode SortedArrayToBST(int[] nums, int l, int r)
    {
        if (l > r)
        {
            return null;
        }

        var midIndex = (l + r) / 2;
        var left = SortedArrayToBST(nums, l, midIndex - 1);
        var right = SortedArrayToBST(nums, midIndex + 1, r);
        return new TreeNode(nums[midIndex], left, right);
    }
}