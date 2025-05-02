using System;

class FilaDuasPilhas<T> : Fila<T>
{
  private PilhaArray<object> PilhaEntrada;  // Pilha para a Entrada de elementos na Fila
  private PilhaArray<object> PilhaSaida;    // Pilha para a Saida de elementos na fila

  public FilaDuasPilhas(int capacidade)
  {
    PilhaEntrada = new PilhaArray<object>(capacidade);    // Inicializando a PilhaEntrada      
    PilhaSaida = new PilhaArray<object>(capacidade);      // Inicializando a PilhaSaida        
  }

  public void Enqueue(T objeto)
  {
    PilhaEntrada.Push(objeto);                            // Adicionar elementos no topo da Pilha de Entrada
  }

  public T Dequeue()
  {
    if(IsEmpty()) throw new FilaVaziaExcecao();           // Verificar se a FilaArray está Vazia
    if(PilhaSaida.IsEmpty())                              // Verificar se a Pilha de Saída está vazia
    {
      while (!PilhaEntrada.IsEmpty())                     // Transferir todos os elementos da Pilha de Entrada para a Pilha de Saida
      {
        PilhaSaida.Push(PilhaEntrada.Pop());              // Usado para passar todos os elementos da Pilha de Entrada para a Pilha de Saida invertendo-os
      }
    }
    return (T)PilhaSaida.Pop();                           // Elimina o primeiro elemento que entrou na Pilha de Entrada
  }

  public T First()
  {
    if(IsEmpty()) throw new FilaVaziaExcecao();           // Verificar se a FilaArray está Vazia
    if(PilhaSaida.IsEmpty())                              // Verificar se a Pilha de Saída está vazia
    {
      while (!PilhaEntrada.IsEmpty())                     // Transferir todos os elementos da Pilha de Entrada para a Pilha de Saida
      {
        PilhaSaida.Push(PilhaEntrada.Pop());              // Usado para passar todos os elementos da Pilha de Entrada para a Pilha de Saida invertendo-os
      }
    }
    return (T)PilhaSaida.Top();                           // Elimina o primeiro elemento que entrou na Pilha de Entrada
  }

  public bool IsEmpty()
  {
    return PilhaEntrada.IsEmpty() && PilhaSaida.IsEmpty();      // Verifica se não há elementos nas duas Pilhas, ou seja, Fila está vazia
  }

  public int Size()
  {
    return PilhaEntrada.Size() + PilhaSaida.Size();             // Retorna a quantidade de elementos presentes nas duas Pilhas, ou seja, a quantidade de elementos na Fila
  }

  public void ExibirFilaArray()
  {
    object[] tempPilhaEntrada = new object[PilhaEntrada.Size()];              // Array Auxiliar da Pilha de Entrada
    object[] tempPilhaSaida = new object[PilhaSaida.Size()];                  // Array Auxiliar da Pilha de Saida
    Array.Copy(PilhaEntrada.Array(), tempPilhaEntrada, PilhaEntrada.Size());  // Copia da Pilha de Entrada
    Array.Copy(PilhaSaida.Array(), tempPilhaSaida, PilhaSaida.Size());        // Copia da Pilha de Saida
    Array.Reverse(tempPilhaSaida);                                            // Inverter os elementos da Pilha Saida (Agora o topo é o último elemento da Fila na parte da Pilha de Saida)
    object[] tempArray = new object[Size()];                                  // Array temporário que possui a capacidade para os elementos de ambas as Pilhas

    tempArray = tempPilhaSaida.Concat(tempPilhaEntrada).ToArray();            // Juntar os elementos das duas Pilhas em ordem da chegada da esquerda para a direita

    for (int i = 0; i < Size(); i++)                                          // Exibir os elementos da Fila
    {
      if(i == 0)
      {
        Console.ForegroundColor = ConsoleColor.Green;            
        Console.Write($"| {tempArray[i]} |");
        Console.ResetColor();
      }
      else
      {
        Console.Write($"| {tempArray[i]} |");
      }
    }

    Console.WriteLine("\n");
  }
}