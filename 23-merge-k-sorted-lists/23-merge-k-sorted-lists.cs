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
    public ListNode MergeKLists(ListNode[] lists)
    {
        ListNode result = null, current = null;

        var iterators = new ListNode[lists.Length];
        
        for (var i = 0; i < lists.Length; i++)
        {
            iterators[i] = lists[i];
        }
        
        while (true)
        {
            var selectedRow = -1;

            for (var i = 0; i < lists.Length; i++)
            {
                if (iterators[i] == null)
                {
                    continue;
                }
                if (selectedRow == -1 || iterators[i].val < iterators[selectedRow].val)
                {
                    selectedRow = i;
                }
            }

            if (selectedRow == -1)
            {
                break;
            }
            
            AddToResult(iterators[selectedRow].val);
            iterators[selectedRow] = iterators[selectedRow].next;
        }

        void AddToResult(int val)
        {
            var node = new ListNode(val);
            if (current == null)
            {
                result = current = node;
            }
            else
            {
                current.next = node;
                current = node;
            }
        }

        return result;
    }
}