public class Node<T>
{
    private int key;
    private T element;

    public Node(int key, T element)
    {
        this.element = element;
        this.key = key;
    }

    // Getters e Setters
    public int GetKey() => key;
    public void SetKey(int newKey) => key = newKey;

    public T GetElement() => element;
    public void SetElement(T newElement) => element = newElement;

    public override string ToString() => $" {key}-{element} ";
}