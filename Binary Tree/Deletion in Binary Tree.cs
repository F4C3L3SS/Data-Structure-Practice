
/// <summary>
/// Algorithm:
/// 1. Starting at the root, find the deepest and rightmost node in binary tree and node which we want to delete. 
/// 2. Replace the deepest rightmost node’s data with the node to be deleted.
/// 3. Then delete the deepest rightmost node.
/// </summary>
namespace Binary_Tree
{
    class BinaryTreeDeletion
    {
        public class Node
        {
            public int key;
            public Node? left, right;

            public Node(int key)
            {
                this.key = key;
                left = null;
                right = null;
            }
        }

        static Node? root;
        static Node? temp = root;

        static void inorder(Node? temp)
        {
            if (temp == null)
                return;

            inorder(temp.left);
            Console.Write(temp.key + " ");
            inorder(temp.right);
        }

        static void Delete(Node? root, int key)
        {
            if (root == null)
                return;

            if(root.left == null && root.right == null)
            {
                if (root.key == key)
                {
                    root = null;
                    return;
                }
                else return;
            }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            Node? temp = null, keyNode = null, last = null;

            while(q.Count != 0)
            {
                temp = q.Peek();
                q.Dequeue();

                if (temp.key == key)
                    keyNode = temp;

                if (temp.left != null)
                {
                    last = temp; // store the parent node
                    q.Enqueue(temp.left);
                }

                if (temp.right != null)
                {
                    last = temp; // store the parent node
                    q.Enqueue(temp.right);
                }
            }

            // found the key, now we need to delete the deepest.
            if (keyNode != null)
            {
                keyNode.key = temp.key; // replacing key_node's data to deepest node's data
                if (last.right == temp)
                    last.right = null;
                else
                    last.left = null;
            }
        }

        public static void Main(string[] args)
        {
            root = new Node(10);
            root.left = new Node(11);
            root.left.left = new Node(7);
            root.left.right = new Node(12);
            root.right = new Node(9);
            root.right.left = new Node(15);
            root.right.right = new Node(8);

            Console.WriteLine("Inorder traversal before deletion:");
            inorder(root);

            Delete(root, 11);

            Console.WriteLine("\nInorder traversal after deletion:");
            inorder(root);
        }
    }
}
