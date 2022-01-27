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
    public ListNode SwapPairs(ListNode head) {
        if (head == null || head.next == null)
        {
            return head;
        }
        
        ListNode prev = null, current = head, result = head.next;

        while (current?.next != null)
        {
            var next = current.next;
            var nextNext = next.next;
            next.next = current;
            current.next = nextNext;

            if (prev == null)
            {
                prev = current;
            }
            else
            {
                prev.next = next;
                prev = current;
            }
            
            current = nextNext;
        }

        return result;
    }
}