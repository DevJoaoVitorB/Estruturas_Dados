using System.Collections;

TesteArvoreGenerica.Executar();

public static class TesteArvoreGenerica
{
    private static ArvoreGenerica<string> arvore = new ArvoreGenerica<string>("A");

    public static void Executar()
    {
        Node<string> raiz = arvore.GetRoot();

        // Adicionar filhos à raiz
        arvore.AddChild(raiz, "B");
        arvore.AddChild(raiz, "C");
        arvore.AddChild(raiz, "D");

        // Adicionar filhos a B
        IEnumerator filhosRaiz = arvore.Children(raiz);
        Node<string> noB = null;
        while (filhosRaiz.MoveNext())
        {
            Node<string> filho = (Node<string>)filhosRaiz.Current;
            if (filho.GetElement() == "B")
            {
                noB = filho;
                break;
            }
        }

        if (noB != null)
        {
            arvore.AddChild(noB, "E");
            arvore.AddChild(noB, "F");
        }

        // 🔎 Travessias
        Console.WriteLine("📌 Pré-Ordem:");
        arvore.PreOrder();

        Console.WriteLine("\n\n📌 Pós-Ordem:");
        arvore.PostOrder();

        // 📏 Altura, profundidade e tamanho
        Console.WriteLine($"\n\n📏 Altura da árvore: {arvore.Height(raiz)}");
        Console.WriteLine($"📍 Profundidade de B: {arvore.Depth(noB)}");
        Console.WriteLine($"📦 Tamanho da árvore: {arvore.Size()}");

        // 📦 Elements
        Console.WriteLine("\n🧺 Elementos:");
        IEnumerator elementos = arvore.Elements(raiz);
        while (elementos.MoveNext())
        {
            string el = (string)elementos.Current;
            Console.Write(el + " ");
        }

        // 📦 Nodes
        Console.WriteLine("\n\n🔗 Nós:");
        IEnumerator nos = arvore.Nodes(raiz);
        while (nos.MoveNext())
        {
            Node<string> no = (Node<string>)nos.Current;
            Console.Write(no.GetElement() + " ");
        }

        // 🔁 Swap entre B e C
        Console.WriteLine("\n\n🔁 Fazendo swap entre B e C...");
        Node<string> noC = null;
        filhosRaiz = arvore.Children(raiz);
        while (filhosRaiz.MoveNext())
        {
            Node<string> filho = (Node<string>)filhosRaiz.Current;
            if (filho.GetElement() == "C") noC = filho;
        }

        arvore.SwapElement(noB, noC);
        arvore.PreOrder();

        // 🔁 Replace D → X
        Console.WriteLine("\n\n✏️ Substituindo D por X...");
        Node<string> noD = null;
        filhosRaiz = arvore.Children(raiz);
        while (filhosRaiz.MoveNext())
        {
            Node<string> filho = (Node<string>)filhosRaiz.Current;
            if (filho.GetElement() == "D") noD = filho;
        }

        arvore.Replace(noD, "X");
        arvore.PreOrder();

        Console.WriteLine("\n");
    }
}
