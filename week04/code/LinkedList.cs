using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // TODO Problem 1
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // IF THE LIST IS NOT EMPTY, ADD NEW TAIL NODE - ONLY TAIL NODE IS AFFECTED 
        else
        {
            newNode.Prev = _tail; // SET PREVIOUS OF NEW NODE TO CURRENT TAIL
            _tail.Next = newNode; // SET NEXT OF CURRENT TAIL TO NEW NODE 
            _tail = newNode; // UPDATE THE TAIL TO POINT TO THE NEW NODE
        }

    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // TODO Problem 2
        // CHECK IF ONLY ONE NODE EXISTS IN LINKED LIST
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list. This condition will also
        // cover an empty list. Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // IF INDEPENDENT TAIL IS THERE(_head != _tail), REMOVE IT - TAIL NODE ONLY AFFECTED
        else if (_tail is not null)
        {
            _tail.Prev.Next = null; // DISCONNECT SECOND LAST NODE FROM CURRENT TAIL NODE
            _tail = _tail.Prev; // MAKE SECOND LAST NODE TO BE THE TAIL NODE
        }

    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // TODO Problem 3
        // IF ONLY ONE NODE - MAKE EMPTY LINKED LIST
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }

        // SEARCH FOR THE NODE TO BE REMOVED
        // Search for the node that matches 'value' by starting at the head of the list.
        else
        {
            Node? curr = _head;
            bool stop = false;
            
            while (curr is not null && stop == false)
            {
                if (curr.Data == value)
                {
                    // REMOVE HEAD IF MATCHED VALUE IS IN HEAD NODE
                    if(_head.Data == value) 
                    {
                       // _head.Next!.Prev = null; // Disconnect the second node from the first node
                       // _head = _head.Next; // Update the head to point to the second node
                       RemoveHead();
                    }

                    // REMOVE HEAD IF MATCHED VALUE IS IN HEAD NODE
                    else if (_tail.Data == value)
                    {
                       // _tail.Prev.Next = null; // DISCONNECT SECOND LAST NODE FROM CURRENT TAIL NODE
                       // _tail = _tail.Prev; // MAKE SECOND LAST NODE TO BE THE TAIL NODE
                        RemoveTail();
                    }

                    else 
                    {
                        curr.Next.Prev = curr.Prev; 
                        curr.Prev.Next = curr.Next;
                    }

                    stop = true;
                }

                if(stop == false)
                {
                    curr = curr.Next; // Go to the next node to search for 'value'
                }
                
            }
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4
        // LOOP THROUGH EACH NODE AND REPLACE THEIR OLD VALUES WITH NEW VALUES
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }

    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // TODO Problem 5
        // yield return 0; // replace this line with the correct yield return statement(s)
        var curr = _tail; // START AT THE BACK SINCE THIS IS THE BACKWARD ITERATION
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Prev; // GO BACK IN THE LINKED LIST
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}