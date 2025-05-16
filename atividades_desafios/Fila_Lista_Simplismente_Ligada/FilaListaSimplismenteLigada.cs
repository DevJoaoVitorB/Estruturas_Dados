using System;

class FilaListaSimplismenteLigada<T> : Fila<T>
{
    private No<T> Head;         // Nó Sentinela Head
    private No<T> Tail;         // Nó Sentinela Tail
    private int QtdElement;     // Quantidade de elementos da Lista

    public FilaListaSimplismenteLigada()
    {
        Head = new No<T>();     // Inicializando o Nó Sentinela Head
        Tail = new No<T>();     // Inicializando o Nó Sentinela Tail
        Head.Next = Tail;       // Referência do próximo do Nó Head é o Nó Tail
        QtdElement = 0;         // Pilha está vazia
    }

    public void Enqueue(T objeto)
    {
        No<T> novoNo = new No<T>();     // Criando o Novo Nó
        novoNo.Objeto = objeto;         // Adicionando um objeto ao Novo Nó
        No<T> atualNo = Head;           // Nó auxiliar para o inicio da Fila
        while(atualNo.Next != Tail)
        {
            atualNo = atualNo.Next;     // Encontrar o último Nó adicionado na Fila
        }
        atualNo.Next = novoNo;          // Mudar a referência do próximo do antigo último Nó para o Novo Nó
        novoNo.Next = Tail;             // Novo Nó passa a ser o último Nó da Fila sendo a sua referência posterior o Nó Tail
        QtdElement++;                   // Quantidade de Nós/elementos +1
    }

    public T Dequeue()
    {
        if(IsEmpty()) throw new FilaVaziaExcecao();     // Verificar se a Fila está vazia
        No<T> noRemovido = Head.Next;                   // Nó que será removido
        Head.Next = noRemovido.Next;                    // Head aponta para um novo Next - próximo do Nó que será removido
        noRemovido.Next = null;                         // Remover a referência posterior do Nó a ser removido - antigo primeiro Nó
        QtdElement--;                                   // Quantidade de Nós/elementos -1
        return noRemovido.Objeto;                       // Retorna o objeto do antigo último Nó
    }

    public T First()
    {
        if(IsEmpty()) throw new FilaVaziaExcecao();     // Verificar se a Fila está vazia
        return Head.Next.Objeto;                        // Retorna o objeto do primeiro Nó
    }

    public int Size()
    {
        return QtdElement;                  // Retorna a quantidade de elementos na Pilha
    }

    public bool IsEmpty()
    {
        return Head.Next == Tail;           // Verificar se a Fila está vazia
    }

    public void ExibirFila()
    {
        No<T> atualNo = Head;                                   // Nó auxiliar para o inicio da Fila
        while(atualNo.Next != Tail)
        {
            atualNo = atualNo.Next;                             // Condição de parada - último Nó
            
            if (Head.Next == atualNo)                           // Imprimir Inicio da Fila
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"| {atualNo.Objeto} |");
                Console.ResetColor();
            }
            else Console.Write($"| {atualNo.Objeto} |");        // Imprimir outros valores da Fila
        }
        
        Console.WriteLine("\n");                                // Pular Linha!
    }
}