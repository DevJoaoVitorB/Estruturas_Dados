using System;

interface Fila<T>                       // Interface com os Métodos de uma Fila
{
  void Enqueue(T objeto);               // Método para Adicionar Elemento no Final da Fila
  T Dequeue();                          // Método para Remover Elemento do Inicio da Fila
  T First();                            // Método de Retorno do Primeiro Elemento da Fila
  bool IsEmpty();                       // Método para Verificar se a Fila está Vazia
  int Size();                           // Método de Retorno da Quantidade de Elementos da Fila
}