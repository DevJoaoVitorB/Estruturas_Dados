public class ArvoreBinariaPesquisa<T> : IArvore<T> where T : IComparable<T>
{
    private Node<T>? Root;

    public ArvoreBinariaPesquisa()
    {
        Root = null;
    }

    // Métodos Tamanho e Está Vazio
    public int Size() => NodeCount(Root);
    public bool IsEmpty() => Root == null;

    // Método de Verificação de Raiz
    public bool IsRoot(Node<T>? node) => node == Root;

    // Método para Contar a Quantidade de Nós
    private int NodeCount(Node<T>? node)
    {
        if (node == null) return 0;
        return 1 + NodeCount(node.GetLeftChild()) + NodeCount(node.GetRightChild());
    }

    // Método de Calculo da Altura
    public int Height(Node<T> node) => HeightCalc(node);
    private int HeightCalc(Node<T>? node)
    {
        if (node == null) return -1;
        return 1 + Math.Max(HeightCalc(node.GetLeftChild()), HeightCalc(node.GetRightChild()));
    }

    // Método de Calculo de Profundidade
    public int Depth(Node<T>? node) => DepthCalc(node);
    private int DepthCalc(Node<T>? node)
    {
        if (IsRoot(node)) return 0;
        return 1 + DepthCalc(node.GetParent());
    }

    // Método para Inserir um Novo Nó na Árvore
    public void Insert(T element) => Root = InsertOperation(Root, element, default);
    private Node<T> InsertOperation(Node<T>? node, T element, Node<T>? parent)
    {
        if (node == null)
            return new Node<T>(element, parent);

        if (element.CompareTo(node.GetElement()) < 0)
            node.SetLeftChild(InsertOperation(node.GetLeftChild(), element, node));
        else
            node.SetRightChild(InsertOperation(node.GetRightChild(), element, node));

        return node;
    }

    // Método de Busca para Nó com Chave X
    public Node<T>? Find(T key) => FindOperation(Root, key);
    private Node<T>? FindOperation(Node<T>? node, T key)
    {
        if (node == null || key.CompareTo(node.GetElement()) == 0)
            return node;

        if (key.CompareTo(node.GetElement()) < 0)
            return FindOperation(node.GetLeftChild(), key);
        else
            return FindOperation(node.GetRightChild(), key);
    }

    // Método para Remove um Nó com Chave X
    public void Remove(T key) => Root = RemoveOperation(Root, key);
    private Node<T>? RemoveOperation(Node<T>? node, T key)
    {
        if (node == null)
            return null;

        if (key.CompareTo(node.GetElement()) < 0)
            node.SetLeftChild(RemoveOperation(node.GetLeftChild(), key));
        else if (key.CompareTo(node.GetElement()) > 0)
            node.SetRightChild(RemoveOperation(node.GetRightChild(), key));
        else
        {
            if (node.GetLeftChild() == null)
                return node.GetRightChild();
            if (node.GetRightChild() == null)
                return node.GetLeftChild();

            Node<T> successor = Successor(node.GetRightChild());
            node.SetElement(successor.GetElement());
            node.SetRightChild(RemoveOperation(node.GetRightChild(), successor.GetElement()));
        }

        return node;
    }

    // Método para encontrar o Sucessor do Nó Removido quando esse possui 2 Filhos
    private Node<T> Successor(Node<T>? node)
    {
        while (node.GetLeftChild() != null)
            node = node.GetLeftChild();

        return node;
    }

    // Métodos de Travessia
    public void PreOrder() => PreOrderTraversal(Root);
    private void PreOrderTraversal(Node<T>? node)
    {
        if (node == null)
            return;

        Console.WriteLine(node.GetElement() + " - ");
        PreOrderTraversal(node.GetLeftChild());
        PreOrderTraversal(node.GetRightChild());
    }

    public void InOrder() => InOrderTraversal(Root);
    private void InOrderTraversal(Node<T>? node)
    {
        if (node == null)
            return;

        InOrderTraversal(node.GetLeftChild());
        Console.WriteLine(node.GetElement() + " - ");
        InOrderTraversal(node.GetRightChild());
    }

    public void PostOrder() => PostOrderTraversal(Root);
    private void PostOrderTraversal(Node<T>? node)
    {
        if (node == null)
            return;

        PostOrderTraversal(node.GetLeftChild());
        PostOrderTraversal(node.GetRightChild());
        Console.WriteLine(node.GetElement() + " - ");
    }


    // Imprimir a Árvore em Formato Estrutural
    public void Arvore()
    {
        // Linhas da Árvore
        int height = Height(Root);
        // Colunas da Árvore
        int width = (int)Math.Pow(2, height + 2);

        // Lista de Linhas da Árvore
        List<string> lines = new();
        for (int i = 0; i <= height; i++)
            lines.Add(new string(' ', width));

        PrintArvore(Root, lines, 0, width / 2, width / 4);

        foreach (string line in lines)
            Console.WriteLine(line.TrimEnd());
    }

    private void PrintArvore(Node<T>? node, List<string> lines, int level, int position, int shift)
    {
        if (node == null || level >= lines.Count)
            return;

        string element = node.GetElement()!.ToString()!;
        int init = position - element.Length / 2;

        lines[level] = lines[level].Remove(init, element.Length).Insert(init, element);

        if (node.GetLeftChild() != null)
            PrintArvore(node.GetLeftChild(), lines, level + 1, position - shift, shift / 2);

        if (node.GetRightChild() != null)
            PrintArvore(node.GetRightChild(), lines, level + 1, position + shift, shift / 2);
    }
}