/// <summary>
/// File contents:
/// 1. Inorder Successor
/// 2. Inorder Predecessor
/// 
/// Brute Force approach: 
/// Store the inorder traversal and find the next greater value of the given node.
/// Time Complexity: O(N), Space Complexity: O(N)
/// 
/// Below Approach:
/// Time Complexity: O(H), H -> height of the BST
/// Space Complexity: O(1), ignoring the recursion stack space
/// 
/// </summary>

namespace Binary_Search_Tree
{
    class InorderSuccessor
    {
        class TreeNode
        {
            public int data;
            public TreeNode? left, right;
            public TreeNode(int data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        }

        class BinaryTree
        {
            static TreeNode? root;
            BinaryTree()
            {
                root = null;
            }

            public TreeNode insert(TreeNode? root, int data)
            {
                if (root == null)
                    return new TreeNode(data);

                if (data < root.data)
                    root.left = insert(root.left, data);
                if (data > root.data)
                    root.right = insert(root.right, data);

                return root;
            }

            public TreeNode? inorderSuccessor(TreeNode? root, TreeNode? p)
            {
                TreeNode? successor = null;

                while(root != null)
                {
                    if(root.data <= p.data)
                    {
                        root = root.right;
                    } 
                    else
                    {
                        successor = root;
                        root = root.left;
                    }
                }
                return successor;
            }

            public TreeNode? inorderPredecessor(TreeNode? root, TreeNode? p)
            {
                TreeNode? predecessor = null;

                while(root != null)
                {
                    if(root.data >= p.data)
                    {
                        root = root.left;
                    }
                    else
                    {
                        predecessor = root;
                        root = root.right;
                    }
                }
                return predecessor;
            }

            public TreeNode? FindMin(TreeNode? root)
            {
                while(root?.left != null)
                {
                    root = root.left;
                }
                return root;
            }

            public static void Main(String[] args)
            {
                BinaryTree tree = new BinaryTree();
                root = tree.insert(root, 20);
                root = tree.insert(root, 8);
                root = tree.insert(root, 22);
                root = tree.insert(root, 4);
                root = tree.insert(root, 12);
                root = tree.insert(root, 10);
                root = tree.insert(root, 14);
                TreeNode? temp = root.left?.right?.right;
                TreeNode? successor = tree.inorderSuccessor(root, temp);

                if(successor != null)
                {
                    Console.WriteLine("Inorder successor of " + temp?.data + " is " + successor.data);
                }
                else
                {
                    Console.WriteLine("Inorder successor does not exist.");
                }

                TreeNode? predecessor = tree.inorderPredecessor(root, temp);

                if (predecessor != null)
                {
                    Console.WriteLine("Inorder predecessor of " + temp?.data + " is " + predecessor.data);
                }
                else
                {
                    Console.WriteLine("Inorder predecessor does not exist.");
                }
            }
        }
    }
}
