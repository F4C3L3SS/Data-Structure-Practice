/// <summary>
/// Diameter of the tree is the longest path between any 2 nodes in a binary tree
/// 
/// Here we are recursively checking for left and right subtree diamter and keeping track of the current
/// diameter in order to update the largest.
/// 
/// Additionally, follow-up question is print the longest path of the binary tree
/// </summary>
namespace Binary_Tree
{
    class Diameter_2_optimized__with_path
    {
        public class TreeNode
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

        public class Diameter
        {
            TreeNode? node;
            static List<TreeNode>? maxPath;
            static int diameter = 0;
            
            public static int findDiameter(TreeNode? root, ref int diameter)
            {
                if (root == null)
                    return 0;

                int left = findDiameter(root.left, ref diameter);
                int right = findDiameter(root.right, ref diameter);

                // update the diameter if left path + right path is larger
                diameter = Math.Max(diameter, left + right);

                // return the longest one between left path and right path
                // we are adding one for the path connecting the node and its parent
                return Math.Max(left, right) + 1;
            }

            public static List<TreeNode> MaxPath(TreeNode? root)
            {
                if (root == null)
                    return new List<TreeNode>();

                List<TreeNode> leftPath = MaxPath(root.left);
                List<TreeNode> rightPath = MaxPath(root.right);

                if(leftPath.Count + rightPath.Count > diameter)
                {
                    maxPath = new List<TreeNode>(leftPath);
                    maxPath.Add(root);
                    maxPath.AddRange(rightPath); // starting adding in last
                    diameter = leftPath.Count + rightPath.Count;
                }

                List<TreeNode> path = new List<TreeNode>(leftPath.Count > rightPath.Count ? leftPath : rightPath);

                path.Add(root);
                return path;
            }

            public static void Main(string[] args)
            {
                Diameter d = new Diameter();
                d.node = new TreeNode(1)
                {
                    left = new TreeNode(2),
                    right = new TreeNode(3)
                };
                d.node.left.left = new TreeNode(4);
                d.node.left.right = new TreeNode(5);

                int diameter = Int32.MinValue;
                Console.WriteLine("Diameter: {0}", findDiameter(d.node, ref diameter));

                MaxPath(d.node);

                foreach(var node in maxPath)
                {
                    Console.Write($"{node.data} ");
                }
            }
        }
    }
}
