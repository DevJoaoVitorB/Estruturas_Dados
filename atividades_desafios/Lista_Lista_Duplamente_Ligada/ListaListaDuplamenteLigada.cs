using System;

class ListaDuplamenteLigada<T> : Lista<T>
{
    private No<T> Head;                             // Nó Sentinela Head
    private No<T> Tail;                             // Nó Sentinela Tail
    private int QtdElement;                         // Quantidade de elementos da Lista

    public ListaDuplamenteLigada()
    {
        Head = new No<T>();                         // Inicializando o Nó Sentinela Head
        Tail = new No<T>();                         // Inicializando o Nó Sentinela Tail
        Head.Next = Tail;                           // Referência do próximo do Nó Head é o Nó Tail
        Tail.Prev = Head;                           // Referência do anterior do Nó Tail é o Nó Head
        QtdElement = 0;                             // Lista está vazia
    }

    public void InsertFirst(T objeto)
    {
        No<T> novoNo = new No<T>();                 // Criando um novo Nó
        novoNo.Objeto = objeto;                     // Adicionando o objeto ao Nó
        No<T> primeiroNo = Head.Next;               // primeiro Nó - posterior a Head
        novoNo.Next = primeiroNo;                   // Referência posterior do novo Nó é o próximo de Head - primeiro Nó
        novoNo.Prev = Head;                         // Referência anterior do novo Nó é Head     
        Head.Next = novoNo;                         // Referência posterior de Head passa a ser o novo Nó
        primeiroNo.Prev = novoNo;                   // Referência anterior do antigo primeiro Nó passa a ser o novo Nó    
        QtdElement++;                               // Quantidade de elementos +1
    }

    public void InsertLast(T objeto)
    {
        No<T> novoNo = new No<T>();                 // Criando um novo Nó
        novoNo.Objeto = objeto;                     // Adicionando o objeto ao Nó
        No<T> ultimoNo = Tail.Prev;                 // último Nó - anterior a Tail
        novoNo.Next = Tail;                         // Referência posterior do novo Nó é Tail
        novoNo.Prev = ultimoNo;                     // Referência anterior do novo Nó é o anterior de Tail - último Nó
        ultimoNo.Next = novoNo;                     // Referência posterior do antigo último Nó passa a ser o novo Nó    
        Tail.Prev = novoNo;                         // Referência anterior de Tail passa a ser o novo Nó
        QtdElement++;                               // Quantidade de elementos +1
    }

    public void InsertAfter(T objetoRef, T objeto)
    {
        No<T> novoNo = new No<T>();                 // Criando um novo Nó
        novoNo.Objeto = objeto;                     // Adicionando o objeto ao Nó
        No<T> noReferencia = Search(objetoRef);     // Nó de referência para adicionar um outro Nó após
        No<T> noRefNext = noReferencia.Next;        // Referência posterior do Nó de referência
        novoNo.Next = noRefNext;                    // Referência posterior do novo Nó é a referência posterior do Nó de referência
        novoNo.Prev = noReferencia;                 // Referência anterior do novo Nó é o Nó de referência
        noReferencia.Next = novoNo;                 // Referência posterior do Nó de referência é o novo Nó
        noRefNext.Prev = novoNo;                    // Referência anterior da antiga referência posterior do Nó de referência é o novo Nó
        QtdElement++;                               // Quantidade de elementos +1
    }

    public void InsertBefore(T objetoRef, T objeto)
    {
        No<T> novoNo = new No<T>();                 // Criando um novo Nó
        novoNo.Objeto = objeto;                     // Adicionando o objeto ao Nó
        No<T> noReferencia = Search(objetoRef);     // Nó de referência para adicionar um outro Nó antes
        No<T> noRefPrev = noReferencia.Prev;       // Referência anterior do Nó de referência
        novoNo.Next = noReferencia;                 // Referência posterior do novo Nó é o Nó de referência
        novoNo.Prev = noRefPrev;                    // Referência anterior do novo Nó é a referência anterior do Nó de referência
        noRefPrev.Next = novoNo;                    // Referência posterior da antiga referência anterior do Nó de referência é o novo Nó
        noReferencia.Prev = novoNo;                 // Referência anterior do Nó de referência é o novo Nó
        QtdElement++;                               // Quantidade de elementos +1
    }

