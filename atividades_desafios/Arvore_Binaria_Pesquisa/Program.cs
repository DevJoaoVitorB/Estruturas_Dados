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

        // Visualizando Árvore Estrutural
        arvore.Arvore();
        Console.WriteLine("\n");

        // Modos de Travessia da Árvore
        arvore.PreOrder();
        Console.WriteLine("\n");

        arvore.InOrder();
        Console.WriteLine("\n");

        arvore.PostOrder();
        Console.WriteLine("\n");

        // Remoção da Árvore
        // CASO 1 - Sem Filhos
        arvore.Remove(4);
        arvore.Arvore();
        Console.WriteLine("\n");

        // CASO 2 - 1 Filho
        arvore.Remove(6);
        arvore.Arvore();
        Console.WriteLine("\n");

        // Caso 3 - 2 Filhos
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
 