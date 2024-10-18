using System.Collections;

namespace Cspro.Collection.Interfaces
{
    public interface IBinaryTreeNode : IComparable
    {
        IBinaryTreeNode Left { get; set; }
        IBinaryTreeNode Right { get; set; }
        IComparable Value { get; }
    }
}
