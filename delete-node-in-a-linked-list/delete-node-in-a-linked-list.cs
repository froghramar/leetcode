/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public void DeleteNode(ListNode node)
    {
        node.val = node.next.val;
        while (node.next.next != null)
        {
            node = node.next;
            node.val = node.next.val;
        }

        node.next = null;
    }
}