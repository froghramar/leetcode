/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head)
    {
        if (head == null)
        {
            return null;
        }
        
        var index = new Dictionary<Node, int>();
        var list = new List<Node>();

        var curNode = head;
        var curIndex = 0;
        while (curNode != null)
        {
            list.Add(curNode);
            index[curNode] = curIndex;
            
            curIndex++;
            curNode = curNode.next;
        }

        var result = list.Select(t => new Node(t.val)).ToList();
        for (var i = 0; i < list.Count; i++)
        {
            if (i < list.Count - 1)
            {
                result[i].next = result[i + 1];
            }

            if (list[i].random != null)
            {
                result[i].random = result[index[list[i].random]];
            }
        }

        return result[0];
    }
}