TesteHeap.Executar();

class TesteHeap
{
    public static void Executar()
    {
        Console.WriteLine("🔍 Iniciando Testes do TAD HeapArray<T>...\n");

        try
        {
            // Cria um heap com capacidade para 5 elementos
            HeapArray<int> heap = new HeapArray<int>(5);

            Console.WriteLine($"✅ Heap criado. Está vazio? {heap.IsEmpty()} (esperado: true)");

            // Inserção de elementos
            heap.Insert(10);
            heap.Insert(5);
            heap.Insert(20);
            heap.Insert(1);
            heap.Insert(15);

            Console.WriteLine($"📌 Após inserções, tamanho: {heap.Size()} (esperado: 5)");
            Console.WriteLine($"🔎 Min: {heap.Min()} (esperado: 1)");

            // Tentativa de inserir além da capacidade
            try
            {
                heap.Insert(25);
                Console.WriteLine("❌ Erro: foi possível inserir além da capacidade.");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"✅ Exceção esperada ao exceder capacidade: {e.Message}");
            }

            // Remoção dos elementos em ordem crescente
            Console.WriteLine("\n🧹 Removendo elementos (esperado em ordem crescente):");
            while (!heap.IsEmpty())
            {
                Console.WriteLine($"➡️ RemoveMin(): {heap.RemoveMin()}");
            }

            // Tentativa de remover de heap vazio
            try
            {
                heap.RemoveMin();
                Console.WriteLine("❌ Erro: foi possível remover de heap vazio.");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"✅ Exceção esperada ao remover de heap vazio: {e.Message}");
            }

            // Tentativa de acessar o mínimo de heap vazio
            try
            {
                heap.Min();
                Console.WriteLine("❌ Erro: foi possível acessar Min de heap vazio.");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"✅ Exceção esperada ao acessar Min em heap vazio: {e.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Erro inesperado durante os testes: {ex.Message}");
        }

        Console.WriteLine("\n✔️ Testes do TAD HeapArray<T> finalizados.");
    }
}
