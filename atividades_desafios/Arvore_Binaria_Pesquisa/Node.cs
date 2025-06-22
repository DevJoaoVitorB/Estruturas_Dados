public class Node<T> where T : IComparable<T>
{
    private T Element;
    private Node<T>? Parent;
    private Node<T>? LChild;
    private Node<T>? RChild;

    public Node(T element, Node<T>? parent = default)
    {
        Element = element;
        Parent = parent;
    }

    // Métodos GET e SET para o Dado do Nó
    public T GetElement() => Element;
    public void SetElement(T newElement) => Element = newElement;

    // Métodos GET e SET para o Pai do Nó
    public Node<T>? GetParent() => Parent;
    public void SetParent(Node<T> newParent) => Parent = newParent;

    // Métodos GET e SET para os Filhos do Nó
    public Node<T>? GetLeftChild() => LChild;
    public Node<T>? GetRightChild() => RChild;
    public void SetLeftChild(Node<T>? newLChild)
    {
        LChild = newLChild;
        if (newLChild != null)
            newLChild.SetParent(this);
    }
    public void SetRightChild(Node<T>? newRChild)
    {
        RChild = newRChild;
        if (newRChild != null)
            newRChild.SetParent(this);
    }
    public IEnumerator<Node<T>> GetChildren()
    {
        List<Node<T>> children = new List<Node<T>>();

        if (GetLeftChild() != null)
            children.Add(GetLeftChild());
        if (GetRightChild() != null)
            children.Add(GetRightChild());

        return children.GetEnumerator();
    }

    // Verificar se o Nó é Interno ou Externo - Verificar se o Nó possui Filho ou Não
    public bool IsExternal() => LChild == null && RChild == null;
    public bool IsInternal() => !IsExternal();
}