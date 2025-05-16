using System;

interface Lista<T>
{
    void InsertFirst(T objeto);                     // Método para Inserir Elemento no Início da Lista
    void InsertLast(T objeto);                      // Método para Inserir Elemento no Final da Lista
    void InsertAfter(T objetoRef, T objeto);        // Método para Inserir Elemento Depois de Outro Elemento da Lista
    void InsertBefore(T objetoRef, T objeto);       // Método para Inserir Elemento Antes de Outro Elemento da Lista
    T ReplaceElement(T objetoRef, T objeto);        // Método para Substituir Elemento Antigo da Lista por Elemento Novo
    void SwapElement(T objetoRef1, T objetoRef2);   // Método para Trocar Posição do Elemento com Outro Elemento da Lista
    T Remove(T objeto);                             // Método para Remover e Retornar Elemento da Lista
    No<T> First();                                  // Método para Retornar o Primeiro Elemento da Lista
    No<T> Last();                                   // Método para Retornar o Último Elemento da Lista
    bool InFirst(T objeto);                         // Método para Verificar se Elemento está na Primeira Posição da Lista
    bool InLast(T objeto);                          // Método para Verificar se Elemento está na Última Posição da Lista
    No<T> After(T objeto);                          // Método para Retornar Elemento Posterior a Outro Elemento da Lista
    No<T> Before(T objeto);                         // Método para Retornar Elemento Anterior a Outro Elemento da Lista
    int Size();                                     // Método para Retornar Número de Elementos da Lista
    bool IsEmpty();                                 // Método para Verificar se a Lista está Vazia
    No<T> Search(T objeto);                         // Método para Retornar Elemento da Lista se Existir
}