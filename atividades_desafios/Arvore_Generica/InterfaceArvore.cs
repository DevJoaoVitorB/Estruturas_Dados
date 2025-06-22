public interface IArvore<T> where T : IComparable<T>
{
    // Métodos Genéricos
    int Size();
    bool IsEmpty();
    IEnumerator<T> Elements();
    IEnumerator<Node<T>> Nodes();

    // Métodos de Acesso
    Node<T> GetRoot();
    Node<T>? Parent(Node<T> child);
    IEnumerator<Node<T>> Children(Node<T> parent);

    // Métodos de Consulta
    bool IsRoot(Node<T>? node);
    int Height(Node<T> node);
    int Depth(Node<T> node);

    // Métodos de Atualização
    void AddChild(Node<T> parent, T newElement);
    T? Remove(Node<T> node);
    void SwapElement(Node<T> node1, Node<T> node2);
    T Replace(Node<T> node, T element);

    // Métodos de Travessia
    void PreOrder();
    void PostOrder();
}