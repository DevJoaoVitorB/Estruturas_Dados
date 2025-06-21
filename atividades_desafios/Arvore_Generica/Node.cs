using System.Collections;

public class Node<T> where T : IComparable<T>
{
    private T Element;
    private Node<T>? Parent;
    private List<Node<T>> Children;

    public Node(T element, Node<T>? parent = default)
    {
        Element = element;
        Parent = parent;
        Children = new List<Node<T>>();
    }

    // Métodos GET e SET para o Dado do Nó
    public T GetElement() => Element;
    public void SetElement(T newElement) => Element = newElement;

    // Métodos GET e SET para o Pai do Nó
    public Node<T>? GetParent() => Parent;
    public void SetParent(Node<T> newParent) => Parent = newParent;

    // Métodos GET, ADD, REMOVE e COUNT para os Filhos do Nó
    public IEnumerator GetChildren() => Children.GetEnumerator();
    public void AddChild(Node<T>? newChild) => Children.Add(newChild);
    public void RemoveChild(Node<T>? child) => Children.Remove(child);
    public int CountChildren() => Children.Count;

    // Verificar se o Nó é Interno ou Externo - Verificar se o Nó possui Filho ou Não
    public bool IsInternal() => CountChildren() > 0;
    public bool IsExternal() => CountChildren() == 0;
}