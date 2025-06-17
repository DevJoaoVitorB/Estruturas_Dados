using System.Collections;

public interface IArvore<T>
{
    // Métodos Genéricos
    int Size();
    bool IsEmpty();
    int Height();
    IEnumerable Elements();
    IEnumerable Nos();

    // Métodos de Acesso
    Node<T> Root();
    Node<T> Parent(Node<T> child);
    IEnumerator Children(Node<T> parent);

    // Métodos de Consulta
    bool IsInternal(Node<T> node);
    bool IsExternal(Node<T> node);
    bool IsRoot(Node<T> node);
    int Depth(Node<T> node);
    Node<T> Find(T element);

    // Métodos de Atualização
    void SwapElements(Node<T> node1, Node<T> node2);
    T Replace(Node<T> node, T element);

    // Métodos de Persistencia
    void AddChild(T referenceElement, T newElement);
    T Remove(Node<T> removeNode);
}