using System;

class No<T>
{
    public No<T> Next {get; set;}                   // Nó de referência próximo
    public No<T> Prev {get; set;}                   // Nó de referência anterior
    public T Objeto {get; set;}                     // Objeto do Nó

    public No(T objeto = default)
    {
        Objeto = objeto;                            // Adicionando um objeto ao Nó
        Next = Prev = null;                         // Inicializando a referência para o próximo e o anterior do Nó como NULL
    }
}