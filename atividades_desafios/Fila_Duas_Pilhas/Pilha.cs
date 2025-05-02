using System;
class PilhaArray<T> : Pilha<T>
{
  private int Topo;         // Atributo de referência do Topo da Pilha
  private int Capacidade;   // Capacidade da PilhaArray
  private T[] ArrayPilha;   // Array utilizado como Pilha

  public PilhaArray(int capacidade)
  {
    Capacidade = capacidade;          // Definir a capacidade da PilhaArray
    Topo = -1;                        // Sem elementos na PilhaArray
    ArrayPilha = new T[Capacidade];   // Inicializando a PilhaArray
  }

  public void Push(T objeto)
  {
    if(Topo >= Capacidade-1)                // Redimensionamento do tamanho da PilhaArray - Excedeu o Limite
    {
      Capacidade *= 2;                      // Estratégia Duplicativa

      T[] tempArray = new T[Capacidade];    // Criação de um Array temporário
      for(int i = 0; i < ArrayPilha.Length; i++)
      {
        tempArray[i] = ArrayPilha[i];       // Colocar os elementos do antigo Array (ArrayPilha) para o novo Array (tempArray)
      }
      ArrayPilha = tempArray;               // tempArray passa a ser o novo Array
    }
    ArrayPilha[++Topo] = objeto;            // Adicionar o novo elemento a PilhaArray
  }

  public T Pop()
  {
    if(IsEmpty()) throw new PilhaVaziaExcecao();  // Verificar se a PilhaArray está Vazia
    T removido = ArrayPilha[Topo--];              // Remover o elemento do Topo da PilhaArray
    return removido;                              // Retorna o elemento removido
  }

  public T Top()
  {
    if(IsEmpty()) throw new PilhaVaziaExcecao();  // Verificar se a PilhaArray está Vazia
    return ArrayPilha[Topo];                      // Retorna o elemento do Topo
  }

  public bool IsEmpty()
  {
    return Topo == -1;                     // Verificar se a Topo da PilhaArray é igual a -1, ou seja, está Vazia
  }

  public int Size()
  {
    return Topo + 1;                       // Retorna a quantidade de elementos da PilhaArray
  }

  public T[] Array()
  {
    return ArrayPilha;
  }
}