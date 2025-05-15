using System;

class PilhaListaSimplismenteLigada<T> : Pilha<T>
{
    private No<T> Head;         // Nó Sentinela Head
    private No<T> Tail;         // Nó Sentinela Tail
    private int QtdElement;     // Quantidade de elementos da Lista

    public PilhaListaSimplismenteLigada()
    {
        Head = new No<T>();     // Inicializando o Nó Sentinela Head
        Tail = new No<T>();     // Inicializando o Nó Sentinela Tail
        Head.Next = Tail;       // Referência do próximo do Nó Head é o Nó Tail
        QtdElement = 0;         // Pilha está vazia
    }

    public void Push(T objeto)
    {
        No<T> novoNo = new No<T>();     // Criando o Novo Nó
        novoNo.Objeto = objeto;         // Adicionando um objeto ao Novo Nó
        No<T> atualNo = Head;           // Nó auxiliar para o inicio da Pilha
        while(atualNo.Next != Tail)
        {
            atualNo = atualNo.Next;     // Encontrar o último Nó adicionado na Pilha
        }
        atualNo.Next = novoNo;          // Mudar a referência do próximo do antigo último Nó para o Novo Nó
        novoNo.Next = Tail;             // Novo Nó passa a ser o último Nó da Pilha sendo a sua referência posterior o Nó Tail
        QtdElement++;                   // Quantidade de Nós/elementos +1
    }

    public T Pop()
    {
        if(IsEmpty()) throw new PilhaVaziaExcecao();    // Verificar se a Pilha está vazia
        No<T> atualNo = Head;                           // Nó auxiliar para o inicio da Pilha
        while(atualNo.Next.Next != Tail)
        {
            atualNo = atualNo.Next;                     // Encontrar o penúltimo Nó adicionado na Pilha
        }
        No<T> noRemovido = atualNo.Next;                // Nó a ser removido - último Nó 
        atualNo.Next = Tail;                            // Penúltimo Nó passa a ser o último Nó da Pilha sendo a sua referência posterior o Nó Tail
        noRemovido.Next = null;                         // Remover a referência posterior do Nó a ser removido - antigo último Nó
        QtdElement--;                                   // Quantidade de Nós/elementos -1
        return noRemovido.Objeto;                       // Retorna o objeto do antigo último Nó
    }

    public T Top()
    {
        if(IsEmpty()) throw new PilhaVaziaExcecao();    // Verificar se a Pilha está vazia
        No<T> atualNo = Head;                           // Nó auxiliar para o inicio da Pilha
        while(atualNo.Next != Tail)
        {
            atualNo = atualNo.Next;                     // Encontrar o último Nó adicionado na Pilha
        }
        return atualNo.Objeto;                          // Retorna o objeto do último Nó - Topo da Pilha
    }

    public int Size()
    {
        return QtdElement;                  // Retorna a quantidade de elementos na Pilha
    }

    public bool IsEmpty()
    {
        return Head.Next == Tail;           // Verificar se a Pilha está vazia
    }

    public void ExibirPilha()
    {
        No<T> atualNo = Head;                                   // Nó auxiliar para o inicio da Pilha
        while(atualNo.Next != Tail)
        {
            atualNo = atualNo.Next;                             // Condição de parada - último Nó

            if(atualNo.Next == Tail)                            // Imprimir Topo da Pilha
            {
                Console.ForegroundColor = ConsoleColor.Green;            
                Console.Write($"| {atualNo.Objeto} |");
                Console.ResetColor();
            } else Console.Write($"| {atualNo.Objeto} |");      // Imprimir outros valores da Pilha

        }
        
        Console.WriteLine("\n");                                // Pular Linha!
    }
}