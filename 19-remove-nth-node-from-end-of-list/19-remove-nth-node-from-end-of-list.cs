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
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode current = head, behind = head;
        var currentPost = 0;

        while (current != null)
        {
            if (currentPost > n)
            {
                behind = behind.next;
            }
            currentPost++;
            current = current.next;
        }
        
        if (behind == head && currentPost <= n)
        {
            return head.next;
        }

        behind.next = behind.next.next;

        return head;
    }
}