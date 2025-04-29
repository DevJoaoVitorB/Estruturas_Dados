using System;

interface Fila
{
    void Enqueue(object objeto);                // Método para Adicionar Elemento no Final da Fila
    object Dequeue();                           // Método para Remover Elemento do Inicio da Fila
    object First();                             // Método de Retorno do Primeiro Elemento da Fila
    bool IsEmpty();                             // Método para Verificar se a Fila está Vazia
    int Size();                                 // Método de Retorno da Quantidade de Elementos da Fila
}