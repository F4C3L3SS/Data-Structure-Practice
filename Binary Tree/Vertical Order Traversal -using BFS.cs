using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{
    class Vertical_Order_Traversal__using_BFS
    {
        public class TreeNode
        {
            public int data;
            public TreeNode? left, right;
            public TreeNode(int data = 0, TreeNode? left = null, TreeNode? right = null)
            {
                this.data = data;
                this.left = left;
                this.right = right;
            }
        }

        class BinaryTree
        {
            TreeNode? root;

            BinaryTree()
            {
                root = null;
            }

            public IList<IList<int>> VerticalOrderHelper(TreeNode root)
            {
                List<IList<int>> result = new();

                if (root == null)
                    return result;

                SortedDictionary<int, IList<int>> sortedDict = new();

                Queue<(TreeNode, int)> queue = new();
                queue.Enqueue((root, 0));

                while (queue.Any())
                {
                    int size = queue.Count;
                    //for (int s = 0; s < size; s++)
                    //{
                        (TreeNode cur, int curIndex) = queue.Dequeue();

                        if(!sortedDict.ContainsKey(curIndex))
                        {
                            sortedDict[curIndex] = new List<int>();
                        }

                        sortedDict[curIndex].Add(cur.data);

                        if (cur.left != null)
                            queue.Enqueue((cur.left, curIndex - 1));

                        if (cur.right != null)
                            queue.Enqueue((cur.right, curIndex + 1));
                    //}
                }

                foreach(var kvp in sortedDict)
                {
                    result.Add(kvp.Value);
                }

                return result;
            }

            public void VerticalOrder(TreeNode root)
            {
                List<IList<int>> result = new(VerticalOrderHelper(root));
            }

            public static void Main(String[] args)
            {
                BinaryTree tree = new BinaryTree();
                tree.root = new TreeNode(3);
                tree.root.left = new TreeNode(9);
                tree.root.right = new TreeNode(20);
                tree.root.right.right = new TreeNode(7);
                tree.root.right.left = new TreeNode(15);

                tree.VerticalOrder(tree.root);
            }
        }
    }
}
