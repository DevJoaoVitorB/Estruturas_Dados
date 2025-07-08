interface IHeap<T>
{
    // Métodos principais de Heap (MinHeap)
    void Insert(int key, T element);
    T RemoveMin();
    T Min();
    int MinKey();

    // Métodos de Informação
    int Size();
    bool IsEmpty();
    int Height();
}