/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
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
    public TreeNode SortedListToBST(ListNode head)
    {
        var nums = GetArray(head);
        return SortedListToBSTInternal(nums, 0, nums.Length - 1);
    }

    private static TreeNode SortedListToBSTInternal(int[] nums, int l, int r)
    {
        if (l > r)
        {
            return null;
        }

        var m = (l + r) / 2;
        return new TreeNode(
            nums[m], 
            SortedListToBSTInternal(nums, l, m - 1), 
            SortedListToBSTInternal(nums, m + 1, r));
    }

    private static int[] GetArray(ListNode node)
    {
        var result = new List<int>();
        while (node != null)
        {
            result.Add(node.val);
            node = node.next;
        }
        return result.ToArray();
    }
}