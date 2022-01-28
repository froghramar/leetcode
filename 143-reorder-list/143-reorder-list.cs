public class Solution {
    public void ReorderList(ListNode head)
    {
        if (head.next == null)
        {
            return;
        }
        
        var (mid, last) = FindMidAndLast(head);
        var midNext = mid.next;
        mid.next = null;
        
        Reverse(midNext);

        ListNode iterator1 = head, iterator2 = last;
        while (iterator1 != null && iterator2 != null)
        {
            var iterator1Next = iterator1.next;
            var iterator2Next = iterator2.next;
            
            iterator1.next = iterator2;
            iterator2.next = iterator1Next;
            
            iterator1 = iterator1Next;
            iterator2 = iterator2Next;
        }
    }

    public void Reverse(ListNode head)
    {
        ListNode current = head, prev = null;
        while (current != null)
        {
            var next = current.next;

            current.next = prev;
            prev = current;
            current = next;
        }
    }

    private (ListNode, ListNode) FindMidAndLast(ListNode head)
    {
        ListNode last = head, mid = head;
        while (last.next != null)
        {
            last = last.next;

            if (last.next != null)
            {
                mid = mid.next;
                last = last.next;
            }
        }

        return (mid, last);
    }
}