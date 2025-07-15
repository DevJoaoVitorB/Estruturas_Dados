class HASH<T> : IHASH<T>
{
    private int capacity;
    private int size;
    private Node<T>[] array;

    public HASH(int capacity)
    {
        this.capacity = capacity;
        size = 0;
        array = new Node<T>[capacity];
    }

    public int Size() => size;
    public bool IsEmpty() => size == 0;

    public T? FindItem(int key)
    {
        return default;
    }
    public void InsertItem(int key, T item)
    {
        Node<T> newItem = new Node<T>(key, item);

        int position = key % capacity;

        if (array[position] == null)
            array[position] = newItem;
        else
        {
            
        }
    }

    public Node<T>? RemoveItem(int key)
    {
        return null;
    }

    public IEnumerator<int> Keys()
    {
        return null;
    }

    public IEnumerator<T> Itens()
    {
        return null;
    }

    private void LinearProbing(int key)
    {

    }

    private void DoubleHashing(int key)
    {
        
    }
}