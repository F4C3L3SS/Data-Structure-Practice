using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (p?.right != null)
                    return FindMin(p.right);

                TreeNode? ans = null;

                while(root != null)
                {
                    if(p.data < root.data)
                    {
                        ans = root;
                        root = root.left;
                    }
                    else
                    {
                        root = root.right;
                    }
                }
                return ans;
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
            }
        }
    }
}
