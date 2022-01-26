/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        var tailA = FindTail(headA);
        var tailB = FindTail(headB);

        if (tailA != tailB)
        {
            return null;
        }

        var sizeA = FindSize(headA);
        var sizeB = FindSize(headB);
        Reverse(headB);

        var newSizeA = FindSize(headA);
        var remaining = (sizeA + sizeB - newSizeA) / 2;
        
        var resultNode = GetNthNode(tailA, remaining);
        
        Reverse(tailB);

        return resultNode;
    }

    ListNode GetNthNode(ListNode root, int n)
    {
        ListNode current = root;
        while (n-- > 0)
        {
            current = current.next;
        }

        return current;
    }

    int FindSize(ListNode node)
    {
        var current = node;
        var size = 0;

        while (current != null)
        {
            size++;
            current = current.next;
        }
        
        return size;
    }

    public void Reverse(ListNode head)
    {
        ListNode current = head.next, prev = head;

        while (current != null)
        {
            var currentNext = current.next;
            current.next = prev;
            prev = current;
            current = currentNext;
        }

        head.next = null;
    }

    public ListNode FindTail(ListNode head)
    {
        var tail = head;

        while (tail.next != null)
        {
            tail = tail.next;
        }
        
        return tail;
    }

    public void PrintList(ListNode node)
    {
        while (node != null)
        {
            Console.Write($"{node.val} ");
            node = node.next;
        }
        
        Console.WriteLine();
    }
}