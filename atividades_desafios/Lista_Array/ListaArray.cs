using System;

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

    public void InsertFirst(T objeto)
    {
        
        QtdElement++;                               // Quantidade de elementos +1
    }

    public void InsertLast(T objeto)
    {
        
        QtdElement++;                               // Quantidade de elementos +1
    }

    public void InsertAfter(T posicao, T objeto)
    {
        
        QtdElement++;                               // Quantidade de elementos +1
    }

    public void InsertBefore(T posicao, T objeto)
    {
        
        QtdElement++;                               // Quantidade de elementos +1
    }

    public T ReplaceElement(T posicao, T objeto)
    {
        
    }

    public void SwapElement(T posicao1, T posicao2)
    {
        
    }

    public T Remove(T posicao)
    {
        
        QtdElement--;                               // Quantidade de elementos -1
    }

    public T First()
    {
        
    }

    public T Last()
    {
        
    }

    public bool InFirst(T posicao)
    {
        
    }

    public bool InLast(T posicao)
    {
        
    }

    public T After(T posicao)
    {
        
    }

    public T Before(T posicao)
    {
        
    }

    public int Size()
    {
        return QtdElement;                              // Retorna a quantidade de Nós da Lista
    }

    public bool IsEmpty()
    {
        
    }

    public T Search(T posicao)
    {
        
    }

    public void ExibirLista()
    {
        Console.Write("Lista -> ");                     // Elementos da Lista
        for(int i = 0; i < QtdElement; i++)
        {
            Console.Write($"| {ArrayLista[i]} |");      // Imprimir os Elementos da Lista
        }

        Console.WriteLine();                            // Pular Linha!
        
        Console.Write("Posição -> ");                   // Posição dos Elementos da Lista
        for(int i = 0; i < QtdElement; i++)
        {
            Console.Write($"| {i} |");                  // Imprimir a Posição dos Elementos da Lista
        }
    }
}