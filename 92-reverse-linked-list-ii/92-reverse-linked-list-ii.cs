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
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        var preLast = FindNthNode(head, left - 1);
        var leftNode = FindNthNode(head, left);
        var rightNode = FindNthNode(head, right);
        var postFirst = FindNthNode(head, right + 1);
        
        Reverse(leftNode, rightNode);

        var result = head;
        if (preLast == null)
        {
            result = rightNode;
        }
        else
        {
            preLast.next = rightNode;
        }

        leftNode.next = postFirst;

        return result;
    }

    private ListNode FindNthNode(ListNode head, int n)
    {
        if (n == 0)
        {
            return null;
        }
        
        if (n == 1)
        {
            return head;
        }

        return FindNthNode(head?.next, n - 1);
    }

    private void Reverse(ListNode left, ListNode right)
    {
        if (left == right)
        {
            return;
        }
        
        Reverse(left.next, right);
        left.next.next = left;
        left.next = null;
    }
}