    public T ReplaceElement(T objetoRef, T objeto)
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();   // Verificar se a Lista está vazia
        No<T> novoNo = new No<T>();                     // Criando um novo Nó
        novoNo.Objeto = objeto;                         // Adicionando o objeto ao Nó
        No<T> noReferencia = Search(objetoRef);         // Nó de referência para ser substituido pelo novo Nó
        No<T> noRefNext = noReferencia.Next;            // Referência posterior do Nó de referência
        No<T> noRefPrev = noReferencia.Prev;            // Referência anterior do Nó de referência
        novoNo.Next = noRefNext;                        // Referência posterior do novoNo é a referência posterior do Nó de referência
        novoNo.Prev = noRefPrev;                        // Referência anterior do novoNo é a referência anterior do Nó de referência
        noRefNext.Prev = novoNo;                        // Referência anterior da referência posterior do Nó de referência é o novo Nó
        noRefPrev.Next = novoNo;                        // Referência posterior da referência anterior do Nó de referência é o novo Nó
        noReferencia.Next = noReferencia.Prev = null;   // Anular a referência posterior e anterior do Nó que será substituido 
        return noReferencia.Objeto;                     // Retorna o objeto do Nó de referência
    }

    public void SwapElement(T objetoRef1, T objetoRef2)
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();   // Verificar se a Lista está vazia
        No<T> noRef1 = Search(objetoRef1);              // Nó de referência 1 para ser trocado pelo Nó de referência 2
        No<T> noRef2 = Search(objetoRef2);              // Nó de referência 2 para ser trocado pelo Nó de referência 1

        // CASO 1 - Mesmo Nó
        // Não realizar a troca!

        if (EqualityComparer<T>.Default.Equals(objetoRef1, objetoRef2)) return; // Não realizar a troca se forem o mesmo Nó

        // CASO 2 - Nós Adjacentes
        // 1º Nó possui referência posterior no 2º Nó   | 1º | -> | 2º |
        // 2º Nó possui referência anterior no 1º Nó    | 1º | <- | 2º |
        // OU
        // 1º Nó possui referência anterior no 2º Nó    | 2º | <- | 1º |
        // 2º Nó possui referência posterior no 1º Nó   | 2º | -> | 1º |
        // ERRO! Nesse caso, ao trocarem referências os Nós podem estarem referênciando eles mesmo:
        // EX.: A referência posterior do 2º Nó passa a ser a referência posterior é o Nó 1º: | 1º | -> | 2º | -> | 2º | -> | 2º |

        if (noRef1.Next == noRef2)                      // Verificar se Nó de referência 1 é adjacente do Nó de referência 2
        {
            AdjacentElements(noRef1, noRef2);           // Realizar a troca dos Nó adjacentes
            return;                                     // Fim da operação de troca
        }
        else if (noRef2.Next == noRef1)                 // Verificar se Nó de referência 2 é adjacente do Nó de referência 1
        {
            AdjacentElements(noRef2, noRef1);           // Realizar a troca dos Nó adjacentes
            return;                                     // Fim da operação de troca
        }

        // CASO 3 - Nós não Adjacentes
        // Realização de troca padrão!

        No<T> next1 = noRef1.Next;                      // Referência posterior do Nó de referência 1
        No<T> prev1 = noRef1.Prev;                      // Referência anterior do Nó de referência 1
        No<T> next2 = noRef2.Next;                      // Referência posterior do Nó de referência 2
        No<T> prev2 = noRef2.Prev;                      // Referência anterior do Nó de referência 2
        next1.Prev = noRef2;                            // A referência anterior da referência posterior do Nó de referência 1 é Nó de referência 2
        prev1.Next = noRef2;                            // A referência posterior da referência anterior do Nó de referência 1 é Nó de referência 2
        next2.Prev = noRef1;                            // A referência anterior da referência posterior do Nó de referência 2 é Nó de referência 1
        prev2.Next = noRef1;                            // A referência posterior da referência anterior do Nó de referência 2 é Nó de referência 1
        (noRef1.Next, noRef2.Next) = (next2, next1);    // Trocar as referências dos posteriores dos Nós de referência entre sí
        (noRef1.Prev, noRef2.Prev) = (prev2, prev1);    // Trocar as referências dos anteriores dos Nós de referência entre sí
    }

    private void AdjacentElements(No<T> noRef1, No<T> noRef2)
    {
        No<T> next = noRef2.Next;                   // Referência posterior do Nó de referência 2
        No<T> prev = noRef1.Prev;                   // Referência anterior do Nó de referência 1
        prev.Next = noRef2;                         // Referência posterior da referência anterior do Nó de referência 1 passa a ser Nó de referência 2 
        noRef2.Next = noRef1;                       // Referência posterior do Nó de referência 2 é Nó de referência 1
        noRef2.Prev = prev;                         // Referência anterior do Nó de referência 2 é referência anterior do Nó de referência 1                        
        noRef1.Next = next;                         // Referência posterior do Nó de referência 1 é referência posterior do Nó de referência 2                        
        noRef1.Prev = noRef2;                       // Referência anterior do Nó de referência 1 é Nó de referência 2
        next.Prev = noRef1;                         // Referência anterior da referência posterior do Nó de referência 2 passa a ser Nó de referência 1
    }

    public T Remove(T objeto)
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> noRemovido = Search(objeto);              // Encontrar o Nó que será removido
        No<T> noRemoveNext = noRemovido.Next;           // Referência posterior do Nó que será removido
        No<T> noRemovePrev = noRemovido.Prev;           // Referência anterior do Nó que será removido
        noRemoveNext.Prev = noRemovePrev;               // Referência anterior da referência posterior do Nó que será removido é a referência anterior do Nó que será removido
        noRemovePrev.Next = noRemoveNext;               // Referência posterior da referência anterior do Nó que será removido é a referência posterior do Nó que será removido
        noRemovido.Next = noRemovido.Prev = null;       // Anular a referência posterior e anterior do Nó que será removido
        QtdElement--;                                   // Quantidade de elementos -1
        return noRemovido.Objeto;                       // Retorna o elemento do Nó que será removido
    }

    public No<T> First()
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        return Head.Next;                               // Retorna o primeiro Nó da Lista
    }

    public No<T> Last()
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        return Tail.Prev;                               // Retorna o último Nó da Lista
    }

    public bool InFirst(T objeto)
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> noReferencia = Search(objeto);            // Nó de referência que quer saber se está no inicio da Lista
        bool inFirst = false;                           // Váriavel auxiliar para saber se o Nó de referência está no inicio da Lista
        if (Head.Next == noReferencia) inFirst = true;   // Verificação para saber se o Nó de referência está no inicio da Lista
        return inFirst;                                 // Retorna a reposta - TRUE ou FALSE - se o Nó de referência está no inicio da Lista
    }

    public bool InLast(T objeto)
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> noReferencia = Search(objeto);            // Nó de referência que quer saber se está no final da Lista
        bool inLast = false;                            // Váriavel auxiliar para saber se o Nó de referência está no final da Lista
        if (Tail.Prev == noReferencia) inLast = true;    // Verificação para saber se o Nó de referência está no final da Lista
        return inLast;                                  // Retorna a reposta - TRUE ou FALSE - se o Nó de referência está no final da Lista
    }

    public No<T> After(T objeto)
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> noReferencia = Search(objeto);            // Nó de referência para encontrar o próximo Nó a ele
        return noReferencia.Next;                       // Retorna o próximo Nó ao Nó de referência
    }

    public No<T> Before(T objeto)
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> noReferencia = Search(objeto);            // Nó de referência para encontrar o Nó anterior a ele
        return noReferencia.Prev;                       // Retorna o Nó anterior ao Nó de referência
    }

    public int Size()
    {
        return QtdElement;                              // Retorna a quantidade de Nós da Lista
    }

    public bool IsEmpty()
    {
        return Head.Next == Tail;                       // Verificar se a Lista está vazia
    }

    public No<T> Search(T objeto)
    {
        No<T> atualNo = Head;                                                                                       // Conseguir uma referência auxiliar do começo da Lista
        while (!EqualityComparer<T>.Default.Equals(atualNo.Objeto, objeto))
        {
            atualNo = atualNo.Next;                                                                                 // Encontra o Nó que possui o elemento
        }
        if (!EqualityComparer<T>.Default.Equals(atualNo.Objeto, objeto)) throw new ObjetoNaoEncontradoExcecao();    // Verificar se existi o Nó com o elemento na Lista
        return atualNo;
    }

    public void ExibirLista()
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();           // Verificar se a Lista está vazia
        No<T> atualNo = Head;                                   // Nó auxiliar para o inicio da Lista
        while (atualNo.Next != Tail)
        {
            atualNo = atualNo.Next;                             // Condição de parada - último Nó
            Console.Write($"| {atualNo.Objeto} |");             // Imprimir outros valores da Lista
        }

        Console.WriteLine("\n");                                // Pular Linha!
    }
}