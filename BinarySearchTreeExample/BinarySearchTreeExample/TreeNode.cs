using System;
using System.Collections;

namespace BinarySearchTreeExample
{
    internal class TreeNode
    {
        internal DictionaryEntry entry; // contains the data in KVP format
        internal TreeNode left;         // lower value than parent
        internal TreeNode right;        // higher value than parent
        internal int height;

        public TreeNode(object key, object value)
        {
            entry = new DictionaryEntry(key, value);
            left = right = null;        // by default a new node is a Leaf w/o Children
            height = 0;
        }
    }
}
