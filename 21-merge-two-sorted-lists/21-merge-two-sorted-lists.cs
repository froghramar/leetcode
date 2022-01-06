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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode result = null, resultNode = null;
        var list1Node = list1;
        var list2Node = list2;

        while (true)
        {
            if (list1Node == null)
            {
                if (list2Node == null)
                {
                    break;
                }
                
                AddToResult(list2Node);
                list2Node = list2Node.next;
                
                continue;
            }

            if (list2Node == null)
            {
                AddToResult(list1Node);
                list1Node = list1Node.next;
                
                continue;
            }

            if (list1Node.val < list2Node.val)
            {
                AddToResult(list1Node);
                list1Node = list1Node.next;
            }
            else
            {
                AddToResult(list2Node);
                list2Node = list2Node.next;
            }
        }

        void AddToResult(ListNode node)
        {
            if (resultNode == null)
            {
                result = resultNode = new ListNode(node.val);
            }
            else
            {
                resultNode.next = new ListNode(node.val);
                resultNode = resultNode.next;
            }
        }

        return result;
    }
}