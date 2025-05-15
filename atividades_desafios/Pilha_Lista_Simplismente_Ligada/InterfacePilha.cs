using System;

interface Pilha<T>                          // Interface com os Métodos de uma Pilha
{
  void Push(T objeto);                      // Método para Adicionar Elemento no Topo da Pilha
  T Pop();                                  // Método para Remover Elemento do Topo da Pilha
  T Top();                                  // Método de Retorno do Elemento do Topo da Pilha
  bool IsEmpty();                           // Método para Verificar se a Pilha está Vazia
  int Size();                               // Método de Retorno da Quantidade de Elementos da Pilha
}