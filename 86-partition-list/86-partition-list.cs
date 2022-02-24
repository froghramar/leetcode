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
    public ListNode Partition(ListNode head, int x)
    {
        ListNode firstHead = null, firstTail = null, lastHead = null, lastTail = null, cur = head;
        while (cur != null)
        {
            if (cur.val < x)
            {
                if (firstTail == null)
                {
                    firstHead = firstTail = cur;
                }
                else
                {
                    firstTail.next = cur;
                    firstTail = cur;
                }
            }
            else
            {
                if (lastTail == null)
                {
                    lastHead = lastTail = cur;
                }
                else
                {
                    lastTail.next = cur;
                    lastTail = cur;
                }
            }
            cur = cur.next;
        }

        if (lastTail != null)
        {
            lastTail.next = null;
        }

        if (firstHead == null)
        {
            return lastHead;
        }

        firstTail.next = lastHead;
        return firstHead;
    }
}