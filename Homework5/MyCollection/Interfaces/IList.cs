namespace Cspro.Collection.Interfaces
{
    public interface IList : ICollection
    {
        object this[int index] { get; set; }
        int Capacity { get; }
        int Add(object value);
        void Insert(int index, object value);
        void Remove(object value);
        void RemoveAt(int index);
        int IndexOf(object value);
        void Reverse();
    }
}
