TesteArvoreBinariaPesquisa<int>.Executar();

static class TesteArvoreBinariaPesquisa<T> where T : IComparable<T>
{
    private static ArvoreBinariaPesquisa<int> arvore = new ArvoreBinariaPesquisa<int>();

    public static void Executar()
    {
        // Inserindo Valores
        arvore.Insert(8);
        arvore.Insert(3);
        arvore.Insert(10);
        arvore.Insert(1);
        arvore.Insert(6);
        arvore.Insert(4);
        arvore.Insert(7);
        arvore.Insert(14);
        arvore.Insert(13);

        // Verificar Tamanho da Árvore
        Console.WriteLine("Tamanho da árvore: " + arvore.Size());

        // Visualizando Árvore Estrutural
        Console.WriteLine("\nÁrvore estruturada:");
        arvore.Arvore();
        Console.WriteLine("\n");

        // Modos de Travessia da Árvore
        Console.Write("\nElementos em ordem (InOrder): ");
        arvore.PreOrder();
        Console.WriteLine("\n");

        Console.Write("\nElementos em pré-ordem (PreOrder): ");
        arvore.InOrder();
        Console.WriteLine("\n");

        Console.Write("\nElementos em pós-ordem (PostOrder): ");
        arvore.PostOrder();
        Console.WriteLine("\n");

        // Buscar alguns valores
        int[] buscas = { 6, 15 };
        foreach (var key in buscas)
        {
            var node = arvore.Find(key);
            Console.WriteLine(node != null
                ? $"Elemento {key} encontrado."
                : $"Elemento {key} não encontrado.");
        }

        // Mostrar altura e profundidade de algum nó
        Node<int> root = arvore.GetRoot();
        if (root != null)
        {
            Console.WriteLine($"Altura da raiz ({root.GetElement()}): {arvore.Height(root)}");

            // Profundidade do nó 14 (se existir)
            Node<int> no14 = arvore.Find(14);
            if (no14 != null)
                Console.WriteLine($"Profundidade do nó 14: {arvore.Depth(no14)}");
        }
        
        // Remoção da Árvore
        // CASO 1 - Sem Filhos
        Console.WriteLine("\nCASO 1 - Nó sem Filhos (4)");
        Console.WriteLine("\nÁrvore estruturada após remoção:");
        arvore.Remove(4);
        arvore.Arvore();
        Console.WriteLine("\n");

        // CASO 2 - 1 Filho
        Console.WriteLine("\nCASO 2 - Nó com 1 Filho (6)");
        Console.WriteLine("\nÁrvore estruturada após remoção:");
        arvore.Remove(6);
        arvore.Arvore();
        Console.WriteLine("\n");

        // Caso 3 - 2 Filhos
        Console.WriteLine("\nCASO 3 - Nó com 2 Filhos (8)");
        Console.WriteLine("\nÁrvore estruturada após remoção:");
        arvore.Remove(8);
        arvore.Arvore();
        Console.WriteLine("\n");
    }
}

// Algoritmos de Travessia

// PreOrder
// Fluxo de Travessia:
// 8 + ->E + ->D
// ├── 3 + ->E + ->D
// │   ├── 1 + ->E + ->D
// │   │   ├── null
// │   │   └── null
// │   └── 6 + ->E ->D
// │       ├── 4 + ->E + ->D
// │       │   ├── null
// │       │   └── null
// │       └── 7 + ->E + ->D
// │           ├── null
// │           └── null
// └── 10 + ->E + ->D
//     ├── null
//     └── 14 + ->E + ->D
//         ├── 13 + ->E + ->D
//         │   ├── null
//         │   └── null
//         └── null

// InOrder
// Fluxo de Travessia:
// 8->E 
// ├── 3->E 
// │   ├── 1->E 
// │   │   └── null 
// │   ├── 1 + ->D
// │   │   └── null 
// │   3 + -> D
// │   └── 6->E 
// │       ├── 4->E 
// │       │   └── null 
// │       ├── 4 + ->D
// │       │   └── null 
// │       6 + -> D
// │       ├── 7->E 
// │       │   └── null 
// │       └── 7 + -> D
// │           └── null 
// 8 + ->D
// ├── 10->E 
// │   └── null 
// └── 10 + ->D 
//     └── 14->E 
//         ├── 13->E 
//         │   └── null 
//         ├── 13 + ->D 
//         │   └── null 
//         14 + ->D           
//         └── null

// PostOrder
// Fluxo de Travessia:
// 8->E
// ├── 3->E
// │   ├── 1->E 
// │   │   └── null  
// │   ├── 1->D 
// │   │   └── null 
// │   ├── 1 
// │   3->D 
// │   ├── 6->E  
// │   3   ├── 4->E 
// │       │   └── null
// │       ├── 4->D 
// │       │   └── null 
// │       ├── 4 
// │       6->D 
// │       ├── 7->E 
// │       │   └── null 
// │       ├── 7->D 
// │       │   └── null 
// │       ├── 7 
// │       6 
// │ 
// 8->D 
// ├── 10->E
// │   └── null 
// ├── 10->D 
// 8   ├── 14->E 
//     10  ├── 13->E 
//         │   └── null 
//         ├── 13->D 
//         │   └── null 
//         ├── 13 
//         14->D 
//         ├── null 
//         14 
 