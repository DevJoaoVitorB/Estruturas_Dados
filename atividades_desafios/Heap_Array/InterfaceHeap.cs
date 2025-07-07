using System.Collections;

interface IHeap<T>
{
    void Insert(T key);
    T RemoveMin();
    T Min();
    int Size();
    bool IsEmpty();

    void UpHeap();
    void DownHeap();
}