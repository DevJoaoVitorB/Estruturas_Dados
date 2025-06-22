TesteArvoreGenerica.Executar();

public static class TesteArvoreGenerica
{
    private static ArvoreGenerica<string> arvore = new ArvoreGenerica<string>("A");

    public static void Executar()
    {
        // Criar nós filhos diretamente para teste
        Node<string> raiz = arvore.GetRoot();
        
        // Adicionar filhos na raiz
        arvore.AddChild(raiz, "B");
        arvore.AddChild(raiz, "C");

        // Pegar referências dos filhos para adicionar netos
        IEnumerator<Node<string>> filhosRaiz = raiz.GetChildren();
        List<Node<string>> filhos = new List<Node<string>>();
        while (filhosRaiz.MoveNext())
            filhos.Add(filhosRaiz.Current);

        // Adicionar filhos em "B"
        arvore.AddChild(filhos[0], "D");
        arvore.AddChild(filhos[0], "E");

        // Mostrar tamanho (quantidade de nós)
        Console.WriteLine("Tamanho da árvore: " + arvore.Size());

        // Mostrar altura da raiz
        Console.WriteLine("Altura da raiz: " + arvore.Height(raiz));

        // Mostrar profundidade do nó "E"
        Node<string> noE = filhos[0].GetChildren().Current; // cuidado, pegar com MoveNext se quiser exato
        // Melhor pegar iterador e avançar:
        IEnumerator<Node<string>> itE = filhos[0].GetChildren();
        itE.MoveNext();
        Node<string> noD = itE.Current;
        itE.MoveNext();
        Node<string> noE_real = itE.Current;
        Console.WriteLine($"Profundidade do nó {noE_real.GetElement()}: " + arvore.Depth(noE_real));

        // Mostrar elementos da árvore (pré-ordem implícita)
        Console.Write("Elementos da árvore: ");
        IEnumerator<string> elementos = arvore.Elements();
        while (elementos.MoveNext())
            Console.Write(elementos.Current + " ");
        Console.WriteLine();

        // Testar remoção de nó externo (ex: nó "E")
        var removido = arvore.Remove(noE_real);
        Console.WriteLine("Elemento removido: " + (removido ?? "null"));

        // Mostrar tamanho após remoção
        Console.WriteLine("Tamanho após remoção: " + arvore.Size());

        // Trocar elementos entre "B" e "C"
        arvore.SwapElement(filhos[0], filhos[1]);
        Console.WriteLine("Elementos após troca entre B e C:");
        elementos = arvore.Elements();
        while (elementos.MoveNext())
            Console.Write(elementos.Current + " ");
        Console.WriteLine();

        // Substituir elemento "D" por "X"
        var antigo = arvore.Replace(noD, "X");
        Console.WriteLine($"Elemento substituído: {antigo}");

        // Mostrar pré-ordem
        Console.Write("Pré-Ordem: ");
        arvore.PreOrder();
        Console.WriteLine();

        // Mostrar pós-ordem
        Console.Write("Pós-Ordem: ");
        arvore.PostOrder();
        Console.WriteLine();
    }
}
