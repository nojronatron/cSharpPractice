using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_Datastructure
{
    public class MyLinkedList
    {
        private MyLinkedListNode first; // reference to the first node in this linked list
        private MyLinkedListNode last; // reference to the last node in this linked list
        private int count; // tracks number of nodes in linked list
        public MyLinkedList() // default CTOR to build an empty linked list
        {
            first = null;
            last = null;
            count = 0;
        }
        public int Count { get { return this.count; } }
        public MyLinkedListNode First { get { return first; } }
        public MyLinkedListNode Last { get { return last; } }
        // help us manage all the nodes using Methods() e.g. Add, Remove, and SearchFor node
        public void AddFirst(object data)
        {
            // create a new node
            MyLinkedListNode node = new MyLinkedListNode(data);
            if (count == 0) // no other nodes exist yet!
            {
                first = node;
                last = node;
            }
            else
            {
                node.next = first; // connects New Node to the CURRENT First Node
                first.previous = node; // connects the CURRENT First Node to New Node
                first = node; // make New Node the First Node
            }
            count++; // more effecient than +1
        }
        public void RemoveFirst()
        {
            if (count == 0)
            {
                throw new InvalidOperationException();
            }
            else if (count == 1)
            {
                first = last = null; // both First and Last are pointing to self to orphan it
            }
            else
            {
                // disconnect links between First and Next Nodes
                first.next.previous = null;
                // save a reference to the Next Node before cutting link to Next node
                MyLinkedListNode second = first.next;
                second.previous = null;
                first.next = null;
                // now delete the last link
                first = second;
                // object is now orphaned and GC will take care of it eventually
            }
            count--;
        }
        public void RemoveLast()
        {
            // DONE: Homework -- finish this Method()

            // 1) catch and handle errors/invalid input
            // 2) disconnect links between Last and Previous nodes
            // 3) save a ref to the Next node before cutting link to it
            // 4) delete the last link
            // 5) TEST it
            if (count < 1)
            {
                throw new InvalidOperationException();
            }
            else if (count == 1)
            {
                last = first = null;
            }
            else // (count > 1)
            {
                MyLinkedListNode previous_to_last = last.previous; // create temp node REF for manipulating properties
                last.previous = null; // remove current last node's reference to previous
                previous_to_last.next = null; // disconnect link from second-to-last node to last
                last = previous_to_last; // set last pointer to this temp node/object
            }
            count--; // reduce count by one
            // object is now orphaned and GC will take care of it eventually
        }
        public void AddLast(object data)
        {
            MyLinkedListNode node = new MyLinkedListNode(data);
            if (count == 0)
            {
                first = node;
            }
            else
            {
                last.next = node; // this one I could not figure out
                node.previous = last; // I figured this out
            }
            last = node; // I figured this out
            count++;
        }
        public void CopyTo(object[] array, int starting_index) // array, starting index
        {
            if (array == null)
            {
                throw new ArgumentNullException(); // this just checks for bad data
            }
            if (starting_index < 0)
            {
                throw new ArgumentOutOfRangeException(); // same here, bad data check
            }
            if (starting_index + count < array.Length)
            {
                throw new ArgumentException(); // to make sure there is enough Array space to include the data
            }
            // sequence through a non-indexed linked list using a temp node, by REFerence, until next == null
            int i = 0; // an index for the array
            MyLinkedListNode temp = first; // initialize by pointing to the First Node
            while(temp != null)
            {
                // copy the Node data to the array
                array[i] = temp.data;
                // advance both
                i++; // increment the array index
                temp = temp.next; // go to the next object by REFerence
            }
        }
    }
}
