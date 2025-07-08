public class Heap<T> : IHeap<T>
{
    private int capacity;
    private int size;
    private Node<T>[] array;

    public Heap(int capacity)
    {
        this.capacity = capacity;
        size = 0;
        array = new Node<T>[capacity + 1];
    }

    public int Size() => size;
    public bool IsEmpty() => size == 0;
    public int Height()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Heap Vazio!");
        return (int)Math.Floor(Math.Log2(size));
    }

    public void Insert(int key, T element)
    {
        if (size >= capacity)
            throw new InvalidOperationException("Heap cheio");

        Node<T> newElement = new Node<T>(key, element);

        size++;
        array[size] = newElement;
        UpHeap();
    }

    public T RemoveMin()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Heap vazio!");

        Node<T> root = array[1];

        array[1] = array[size];
        array[size] = null;
        size--;
        DownHeap();

        return root.GetElement();
    }

    public T Min() => array[1].GetElement();
    public int MinKey() => array[1].GetKey();


    public void UpHeap()
    {
        int aux = size;
        Node<T> lastInsert = array[aux];

        while (aux > 1 && lastInsert.GetKey() < array[aux / 2].GetKey())
        {
            array[aux] = array[aux / 2];
            aux /= 2;
        }

        array[aux] = lastInsert;
    }

    public void DownHeap()
    {
        int aux = 1;
        Node<T> peek = array[aux];

        while (aux * 2 <= size)
        {
            int lChild = aux * 2;
            int rChild = lChild + 1;

            int minChild = lChild;

            // Se o filho direito existir e for menor que o esquerdo
            if (rChild <= size && array[rChild].GetKey() < array[lChild].GetKey())
            {
                minChild = rChild;
            }

            // Se o elemento atual já é menor ou igual ao menor filho, está no lugar certo
            if (peek.GetKey() <= array[minChild].GetKey())
                break;

            // Move o menor filho para cima
            array[aux] = array[minChild];
            aux = minChild;
        }

        array[aux] = peek;
    }

    public void PrintHeap()
    {
        if (IsEmpty())
        {
            Console.WriteLine("[Heap vazio]");
            return;
        }

        int h = (int)Math.Floor(Math.Log2(size)) + 1;
        int maxWidth = (int)Math.Pow(2, h); // Largura total estimada
        int index = 1;

        for (int level = 0; level < h; level++)
        {
            int nodesAtLevel = (int)Math.Pow(2, level);
            int spaceBetween = maxWidth / nodesAtLevel;

            // Espaçamento inicial antes do primeiro nó
            Console.Write(new string(' ', spaceBetween / 2));

            for (int i = 0; i < nodesAtLevel && index <= size; i++)
            {
                string valor = array[index].GetElement().ToString();
                Console.Write(valor.PadLeft(2).PadRight(spaceBetween));
                index++;
            }

            Console.WriteLine("\n");
        }
    }
}