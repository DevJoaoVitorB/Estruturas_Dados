using System;
using System.Collections;
using System.Net.Security;

class ListaArray<T> : Lista<T>
{
    private int Capacidade;                         // Capacidade da ListaArray
    private int QtdElement;                         // Quantidade de Elementos da Lista
    private T[] ArrayLista;                         // Array que Contém os Elementos da Lista

    public ListaArray(int capacidade)
    {
        Capacidade = capacidade;                    // Definir a capacidade inicial da ListaArray
        QtdElement = 0;                             // Lista está vazia
        ArrayLista = new T[Capacidade];             // Inicializando ListaArray
    }

    private void Redimensionar()
    {
        Capacidade *= 2;                            // Estratégia Duplicativa
        T[] tempArray = new T[Capacidade];          // Criação de um Array temporário
        for(int i = 0; i < Size(); i++)
        {
            tempArray[i] = ArrayLista[i];           // Colocar os elementos do antigo Array (ArrayLista) para o novo Array (tempArray)
        }
        ArrayLista = tempArray;                     // tempArray passa a ser o novo Array
    }

    public void InsertFirst(T objeto)
    {
        if (Size() == Capacidade) Redimensionar();                              // Verificar se a ListaArray está cheia
        for (int i = Size(); i > 0; i--) ArrayLista[i] = ArrayLista[i - 1];     // Deslocar os elementos da ListaArray para a direita a partir do inicio
        ArrayLista[0] = objeto;                                                 // Adicionar o elemento no inicio da Lista
        QtdElement++;                                                           // Quantidade de elementos +1
    }

    public void InsertLast(T objeto)
    {
        if (Size() == Capacidade) Redimensionar();  // Verificar se a ListaArray está cheia
        ArrayLista[Size()] = objeto;                // Adicionar o elemento no final da Lista
        QtdElement++;                               // Quantidade de elementos +1
    }

    public void InsertAfter(int posicao, T objeto)
    {
        if (Size() == Capacidade) Redimensionar();                                      // Verificar se a ListaArray está cheia
        if (posicao < 0 || posicao >= Size()) throw new ObjetoNaoEncontradoExcecao();   // Verificar se a posição está no range da Lista
        for (int i = Size(); i > posicao + 1; i--) ArrayLista[i] = ArrayLista[i - 1];   // Deslocar os elementos da ListaArray para a direita a partir do próximo da posição do elemento de referência
        ArrayLista[posicao + 1] = objeto;                                               // Adicionar o elemento depois do elemento da posição informada
        QtdElement++;                                                                   // Quantidade de elementos +1
    }

    public void InsertBefore(int posicao, T objeto)
    {
        if (Size() == Capacidade) Redimensionar();                                      // Verificar se a ListaArray está cheia
        if (posicao < 0 || posicao >= Size()) throw new ObjetoNaoEncontradoExcecao();   // Verificar se a posição está no range da Lista
        for (int i = Size(); i > posicao; i--) ArrayLista[i] = ArrayLista[i - 1];       // Deslocar os elementos da ListaArray para a direita a partir da posição do elemento de referência
        ArrayLista[posicao] = objeto;                                                   // Adicionar o elemento antes do elemento da posição informada
        QtdElement++;                                                                   // Quantidade de elementos +1
    }

    public T ReplaceElement(int posicao, T objeto)
    {
        if (posicao < 0 || posicao >= Size()) throw new ObjetoNaoEncontradoExcecao();   // Verificar se a posição está no range da Lista
        T elementSubstituido = ArrayLista[posicao];                                     // Elemento que será substituido 
        ArrayLista[posicao] = objeto;                                                   // Substituir o elemento da Lista da posição informada por outro elemento
        return elementSubstituido;                                                      // Retorna elemento que será substituido
    }

