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
    public ListNode RotateRight(ListNode head, int k)
    {
        var length = 0;
        ListNode cur = head, last = null;
        while (cur != null)
        {
            last = cur;
            length++;
            cur = cur.next;
        }

        if (length < 2)
        {
            return head;
        }

        k %= length;
        k = length - k;
        k %= length;

        if (k == 0)
        {
            return head;
        }

        k--;
        cur = head;
        while (k > 0)
        {
            cur = cur.next;
            k--;
        }

        var next = cur.next;
        cur.next = null;
        last.next = head;
        return next;
    }
}