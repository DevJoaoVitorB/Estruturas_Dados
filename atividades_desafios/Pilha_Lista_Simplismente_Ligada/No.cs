using System;

class No<T>
{
    public No<T> Next {get; set;}   // Nó de referência próximo
    public T Objeto {get; set;}     // Objeto do Nó

    public No(T objeto = default)
    {
        Objeto = objeto;            // Adicionando um objeto ao Nó
        Next = null;                // Inicializando a referência para o próximo Nó como NULL
    }
}