using System;
using System.Collections;

namespace BinarySearchTreeExample
{
    internal class Tree
    {
        TreeNode root;      // from here can reach all other nodes like a LinkedList
        int count;

        public Tree()
        {
            root = null;
            count = 0;
        }
        public Tree(TreeNode node)
        {
            root = node;
            count = 1;
        }
        public int Count { get { return this.count; } }
        public void Insert(object key, object value)
        {
            TreeNode newNode = new TreeNode(key, value);
            if (root == null)
            {
                root = newNode;     // 1st node is always the root
                count++;
                return;
            }
            // need to loop to get to where the 'ground' node is (null)
            TreeNode parent = null;
            TreeNode temp = root;   // temp Node is the one we need to move FIRST
            while (temp != null)    // do what we need to do until temp meets ground
            {
                parent = temp;
                if (key.GetHashCode() == temp.entry.Key.GetHashCode())
                {
                    throw new ArgumentException("Cannot Insert. Keys must be unique.");
                }
                if (key.GetHashCode() > temp.entry.Key.GetHashCode())
                {
                    temp = temp.right;
                }
                else
                {
                    temp = temp.left;
                }
            }
            // once we hit 'ground' we need to test left-or-right then place 'parent' at the new position
            if (key.GetHashCode() < parent.entry.Key.GetHashCode())
            {
                parent.left = newNode;      // attach to left
            }
            else
            {
                parent.right = newNode;     // attach to right
            }
            count++;
            return;
        }
        public Queue Inorder()
        {
            Queue queue = new Queue();
            Inorder(root, queue);           // start the recursive inorder at the root
                                            // pass to it the queue to save all the nodes it traverses
            return queue;                   // return queue to the caller
        }
        // traversing the BST
        private void Inorder(TreeNode node, Queue queue)    // user should not see this
        {
            // left, node, right
            if (node == null)
            {
                return;
            }
            // move to the left
            Inorder(node.left, queue);
            // visit (display) the node
            queue.Enqueue(node.entry);      // reminder: a DictionaryEntry<>
            Inorder(node.right, queue);
        }
        public Queue Preorder()
        {
            // node, left, then right
            Queue queue = new Queue();
            Preorder(root, queue);
            return queue;
        }
        private void Preorder(TreeNode node, Queue queue)
        {
            if (node == null)
            {
                return;
            }
            queue.Enqueue(node.entry);
            Preorder(node.left, queue);
            Preorder(node.right, queue);
        }
        // TODO: Create public Postorder Queue methods
        // TODO: Create private Postorder recursive method
    }
}
