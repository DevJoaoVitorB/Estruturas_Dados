using System;

interface Lista<T>
{
    void InsertFirst(T objeto);                     // Método para Inserir Elemento no Início da Lista
    void InsertLast(T objeto);                      // Método para Inserir Elemento no Final da Lista
    void InsertAfter(T posicao, T objeto);          // Método para Inserir Elemento Depois de Outro Elemento da Lista
    void InsertBefore(T posicao, T objeto);         // Método para Inserir Elemento Antes de Outro Elemento da Lista
    T ReplaceElement(T posicao, T objeto);          // Método para Substituir Elemento Antigo da Lista por Elemento Novo
    void SwapElement(T posicao1, T posicao2);       // Método para Trocar Posição do Elemento com Outro Elemento da Lista
    T Remove(T posicao);                            // Método para Remover e Retornar Elemento da Lista
    T First();                                      // Método para Retornar o Primeiro Elemento da Lista
    T Last();                                       // Método para Retornar o Último Elemento da Lista
    bool InFirst(T posicao);                        // Método para Verificar se Elemento está na Primeira Posição da Lista
    bool InLast(T posicao);                         // Método para Verificar se Elemento está na Última Posição da Lista
    T After(T posicao);                             // Método para Retornar Elemento Posterior a Outro Elemento da Lista
    T Before(T posicao);                            // Método para Retornar Elemento Anterior a Outro Elemento da Lista
    int Size();                                     // Método para Retornar Número de Elementos da Lista
    bool IsEmpty();                                 // Método para Verificar se a Lista está Vazia
    T Search(T posicao);                            // Método para Retornar Elemento da Lista se Existir
}