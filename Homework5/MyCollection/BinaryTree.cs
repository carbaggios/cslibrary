namespace Cspro.Collection
{
    public class BinaryTreeNode
    {
        public int Key { get; }

        public BinaryTreeNode? Left { get; set; }

        public BinaryTreeNode? Right { get; set; }

        public BinaryTreeNode(int value)
        {
            Key = value;
            Left = Right = null;
        }

        public override string? ToString()
        {
            return Key.ToString();
        }
    }

    public class BinaryTree
    {
        public BinaryTreeNode? Root { get; private set; }

        public int Count { get; private set; }

        public void Add(int value)
        {
            Root = Add(Root!, value);
        }

        private BinaryTreeNode Add(BinaryTreeNode root, int value)
        {
            if (root == null)
            {
                root = new BinaryTreeNode(value);
                Count++;
                return root;
            }

            var compareResult = value.CompareTo(root.Key);
            if (compareResult < 0)
            {
                root.Left = Add(root.Left!, value);
            }
            else if (compareResult > 0)
            {
                root.Right = Add(root.Right!, value);
            }

            return root;
        }

        public bool Contains(int value) => Contains(Root, value);

        private bool Contains(BinaryTreeNode? root, int value)
        {
            if (root == null || root.Key.CompareTo(value) == 0)
                return root != null;

            if (value.CompareTo(root.Key) < 0)
                return Contains(root.Left, value);
            else
                return Contains(root.Right, value);
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public int[] ToArray()
        {
            int[] result = new int[Count];
            int index = 0;

            void RecursiveToArray(BinaryTreeNode node)
            {
                if (node != null)
                {
                    RecursiveToArray(node.Left!);
                    result[index++] = node.Key;
                    RecursiveToArray(node.Right!);
                }
            }

            RecursiveToArray(Root!);
            return result;
        }
    }
}
