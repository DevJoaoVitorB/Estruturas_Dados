using System.Collections;

public class Node<T>
{
    private T Data;
    private Node<T> Parent;
    private ArrayList Children;

    public Node(T data, Node<T> parent)
    {
        Data = data;
        Parent = parent;
        Children = new ArrayList();
    }

    // Métodos GET e SET para o Dado do Nó
    public T GetData() => Data;
    public void SetData(T newData) => Data = newData;

    // Métodos GET e SET para o Pai do Nó
    public Node<T> GetParent() => Parent;
    public void SetParent(Node<T> newParent) => Parent = newParent;

    // Métodos GET, ADD e COUNT para os Filhos do Nó
    public IEnumerator GetChildren() => Children.GetEnumerator();
    public void AddChild(Node<T> newChild) => Children.Add(newChild);
    public int ChildrenNumber() => Children.Count;
}