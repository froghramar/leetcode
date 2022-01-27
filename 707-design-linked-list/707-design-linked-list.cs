public class MyLinkedList
{
    private Node _head, _tail;
    
    public MyLinkedList() {
    }

    public void Print()
    {
        var current = _head;
        while (current != null)
        {
            Console.Write(current.val);
            current = current.next;
        }
        
        Console.WriteLine();
    }
    
    public int Get(int index)
    {
        var current = _head;
        while (index-- > 0)
        {
            if (current == null)
            {
                return -1;
            }
            current = current.next;
        }

        return current?.val ?? -1;
    }
    
    public void AddAtHead(int val)
    {
        if (_head == null)
        {
            _head = _tail = new Node(val);
        }
        else
        {
            _head = new Node(val, _head);
        }
    }
    
    public void AddAtTail(int val)
    {
        if (_head == null)
        {
            AddAtHead(val);
            return;
        }
        var newTail = new Node(val);
        _tail.next = newTail;
        _tail = newTail;
    }
    
    public void AddAtIndex(int index, int val) {
        if (index == 0)
        {
            AddAtHead(val);
            return;
        }

        var current = _head;
        while (--index > 0)
        {
            if (current == null)
            {
                return;
            }
            current = current.next;
        }

        if (current == null)
        {
            return;
        }

        if (current == _tail)
        {
            AddAtTail(val);
        }
        else
        {
            current.next = new Node(val, current.next);
        }
    }
    
    public void DeleteAtIndex(int index) {

        if (_head == null)
        {
            return;
        }

        if (_head == _tail)
        {
            if (index == 0)
            {
                _head = _tail = null;
            }
            
            return;
        }
        
        if (index == 0)
        {
            _head = _head.next;
            return;
        }

        var current = _head;
        while (--index > 0)
        {
            if (current == null)
            {
                return;
            }
            current = current.next;
        }

        if (current == null)
        {
            return;
        }

        if (current.next == null)
        {
            return;
        }

        if (current.next == _tail)
        {
            current.next = null;
            _tail = current;
        }
        else
        {
            current.next = current.next.next;
        }
    }
}

class Node
{
    public int val;
    public Node next;
    
    public Node(int val, Node next = null)
    {
        this.val = val;
        this.next = next;
    }
}