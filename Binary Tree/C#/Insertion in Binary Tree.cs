namespace Binary_Tree
{
    class BinaryTree
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

        static void inorder(Node? temp)
        {
            if (temp == null)
                return;

            inorder(temp.left);
            Console.Write(temp.key + " ");
            inorder(temp.right);
        }

        static void insert(Node temp, int key)
        {
            if(temp == null)
            {
                root = new Node(key);
                return;
            }
            
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(temp);

            // Do level order traversel until we find an empty place for new key
            while(q.Count != 0)
            {
                temp = q.Peek();
                q.Dequeue();

                if(temp.left == null)
                {
                    temp.left = new Node(key);
                    break;
                }
                else
                {
                    q.Enqueue(temp.left);
                }

                if(temp.right == null)
                {
                    temp.right = new Node(key);
                    break;
                }
                else
                {
                    q.Enqueue(temp.right);
                }
            }
        }

        public static void Main(String[] args)
        {
            root = new Node(10);

            insert(root, 20);
            inorder(root);

            Console.WriteLine();
            insert(root, 30);
            inorder(root);

            Console.WriteLine();
            insert(root, 40);
            inorder(root);

            Console.WriteLine();
            insert(root, 50);
            inorder(root);
        }
    }
}
