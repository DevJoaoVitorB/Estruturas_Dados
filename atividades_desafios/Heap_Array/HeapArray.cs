public class HeapArray<T> : IHeap<T> where T : IComparable<T>
{
    private int capacidade;
    private int tamanho;
    private T[] array;

    public HeapArray(int capacidade)
    {
        this.capacidade = capacidade;
        array = new T[capacidade + 1];
        tamanho = 0;
    }

    public int Size() => tamanho;
    public bool IsEmpty() => tamanho == 0;

    public void Insert(T key)
    {
        if (tamanho >= capacidade)
            throw new InvalidOperationException("Heap Cheio!");

        tamanho++;
        array[tamanho] = key;

        UpHeap();
    }

    public T RemoveMin()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Heap Vazio!");

        T removido = array[1];
        array[1] = array[tamanho];

        DownHeap();
        tamanho--;
        return removido;
    }

    public T Min()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Heap Vazio!");
        return array[1];
    }
    public void UpHeap()
    {
        int aux = tamanho;

        while (aux > 1)
        {
            int paiIndex = aux / 2;
            if (array[aux].CompareTo(array[paiIndex]) >= 0)
                break;

            T key = array[aux];
            array[aux] = array[paiIndex];
            array[paiIndex] = key;

            aux = paiIndex;
        }
    }

    public void DownHeap()
    {
        int aux = 1;

        while (aux * 2 <= tamanho)
        {
            int filhoEsquerdo = aux * 2;
            int filhoDireito = aux * 2 + 1;
            int menorFilho = filhoEsquerdo;

            if (filhoDireito <= tamanho && array[filhoDireito].CompareTo(array[filhoEsquerdo]) < 0)
                menorFilho = filhoDireito;

            if (array[aux].CompareTo(array[menorFilho]) <= 0)
                break;

            T temp = array[aux];
            array[aux] = array[menorFilho];
            array[menorFilho] = temp;

            aux = menorFilho;
        }
    }
}
