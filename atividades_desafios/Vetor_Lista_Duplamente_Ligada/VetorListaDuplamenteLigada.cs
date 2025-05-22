class VetorListaDuplamenteLigada<T> : Vetor<T>
{
    private No<T> Head;                     // Nó Sentinela Head
    private No<T> Tail;                     // Nó Sentinela Tail
    private int QtdElement;                 // Quantidade de elementos da Lista

    public VetorListaDuplamenteLigada()
    {
        Head = new No<T>();                 // Inicializando o Nó Sentinela Head
        Tail = new No<T>();                 // Inicializando o Nó Sentinela Tail
        Head.Next = Tail;                   // Referência do próximo do Nó Head é o Nó Tail
        Tail.Prev = Head;                   // Referência do anterior do Nó Tail é o Nó Head
        QtdElement = 0;                     // VetorArray inicializa vazio
    }

    public void InsertAtRank(int posicao, T objeto)
    {
        if (posicao > Size()) throw new PosicaoInvalidaExcecao();   // Verificar se a posição informada está inválida
        No<T> novoNo = new No<T>(objeto);                           // Criar um novo Nó com o objeto informado
        No<T> noReferencia = Search(posicao);                       // Obter o Nó de referência para a inserção na posição informada
        No<T> noRefPrev = noReferencia.Prev;                        // Obter a referência do anterior do Nó de referência
        novoNo.Next = noReferencia;                                 // Referência posterior do novo Nó é o Nó de referência
        novoNo.Prev = noRefPrev;                                    // Referência anterior do novo Nó é a referência anterior do Nó de referência
        noRefPrev.Next = novoNo;                                    // Referência posterior da referência anterior do Nó de referência é o novo Nó
        noReferencia.Prev = novoNo;                                 // Referência anterior do Nó de referência é o novo Nó
        QtdElement++;                                               // Quantidade de elementos +1
    }

    public T RemoveAtRank(int posicao)
    {
        if (IsEmpty()) throw new VetorVazioExcecao();               // Verificar se o Vetor está vazio
        if (posicao >= Size()) throw new PosicaoInvalidaExcecao();  // Verificar se a posição informada está inválida
        No<T> noRemovido = Search(posicao);                         // Encontrar o Nó que será removido
        No<T> noRefNext = noRemovido.Next;                          // Referência posterior do Nó que será removido
        No<T> noRefPrev = noRemovido.Prev;                          // Referência anterior do Nó que será removido
        T objeto = noRemovido.Objeto;                               // Objeto do Nó que será removido
        noRefNext.Prev = noRefPrev;                                 // Referência anterior da referência posterior do Nó de que será removido é a referência anterior do Nó que será removido
        noRefPrev.Next = noRefNext;                                 // Referência posterior da referência anterior do Nó de que será removido é a referência posterior do Nó que será removido
        noRemovido.Next = noRemovido.Prev = null;                   // Anulando as referências posterior e anterior do Nó que será removido
        QtdElement--;                                               // Quantidade de elementos -1
        return objeto;                                              // Retorna objeto do Nó que será removido
    }

    public T ReplaceAtRank(int posicao, T objeto)
    {
        if (IsEmpty()) throw new VetorVazioExcecao();               // Verificar se o Vetor está vazio
        if (posicao >= Size()) throw new PosicaoInvalidaExcecao();  // Verificar se a posição informada está inválida
        No<T> novoNo = new No<T>(objeto);                           // Criar um novo Nó com o objeto informado
        No<T> noSubstituido = Search(posicao);                      // Obter o Nó que será substituido pelo novo Nó
        No<T> noRefNext = noSubstituido.Next;                       // Referência posterior do Nó que será substituido
        No<T> noRefPrev = noSubstituido.Prev;                       // Referência anterior do Nó que será substituido
        T objetoRef = noSubstituido.Objeto;                         // Objeto do Nó que será substituido
        novoNo.Next = noRefNext;                                    // Referência posterior do novo Nó é a referência posterior do Nó que será substituido
        novoNo.Prev = noRefPrev;                                    // Referência anterior do novo Nó é a referência anterior do Nó que será substituido
        noRefNext.Prev = novoNo;                                    // Referência anterior da referência posterior do Nó que será substituido e o novo Nó
        noRefPrev.Next = novoNo;                                    // Referência posterior da referência anterior do Nó que será substituido e o novo Nó
        noSubstituido.Next = noSubstituido.Prev = null;             // Anulando as referências posterior e anterior do Nó que será substituido
        return objetoRef;                                           // Retorna objeto do Nó que será substituido
    }

    public T ElemAtRank(int posicao)
    {
        if (IsEmpty()) throw new VetorVazioExcecao();               // Verificar se o Vetor está vazio
        if (posicao >= Size()) throw new PosicaoInvalidaExcecao();  // Verificar se a posição informada está inválida
        No<T> noReferencia = Search(posicao);                       // Nó de referência da posição informada
        return noReferencia.Objeto;                                 // Retorna objeto do Nó de referência
    }

    public int Size()
    {
        return QtdElement;          // Retorna a quantidade de elementos do Vetor
    }

    public bool IsEmpty()
    {
        return Head.Next == Tail;   // Verificar se a Lista está vazia
    }

    public No<T> Search(int posicao)
    {
        if (posicao == QtdElement) return Tail;     // Verificar se a posição informada é a posterior do último elemento
        No<T> atualNo = Head.Next;                  // Nó auxiliar do primeiro elemento do Vetor - posterior a Head
        int aux = 0;                                // Variável auxiliar que indica o índice do Vetor
        while (aux != posicao)
        {
            atualNo = atualNo.Next;                 // Encontra o Nó da posição informada
            aux++;
        }
        return atualNo;                             // Retorna o Nó de referência da posição informada
    }

    public void ExibirVetor()
    {
        No<T> atualNo = Head;                                                       // Nó auxiliar para o inicio do Vetor
        Console.Write("Objetos -> ");
        while (atualNo.Next != Tail)
        {
            atualNo = atualNo.Next;                                                 // Condição de parada - último Nó
            Console.Write($"| {atualNo.Objeto} |");                                 // Imprimir valores da Vetor
        }

        Console.WriteLine("\n");                                                    // Pular Linha!

        Console.Write("Posição -> ");
        for (int i = 0; i <= Size(); i++) Console.Write($"| {i} |");                // Imprimir posição dos valores do Vetor

        Console.WriteLine("\n");                                                    // Pular Linha!
    }
}