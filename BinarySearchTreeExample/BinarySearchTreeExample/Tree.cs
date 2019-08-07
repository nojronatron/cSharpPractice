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
        public TreeNode Get(object key)
        {
            // return the TreeNode with the given key or null if not found
            if (root == null)
            {
                return null;
            }
            TreeNode temp = root;
            while (temp != null)
            {
                if (key.GetHashCode().Equals(temp.entry.Key.GetHashCode()))
                {
                    return temp;
                }
                if (key.GetHashCode() < temp.entry.Key.GetHashCode())
                {
                    temp = temp.left;
                }
                else
                {
                    temp = temp.right;
                }
            }
            return null;
        }
        public TreeNode Successor()
        {
            if (root.right == null)
            {
                return null;
            }
            TreeNode temp = root.right;
            TreeNode successor = MinNode(temp);
            return successor;
        }
        public TreeNode Successor(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }
            TreeNode temp = node.right;
            TreeNode successor = MinNode(node.right);
            return successor;
        }
        public TreeNode Predecessor()
        {
            if (root.left == null)
            {
                return null;
            }
            TreeNode temp = root.left;
            TreeNode predecessor = MaxNode(temp);
            return predecessor;
        }
        public TreeNode Predecessor(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }
            TreeNode temp = node.left;
            TreeNode predecessor = MaxNode(node.right);
            return predecessor;
        }
        public TreeNode MaxNode()
        {
            if (root == null)
            {
                return null;
            }
            TreeNode temp = root;
            while (temp.right != null)
            {
                temp = temp.right;
            }
            return temp;
        }
        public TreeNode MaxNode(TreeNode node)
        {
            if (root == null)
            {
                return null;
            }
            TreeNode temp = node;
            while(temp.right != null)
            {
                temp = temp.right;
            }
            return temp;
        }
        public TreeNode MinNode()
        {
            if (root == null)
            {
                return null;
            }
            TreeNode temp = root;
            while(temp.left != null)
            {
                temp = temp.left;
            }
            return temp;
        }
        public TreeNode MinNode(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }
            TreeNode temp = node;
            while (temp.left != null)
            {
                temp = temp.left;
            }
            return temp;
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
            // left, node, right (LNR :: Sorted ascending indices)
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
            // NLR
            if (node == null)
            {
                return;
            }
            queue.Enqueue(node.entry);
            Preorder(node.left, queue);
            Preorder(node.right, queue);
        }
        // DONE: Create public Postorder Queue methods
        public Queue Postorder()
        {
            Queue queue = new Queue();
            Postorder(root, queue);
            return queue;
        }
        // DONE: Create private Postorder recursive method
        private void Postorder(TreeNode node, Queue queue)
        {
            // LRN
            if (node == null)
            {
                return;
            }
            Postorder(node.left, queue);
            Postorder(node.right, queue);
            queue.Enqueue(node.entry);
        }
        public Queue OutOrder()
        {
            Queue queue = new Queue();
            Outorder(root, queue);
            return queue;
        }
        private void Outorder(TreeNode node, Queue queue)
        {
            // RNL: reverse order a.k.a. Descending
            if (node == null)
            {
                return;
            }
            Outorder(node.right, queue);
            queue.Enqueue(node.entry);
            Outorder(node.left, queue);
        }

    }
}
