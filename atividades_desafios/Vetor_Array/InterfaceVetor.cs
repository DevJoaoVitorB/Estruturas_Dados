using System;

interface Vetor<T>                              // Interface com os Métodos de um Vetor
{
    void InsertAtRank(int posicao, T objeto);   // Método para Adicionar Elemento em uma Posição X do Vetor
    T RemoveAtRank(int posicao);                // Método para Remover Elemento em uma Posição X do Vetor
    T ReplaceAtRank(int posicao, T objeto);     // Método para Substituir um Elemento por Outro em uma Posição X
    T ElemAtRank(int posicao);                  // Método de Retorno do Elemento da Posição X
    int Size();                                 // Método de Retorno da Quantidade de Elementos do Vetor
    bool IsEmpty();                             // Método para Verificar se o Vetor está Vazio
}