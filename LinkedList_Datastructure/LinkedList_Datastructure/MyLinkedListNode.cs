using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_Datastructure
{
    public class MyLinkedListNode
    {
        internal object data; // object allows any datatype essentially
        internal MyLinkedListNode next; // use internal so that the linked list will have access to these
        internal MyLinkedListNode previous;
        public MyLinkedListNode(object data) // CTOR
        {
            this.data = data;
            next = null; // we dont yet know what they will be set to
            previous = null; // alternately could do next = previous = null (without shadowing!)
        }
    }
}
