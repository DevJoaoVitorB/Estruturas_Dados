class Node<T>
{
    private int key;
    private T item;

    public Node(int key, T item)
    {
        this.key = key;
        this.item = item;
    }

    // Getters e Setters
    public int GetKey() => key;
    public void SetKey(int newKey) => key = newKey;

    public T GetItem() => item;
    public void SetItem(T newItem) => item = newItem;

    public override string ToString() => $" {key}-{item} ";
}