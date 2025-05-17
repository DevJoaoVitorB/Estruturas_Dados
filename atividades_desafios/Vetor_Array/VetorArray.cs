class VetorArray<T> : Vetor<T>
{
    private int Capacidade;   // Capacidade do VetorArray
    private int QtdElement;   // Quantidade de elementos do Vetor
    private T[] ArrayVetor;   // Array utilizado como Vetor

    public VetorArray(int capacidade)
    {
        Capacidade = capacidade;            // Definir a capacidade do VetorArray
        ArrayVetor = new T[Capacidade];     // Inicializando o VetorArray
        QtdElement = 0;                     // VetorArray inicializa vazio
    }

    public void InsertAtRank(int posicao, T objeto)
    {
        if (posicao > Size() || posicao >= Capacidade) throw new PosicaoInvalidaExcecao();  // Verificar se a posição informada está inválida

        if (Size() == Capacidade - 1)
        {
            Capacidade *= 2;

            T[] tempArray = new T[Capacidade];                                              // Criação de um Array temporário
            for (int i = 0; i < ArrayVetor.Length; i++)
            {
                tempArray[i] = ArrayVetor[i];                                               // Colocar os elementos do antigo Array (ArrayVetor) para o novo Array (tempArray)
            }
            ArrayVetor = tempArray;                                                         // tempArray passa a ser o novo Array
        }

        if (posicao < Size())
        {
            for (int j = Size(); j > posicao; j--)
            {
                ArrayVetor[j] = ArrayVetor[j - 1];                                          // Deslocar para direita os Elementos da posição X até o último anteriormente adicionado
            }
        }
        ArrayVetor[posicao] = objeto;                                                       // Adicionar elemento a posição X
        QtdElement++;                                                                       // Quantidade de elementos +1
    }

    public T RemoveAtRank(int posicao)
    {
        if (IsEmpty()) throw new VetorVazioExcecao();                                           // Verificar se o VetorArray está Vazio
        if (posicao >= Size() || posicao >= Capacidade) throw new PosicaoInvalidaExcecao();     // Verificar se a posição informada está inválida

        T objetoRemovido = ArrayVetor[posicao];                                                 // Guardar o objeto a ser removido

        for (int i = posicao; i < Size(); i++)
        {
            ArrayVetor[i] = ArrayVetor[i + 1];                                                  // Deslocar para esquerda os Elementos da posição X+1 até o último anteriormente adicionado
        }
        QtdElement--;                                                                           // Quantidade de elementos -1
        return objetoRemovido;                                                                  // Retornando o valor que será removido
    }

    public T ReplaceAtRank(int posicao, T objeto)
    {
        if (IsEmpty()) throw new VetorVazioExcecao();                                           // Verificar se o VetorArray está Vazio
        if (posicao >= Size() || posicao >= Capacidade) throw new PosicaoInvalidaExcecao();     // Verificar se a posição informada está inválida

        T objetoSubstituido = ArrayVetor[posicao];                                              // Guarda o objeto que será substituido
        ArrayVetor[posicao] = objeto;                                                           // Substituir o objeto antigo pelo objeto novo
        return objetoSubstituido;                                                               // Retorna o objeto que será substituido
    }

    public T ElemAtRank(int posicao)
    {
        if (IsEmpty()) throw new VetorVazioExcecao();                                           // Verificar se o VetorArray está Vazio
        if (posicao >= Size() || posicao >= Capacidade) throw new PosicaoInvalidaExcecao();     // Verificar se a posição informada está inválida

        return ArrayVetor[posicao];                                                             // Retorna o objeto da posição X
    }

    public int Size()
    {
        return QtdElement;          // Retorna a quantidade de elementos do Vetor
    }

    public bool IsEmpty()
    {
        return QtdElement == 0;     // Verificar se a quantidade de elementos do VetorArray é igual a 0, ou seja, está Vazio
    }

    public void ExibirVetor()
    {
        Console.Write("Vetor -> ");                     // Elementos da Lista
        for (int i = 0; i < Capacidade - 1; i++)
        {
            Console.Write($"| {ArrayVetor[i]} |");      // Imprimir os Elementos do Vetor
        }

        Console.WriteLine();                            // Pular Linha!

        Console.Write("Posição -> ");                   // Posição dos Elementos do Vetor
        for (int i = 0; i < Capacidade - 1; i++)
        {
            Console.Write($"| {i} |");                  // Imprimir a Posição dos Elementos do Vetor
        }

        Console.WriteLine();                            // Pular Linha!
    }
}