interface IHASH<T>
{
    T? FindItem(int key);
    void InsertItem(int key, T item);
    Node<T>? RemoveItem(int key);
    int Size();
    bool IsEmpty();
    IEnumerator<int> Keys();
    IEnumerator<T> Itens();
}