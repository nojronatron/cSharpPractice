using System;
using System.Collections;

namespace StackArrayImplementation
{
    class MyStack : IEnumerable
    {
        // create an array, encapsulate it in a class, and then 
        // provide functionatily that makes it look like a stack
        private object[] array;
        private int sp; // _S_tack _P_ointer
        private int count; // track number of items in the collection
        public MyStack()
        {
            array = new object[8];
            sp = -1;
            count = 0;
        }
        public MyStack(int capacity)
        {
            array = new object[capacity];
            sp = -1;
            count = 0;
        }
        public int Count { get { return count; } }
        //methods
        //add new item to top of the stack
        public void Push(object data)
        {
            sp++;
            if (sp < array.Length)
            {
                array[sp] = data;
            }
            else
            {
                // the array is full and needs to be extended
                object[] temp = new object[array.Length * 2];
                // copy all the data from array to temp
                for (int i = 0; i < array.Length; i++)
                {
                    temp[i] = array[i]; // this is a one-to-one operation
                }
                array = temp; // update the REF of array (because the data is in the Heap anyway)
                // now add the data to the newly resized array
                array[sp] = data;
                // remember to add to the count!!
            }
            count++;
        }
        //return and remove the top item from the stack
        public object Pop()
        {
            // is stack empty? if so throw InvalidOperationException
            if (Count == 0)
            {
                throw new InvalidOperationException("The stack is empty so nothing to return.");
            }
            else
            {
                // 1) take item from index sp and store it
                // 2) _decrement_ sp
                // 3) _decrement_ count
                // 4) return the stored item at old index sp
                object temp = array[sp];
                sp--;
                count--;
                return temp;
            }
        }
        //return the top item from the stack without removing it
        public object Peek()
        {
            // is stack empty? if so throw InvalidOperationException
            if (Count == 0)
            {
                throw new InvalidOperationException("The stack is empty so nothing to return.");
            }
            else
            {
                // since no changs are being made to the Collection, just return the item to the caller
                return array[sp];
            }
        }
        //helper method ToArray() copies content of the stack to an array i.e.: return an array that contains everything in the stack
        public object[] ToArray()
        {
            // because the method() returns an array, we need to create the array in order to return values from the stack
            // use Count so that it holds _exactly_ the number of items we will copy out (otherwise would waste mem & cycles)
            object[] temp = new object[Count];
            for (int i = 0; i >= Count; i++)
            {
                temp[i] = array[i]; // this is a one-to-one operation
            }
            return temp;
        }
        // add GetEnumerator() so that foreach statement can be used on this stack
        //    GetEnumerator() is defined in IEnumerable interface
        public IEnumerator GetEnumerator()
        {
            // sequence through the stack and return wanted values
            //    start from the TOP of the stack
            for (int i = sp; i >= 0; i--)
            {
                yield return array[i];
            }
        }
    }
}
