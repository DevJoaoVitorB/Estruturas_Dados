TesteHeap.Executar();

public class TesteHeap
{
    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine("=== Teste do TAD Heap ===\n");

        Heap<Node<string>> heap = new Heap<Node<string>>(15); // Heap com capacidade para 15 elementos

        // Inserções
        Console.WriteLine("Inserindo elementos no Heap...\n");

        heap.Insert(10, new Node<string>(10, "A"));
        heap.Insert(7, new Node<string>(7, "B"));
        heap.Insert(9, new Node<string>(9, "C"));
        heap.Insert(3, new Node<string>(3, "D"));
        heap.Insert(6, new Node<string>(6, "E"));
        heap.Insert(5, new Node<string>(5, "F"));
        heap.Insert(8, new Node<string>(8, "G"));

        Console.WriteLine("Heap estrutural após inserções:");
        heap.PrintHeap();

        // Verificando raiz
        Console.WriteLine("Raiz do Heap (Min):");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(heap.Min());
        Console.ResetColor();

        // Remoção
        Console.WriteLine("\nRemovendo elemento da raiz...");
        var removido = heap.RemoveMin();
        Console.WriteLine($"Elemento removido: {removido}");

        Console.WriteLine("\nHeap estrutural após remoção:");
        heap.PrintHeap();

        Console.WriteLine("\nTamanho atual do Heap: " + heap.Size());
        Console.WriteLine("\nHeap vazio? " + (heap.IsEmpty() ? "Sim" : "Não"));
    }
}