    public void SwapElement(int posicao1, int posicao2)
    {
        if (posicao1 < 0 || posicao1 >= Size() || posicao2 < 0 || posicao2 >= Size()) throw new ObjetoNaoEncontradoExcecao();   // Verificar se a posição está no range da Lista
        T objeto1 = ArrayLista[posicao1];                                                                                       // Primeiro elemento da troca
        ArrayLista[posicao1] = ArrayLista[posicao2];                                                                            // Posição do elemento 1 passa a ser ocupada pelo elemento 2
        ArrayLista[posicao2] = objeto1;                                                                                         // Posição do elemento 2 passa a ser ocupada pelo elemento 1
    }

    public T Remove(int posicao)
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();                                   // Verificar se a Lista está vazia
        if (posicao < 0 || posicao >= Size()) throw new ObjetoNaoEncontradoExcecao();   // Verificar se a posição está no range da Lista
        T elementRemovido = ArrayLista[posicao];                                        // Elemento que será removido
        for (int i = posicao; i < Size() - 1; i++) ArrayLista[i] = ArrayLista[i + 1];   // Deslocar os elementos da ListaArray para a esquerda a partir da posição do elemento que será removido                   
        QtdElement--;                                                                   // Quantidade de elementos -1
        return elementRemovido;                                                         // Retorna o elemento que será removido
    }

    public T First()
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();   // Verificar se a Lista está vazia
        return ArrayLista[0];                           // Retorna o primeiro elemento da Lista
    }

    public T Last()
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();   // Verificar se a Lista está vazia
        return ArrayLista[Size() - 1];                  // Retorna o último elemento da Lista
    }

    public bool InFirst(int posicao)
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();                                   // Verificar se a Lista está vazia
        if (posicao < 0 || posicao >= Size()) throw new ObjetoNaoEncontradoExcecao();   // Verificar se a posição está no range da Lista
        return EqualityComparer<T>.Default.Equals(ArrayLista[posicao], ArrayLista[0]);  // Verificar se o elemento da posição informada é o primeiro
    }

    public bool InLast(int posicao)
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();                                           // Verificar se a Lista está vazia
        if (posicao < 0 || posicao >= Size()) throw new ObjetoNaoEncontradoExcecao();           // Verificar se a posição está no range da Lista
        return EqualityComparer<T>.Default.Equals(ArrayLista[posicao], ArrayLista[Size() - 1]); // Verificar se o elemento da posição informada é o último
    }

    public T After(int posicao)
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();                                           // Verificar se a Lista está vazia
        if (posicao < 0 || posicao >= Size()) throw new ObjetoNaoEncontradoExcecao();           // Verificar se a posição está no range da Lista
        return ArrayLista[posicao + 1];                                                         // Retorna o elemento posterior ao elemento da posição informada
    }

    public T Before(int posicao)
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();                                           // Verificar se a Lista está vazia
        if (posicao <= 0 || posicao >= Size()) throw new ObjetoNaoEncontradoExcecao();          // Verificar se a posição está no range da Lista
        return ArrayLista[posicao - 1];                                                         // Retorna o elemento anterior ao elemento da posição informada
    }

    public int Size()
    {
        return QtdElement;                              // Retorna a quantidade de Nós da Lista
    }

    public bool IsEmpty()
    {
        return QtdElement == 0;                         // Verificar se a Lista está vazia
    }

    public void ExibirLista()
    {
        if (IsEmpty()) throw new ListaVaziaExcecao();   // Verificar se a Lista está vazia
        Console.Write("Lista -> ");                     // Elementos da Lista
        for (int i = 0; i < QtdElement; i++)
        {
            Console.Write($"| {ArrayLista[i]} |");      // Imprimir os Elementos da Lista
        }

        Console.WriteLine();                            // Pular Linha!

        Console.Write("Posição -> ");                   // Posição dos Elementos da Lista
        for (int i = 0; i < QtdElement; i++)
        {
            Console.Write($"| {i} |");                  // Imprimir a Posição dos Elementos da Lista
        }

        Console.WriteLine();                            // Pular Linha!
    }
}