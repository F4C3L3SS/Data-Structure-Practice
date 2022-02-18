using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Tree
{
    class Check_if_Binary_Tree_is_a_BST
    {
        class TreeNode
        {
            public int data;
            public TreeNode? left;
            public TreeNode? right;

            public TreeNode(int data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        }

        class BinaryTree
        {
            TreeNode? root;

            BinaryTree()
            {
                root = null;
            }

            static bool ValidateTreeHelper(TreeNode? root, TreeNode? min, TreeNode? max)
            {
                if (root == null)
                    return true;

                if (min != null && root.data < min.data)  // we are comparing if our root node's data is less than the minimum value allowed
                    return false;
                if (max != null && root.data > max.data) // we are comparing if our root node's data is more than the maximum value allowed
                    return false;

                // recursively check for left subtree (min value would be min, maximum cannot be more than or equal to root, hence root) [min <= root.data <= root]
                // recursively check for right subtree (min value would be root, maximum cannot be more than or equal to max) [root <= root.data <= max]
                return ValidateTreeHelper(root.left, min, root) && ValidateTreeHelper(root.right, root, max);
            }

            void ValidateTree(TreeNode root)
            {
                if (ValidateTreeHelper(root, null, null))
                {
                    Console.Write("Given Tree is a BST");
                    return;
                }
                Console.Write("Given Tree is not a BST");
            }

            public static void Main(String[] args)
            {
                //BinaryTree tree = new BinaryTree()
                //{
                //    root = new TreeNode(3)
                //    {
                //        left = new TreeNode(2),
                //        right = new TreeNode(5)
                //    },
                //};
                //tree.root.left.left = new TreeNode(1);
                //tree.root.left.right = new TreeNode(4);

                BinaryTree tree1 = new BinaryTree()
                {
                    root = new TreeNode(4)
                    {
                        left = new TreeNode(2),
                        right = new TreeNode(5)
                    },
                };
                tree1.root.left.left = new TreeNode(1);
                tree1.root.left.right = new TreeNode(3);

                tree1.ValidateTree(tree1.root);
            }

        }
    }
}
