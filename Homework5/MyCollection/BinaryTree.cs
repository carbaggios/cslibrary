using Cspro.Collection.Interfaces;

namespace Cspro.Collection
{
    public class BinaryTreeNode : IBinaryTreeNode
    {
        public IBinaryTreeNode? Left { get; set; }

        public IBinaryTreeNode? Right { get; set; }

        public IComparable Value { get; private set; }

        public BinaryTreeNode(IComparable value)
        {
            Value = value;
            Left = Right = null;
        }

        public override string? ToString()
        {
            return Value.ToString();
        }

        public int CompareTo(object obj)
        {
            var otherNode = obj as IBinaryTreeNode;
            return Value.CompareTo(otherNode != null ? otherNode.Value : obj);
        }
    }

    public class BinaryTree : IBinaryTree
    {
        public IBinaryTreeNode? Root { get; private set; }

        public int Count { get; private set; }

        public System.Collections.IEnumerator GetEnumerator() => new BinaryTreeEnumerator(Root!);

        public IBinaryTreeNode Add(IComparable value)
        {
            Root = Add(Root!, value);
            return Root;
        }

        private IBinaryTreeNode Add(IBinaryTreeNode root, IComparable value)
        {
            if (root == null)
            {
                root = new BinaryTreeNode(value);
                Count++;
                return root;
            }

            var compareResult = value.CompareTo(root.Value);
            if (compareResult < 0)
            {
                root.Left = Add(root.Left, value);
            }
            else if (compareResult > 0)
            {
                root.Right = Add(root.Right!, value);
            }

            return root;
        }

        public bool Contains(object value) => Contains(Root, ((IComparable)value));

        private bool Contains(IBinaryTreeNode? root, IComparable value)
        {
            if (root == null || root.Value.CompareTo(value) == 0)
                return root != null;

            if (value.CompareTo(root.Value) < 0)
                return Contains(root.Left, value);
            else
                return Contains(root.Right, value);
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public object[] ToArray()
        {
            object[] result = new object[Count];
            int index = 0;

            void RecursiveToArray(IBinaryTreeNode node)
            {
                if (node != null)
                {
                    RecursiveToArray(node.Left!);
                    result[index++] = node.Value;
                    RecursiveToArray(node.Right!);
                }
            }

            RecursiveToArray(Root!);
            return result;
        }

        private class MoveState : BinaryTreeEnumeratorState
        {

            [System.Flags]
            private enum MoveStateStatus
            {

                New = 0,
                LeftDone = 1,
                RightDone = 2,
                AllDone = LeftDone | RightDone,
            }

            private MoveStateStatus status = MoveStateStatus.New;

            public MoveState(IBinaryTreeNode previos, IBinaryTreeNode current, BinaryTreeEnumeratorState prevState)
              : base(previos, current, prevState)
            {
            }

            public override BinaryTreeEnumeratorState ChangeState()
            {

                if (CurrentNode.Left != null && !status.HasFlag(MoveStateStatus.LeftDone))
                {
                    status |= MoveStateStatus.LeftDone;
                    return new MoveState(CurrentNode, CurrentNode.Left, this);
                }
                else if (CurrentNode.Right != null && !(status.HasFlag(MoveStateStatus.RightDone)))
                {
                    status |= MoveStateStatus.RightDone;
                    return new MoveState(CurrentNode, CurrentNode.Right, this);
                }
                else if (PreviosState != null)
                    return PreviosState.ChangeState();
                else
                    return new DoneState();
            }
        }

        private class DoneState : BinaryTreeEnumeratorState
        {
            public DoneState() : base(null, null, null) { }

            public override BinaryTreeEnumeratorState ChangeState() => this;
        }

        private abstract class BinaryTreeEnumeratorState
        {
            public readonly IBinaryTreeNode CurrentNode;
            public readonly IBinaryTreeNode PreviosNode;
            public readonly BinaryTreeEnumeratorState PreviosState;

            public BinaryTreeEnumeratorState(IBinaryTreeNode previos, IBinaryTreeNode current, BinaryTreeEnumeratorState prevState)
            {
                this.PreviosNode = previos;
                this.CurrentNode = current;
                this.PreviosState = prevState;
            }

            public abstract BinaryTreeEnumeratorState ChangeState();
        }

        private class BinaryTreeEnumerator : System.Collections.IEnumerator
        {

            private IBinaryTreeNode root;
            private BinaryTreeEnumeratorState state;

            public BinaryTreeEnumerator(IBinaryTreeNode root)
            {
                this.root = root;
            }

            public object Current => state.CurrentNode.Value;

            public bool MoveNext()
            {
                if (state == null)
                {
                    state = new MoveState(null, root, null);
                    return true;
                }
                return !((state = state.ChangeState()) is DoneState);
            }

            public void Reset()
            {
                state = null;
            }
        }
    }
}
