Teste<int> teste = new Teste<int>();
teste.Executar();

class Teste<T> where T : IComparable<T>
{
    public ArvoreBinariaPesquisa<int> arvore = new ArvoreBinariaPesquisa<int>();

    public void Executar()
    {
        arvore.Insert(8);
        arvore.Insert(3);
        arvore.Insert(10);
        arvore.Insert(1);
        arvore.Insert(6);
        arvore.Insert(4);
        arvore.Insert(7);
        arvore.Insert(14);
        arvore.Insert(13);

        arvore.Arvore();
        Console.WriteLine("\n");

        arvore.PreOrder();
        // ORDEM
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
        Console.WriteLine("\n");

        arvore.InOrder();
        // ORDEM
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
        Console.WriteLine("\n");

        arvore.PostOrder();
        // ORDEM
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
        Console.WriteLine("\n");
    }
}