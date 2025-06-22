public interface IArvore<T> where T : IComparable<T>
{
    // Métodos Genéricos
    int Size();
    bool IsEmpty();
    IEnumerator<T> Elements();
    IEnumerator<Node<T>> Nodes();

    // Métodos de Acesso
    Node<T>? GetRoot();
    Node<T>? Parent(Node<T> child);
    IEnumerator<Node<T>> Children(Node<T> parent);

    // Métodos de Consulta
    bool IsRoot(Node<T> node);
    int Height(Node<T> node);
    int Depth(Node<T> node);
    Node<T>? Find(T key);

    // Métodos de Atualização
    void Insert(T element);
    void Remove(T key);

    // Métodos de Travessia
    void PreOrder();
    void InOrder();
    void PostOrder();
}