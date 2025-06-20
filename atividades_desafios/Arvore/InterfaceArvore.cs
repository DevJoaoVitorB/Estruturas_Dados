public interface IArvore<T> where T : IComparable<T>
{
    int Size();
    bool IsEmpty();
    bool IsRoot(Node<T> node);
    int Height(Node<T> node);
    int Depth(Node<T> node);
    void Insert(T element);
    void Remove(T key);
    Node<T>? Find(T key);
    void PreOrder();
    void InOrder();
    void PostOrder();
}