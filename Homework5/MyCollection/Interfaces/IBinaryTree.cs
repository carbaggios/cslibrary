using System.Collections;

namespace Cspro.Collection.Interfaces
{
    public interface IBinaryTree : ICollection
    {
        IBinaryTreeNode Root { get; }
        IBinaryTreeNode Add(IComparable value);
    }
}
