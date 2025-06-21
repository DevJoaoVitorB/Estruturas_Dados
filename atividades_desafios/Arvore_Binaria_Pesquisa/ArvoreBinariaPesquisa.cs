public class ArvoreBinariaPesquisa<T> : IArvore<T> where T : IComparable<T>
{
    private Node<T>? Root;

    public ArvoreBinariaPesquisa() => Root = null;

    // Método para Pegar a Raiz da Árvore
    public Node<T>? GetRoot() => Root;

    // Métodos Tamanho e Está Vazio
    public int Size() => NodeCount(Root);
    private int NodeCount(Node<T>? node)
    {
        if (node == null) return 0;
        return 1 + NodeCount(node.GetLeftChild()) + NodeCount(node.GetRightChild());
    }
    public bool IsEmpty() => Root == null;

    // Método de Verificação de Raiz
    public bool IsRoot(Node<T>? node) => node == Root;

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
    // Lógica: O Nó Pai deve possuir o Nó Filho Esquerdo Menor e o Nó Filho Direito Maior
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
        // A chave não foi encontrada na árvore.
        if (node == null)
            return null;

        // Encontra o Nó com a chave de remoção
        if (key.CompareTo(node.GetElement()) < 0)
            // Nó procurado é menor que o Nó atual -> percorre a esquerda 
            node.SetLeftChild(RemoveOperation(node.GetLeftChild(), key));
        else if (key.CompareTo(node.GetElement()) > 0)
            // Nó procurado é maior que o Nó atual -> percorre a direita
            node.SetRightChild(RemoveOperation(node.GetRightChild(), key));
        // Nó com chave de remoção encontrado
        else
        {
            // Único Filho
            if (node.GetLeftChild() == null)
                // Sem filho esquerdo -> filho direito ocupa o lugar do pai
                return node.GetRightChild();
            if (node.GetRightChild() == null)
                // Sem filho direito -> filho esquerdo ocupa o lugar do pai
                return node.GetLeftChild();

            // Dois Filhos
            // PASSO 1 - Encontra o sucessor (Direita - Esquerda - Esquerda - ...)
            Node<T> successor = Successor(node.GetRightChild());
            // PASSO 2 - Nó sucessor ocupa o lugar do Nó pai
            node.SetElement(successor.GetElement());
            // PASSO 3 - Remove o Nó duplicado do sucessor
            node.SetRightChild(RemoveOperation(node.GetRightChild(), successor.GetElement()));
        }

        return node;
    }

    // Método para encontrar o Sucessor do Nó Removido quando esse possui 2 Filhos
    private Node<T> Successor(Node<T>? node)
    {
        // Encontrar o menor Nó da subarvore direita
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

        Console.Write(node.GetElement() + " - ");
        PreOrderTraversal(node.GetLeftChild());
        PreOrderTraversal(node.GetRightChild());
    }

    public void InOrder() => InOrderTraversal(Root);
    private void InOrderTraversal(Node<T>? node)
    {
        if (node == null)
            return;

        InOrderTraversal(node.GetLeftChild());
        Console.Write(node.GetElement() + " - ");
        InOrderTraversal(node.GetRightChild());
    }

    public void PostOrder() => PostOrderTraversal(Root);
    private void PostOrderTraversal(Node<T>? node)
    {
        if (node == null)
            return;

        PostOrderTraversal(node.GetLeftChild());
        PostOrderTraversal(node.GetRightChild());
        Console.Write(node.GetElement() + " - "); 
    }


    // Imprimir a Árvore em Formato Estrutural
    public void Arvore()
    {
        // Linhas da Árvore
        int height = Height(Root);
        // Colunas da Árvore
        int width = (int)Math.Pow(2, height + 2);

        // Lista de Linhas da Árvore (Folha de Desenho)
        List<string> lines = new();
        // Definir a quantidade de Colunas de cada Linha
        for (int i = 0; i <= height; i++)
            // Cada Linha deve ter o mesmo número de colunas
            lines.Add(new string(' ', width));

        // "Escrever" cada Nó em sua Linha/Coluna da "Folha de Desenho"
        // INFORMAÇÕES INICIAIS:
        // Nó de referência - Raíz (ínicio)
        // "Folha de Desenho em Branco"
        // Linha - 0 (ínicio)
        // Posição - Centro da Linha 0
        // Deslocamento - Deslocamento Horizontal dos Filhos (Metade da Linha 0)
        PrintArvore(Root, lines, 0, width / 2, width / 4);

        // Mostrar todas as Linhas/Colunas da "Folha de Desenho" - retirando todos os espaços desnecessários do final de cada Linha
        foreach (string line in lines)
            Console.WriteLine(line.TrimEnd());
    }

    private void PrintArvore(Node<T>? node, List<string> lines, int level, int position, int shift)
    {
        // Condição Base - Nó atual é null -> sair da função
        if (node == null || level >= lines.Count)
            return;

        // Tranforma o elemento do Nó de referência em string
        string element = node.GetElement()!.ToString()!;
        // Centralização do elemento - posição de inserção
        int init = position - element.Length / 2;

        // "Escrever"
        // PASSO 1 - Remover o espaço(" ") necessário para colocar o elemento
        // PASSO 2 - Inserir o elemento no espaço liberado
        lines[level] = lines[level].Remove(init, element.Length).Insert(init, element);

        // Recursividade - Fazer a mesma coisa para os filhos esquerdo e direito seguindo para as próximas linhas e ajustando a posição relativa ao Nó pai
        if (node.GetLeftChild() != null)
            PrintArvore(node.GetLeftChild(), lines, level + 1, position - shift, shift / 2);

        if (node.GetRightChild() != null)
            PrintArvore(node.GetRightChild(), lines, level + 1, position + shift, shift / 2);
    }
}