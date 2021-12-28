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
    public ListNode MiddleNode(ListNode head)
    {
        ListNode current = head, middle = head;

        while (current?.next != null)
        {
            current = current.next;
            middle = middle.next;

            if (current != null)
            {
                current = current.next;
            }
        }

        return middle;
    }
}