
/// <summary>
/// Depth First Traversals: 
/// (a) Inorder (Left, Root, Right) : 4 2 5 1 3 
/// (b) Preorder (Root, Left, Right) : 1 2 4 5 3 
/// (c) Postorder (Left, Right, Root) : 4 5 2 3 1
/// </summary>
namespace Binary_Tree
{
    class TreeTraversal
    {
        public class Node
        {
            public int key;
            public Node? left, right;

            public Node(int item)
            {
                key = item;
                left = null;
                right = null;
            }
        }

        class BinaryTree
        {
            Node? root;

            BinaryTree()
            {
                root = null;
            }

            // Left, Right, Root
            void PostOrder(Node? root)
            {
                if (root == null)
                    return;

                PostOrder(root.left);
                PostOrder(root.right);
                Console.Write(root.key + " ");
            }

            // Root, Left, Right
            void PreOrder(Node? root)
            {
                if (root == null)
                    return;

                Console.Write(root.key + " ");
                PreOrder(root.left);
                PreOrder(root.right);
            }

            // Left, Root, Right
            void InOrder(Node? root)
            {
                if (root == null)
                    return;

                InOrder(root.left);
                Console.Write(root.key + " ");
                InOrder(root.right);
            }

            void printPostorder() { PostOrder(root); }
            void printPreorder() { PreOrder(root); }
            void printInorder() { InOrder(root); }

            public static void Main(String[] args)
            {
                BinaryTree tree = new BinaryTree();
                tree.root = new Node(1);
                tree.root.left = new Node(2);
                tree.root.right = new Node(3);
                tree.root.left.left = new Node(4);
                tree.root.left.right = new Node(5);

                Console.WriteLine("PostOrder traversal of binary tree is ");
                tree.printPostorder();

                Console.WriteLine("PreOrder traversal of binary tree is ");
                tree.printPreorder();

                Console.WriteLine("InOrder traversal of binary tree is ");
                tree.printInorder();
            }
        }

    }
}
