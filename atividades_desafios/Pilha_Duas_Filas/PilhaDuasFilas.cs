using System;

class PilhaDuasFilas<T> : Pilha<T>
{
  private FilaArray<object> FilaPrincipal;    // Fila Principal que é a Pilha
  private FilaArray<object> FilaAuxiliar;     // Fila Auxiliar que ajuda na manipulação das ordens dos elementos na FilaPrincipal

  public PilhaDuasFilas(int capacidade)
  {
    FilaPrincipal = new FilaArray<object>(capacidade);    // Inicializando a FilaPrincipal      
    FilaAuxiliar = new FilaArray<object>(capacidade);     // Inicializando a FilaAuxiliar  
  }

  public void Push(T objeto)
  {
    FilaAuxiliar.Enqueue(objeto);                     // Adicionar o objeto na FilaAuxiliar

    while (!FilaPrincipal.IsEmpty())
    {
      FilaAuxiliar.Enqueue(FilaPrincipal.Dequeue());  // Inverter a posição dos elementos, dessa forma o último elemento inserido sempre vai ser o primeiro da Fila
    }

    var arrayAuxiliar = FilaPrincipal;                // Referência à FilaPrincipal (VAZIA)      
    FilaPrincipal = FilaAuxiliar;                     // FilaAuxiliar passa a ser FilaPrincipal - Na Fila o primeiro elemento é removido no Dequeue() que nesse caso é o último elemento que entrou e que na Pilha é removido no Pop()
    FilaAuxiliar = arrayAuxiliar;                     // FilaAuxiliar torna-se vazia
  }

  public T Pop()
  {
    if(IsEmpty()) throw new FilaVaziaExcecao();                   // Verificar se a FilaPrincipal que é a Pilha está vazia
    return (T)FilaPrincipal.Dequeue();                            // Remover e retorna o primeiro elemento da Fila que é o último da Pilha
  }

  public T Top()
  {
    if(IsEmpty()) throw new FilaVaziaExcecao();                   // Verificar se a FilaPrincipal que é a Pilha está vazia
    return (T)FilaPrincipal.First();                              // Retorna o primeiro elemento da Fila que é o último da Pilha
  }

  public bool IsEmpty()
  {
    return FilaPrincipal.IsEmpty();                               // Retorna se a FilaPrincipal que é a Pilha está vazia
  }

  public int Size()
  {
    return FilaPrincipal.Size();                                  // Retorna a quantidade de elementos na FilaPrincipal que é a Pilha
  }

  public void ExibirPilhaArray()
  {
    object[] tempPilha = FilaPrincipal.Array();                   // Cópia dos elementos da Fila para o array temporária       
    Array.Reverse(tempPilha);                                     // Inverter os elementos da Fila para o primeiro elemento ser o último da Pilha

    for (int i = 0; i < tempPilha.Length; i++)                    // Exibir os elementos da Pilha
    {
      if(i == tempPilha.Length - 1)                               // Exibir o topo da Pilha
      {
        Console.ForegroundColor = ConsoleColor.Green;            
        Console.Write($"| {tempPilha[i]} |");
        Console.ResetColor();
      }
      else                                                        // Exibir os outros elementos da Pilha
      {
        Console.Write($"| {tempPilha[i]} |");
      }
    }

    Console.WriteLine("\n");
  }
}