using System;

class FilaArray<T> : Fila<T>
{
  private int Inicio;                   // Atributo de referência do Inicio da Fila
  private int Final;                    // Atributo de referência do Final da Fila
  private int Capacidade;               // Capacidade da FilaArray
  private T[] ArrayFila;                // Array utilizado como Fila

  public FilaArray(int capacidade)
  {
    Capacidade = capacidade;          // Definir a capacidade da FilaArray
    Inicio = Final = 0;               // Sem elementos na FilaArray
    ArrayFila = new T[Capacidade];    // Inicializando a FilaArray
  }

  public void Enqueue(T objeto)
  {
    if(Size() == Capacidade - 1)
    {
      int novaCapacidade = Capacidade*2;                              // Variável auxiliar contendo a nova capacidade da FilaArray

      T[] tempArray = new T[novaCapacidade];                          // Criação de um Array temporário
      int inicioAux = Inicio;                                         // Variável auxiliar contendo o Inicio da FilaArray

      for(int i = 0; i < Size(); i++)
      {
        tempArray[i] = ArrayFila[inicioAux];                          // Colocar os elementos do antigo Array (ArrayFila) para o novo Array (tempArray)
        inicioAux = (inicioAux + 1) % Capacidade;                     // Iterar por todos os elementos da FilaArray
      }

      Final = Size();                                                 // Novo Final
      Inicio = 0;                                                     // Novo Inicio
      Capacidade = novaCapacidade;                                    // Nova Capacidade
      ArrayFila = tempArray;                                          // tempArray passa a ser o novo Array
    }

    ArrayFila[Final] = objeto;                  // Adicionar o novo elemento a FilaArray
    Final = (Final + 1) % Capacidade;           // Novo Final
  }

  public T Dequeue()
  {
    if(IsEmpty()) throw new FilaVaziaExcecao();     // Verificar se a FilaArray está Vazia
    T removido = ArrayFila[Inicio];                 // Remover o elemento do Inicio da FilaArray
    ArrayFila[Inicio] = default;                    // Mudando o valor removido para default
    Inicio = (Inicio + 1) % Capacidade;             // Novo Inicio
    return removido;                                // Retorna o elemento removido
  }

  public T First()
  {
    if(IsEmpty()) throw new FilaVaziaExcecao();     // Verificar se a FilaArray está Vazia
    return ArrayFila[Inicio];                       // Retorna o primeiro elemento
  }

  public bool IsEmpty()
  {
    return Inicio == Final;                             // Verificar se a Inicio da FilaArray é igual ao Final, ou seja, está Vazia
  }

  public int Size()
  {
    return (Capacidade - Inicio + Final) % Capacidade;  // Retorna a quantidade de elementos da FilaArray
  }

  public T[] Array()
  {
    T[] arrayFila = new T[Size()];                      // Cria um ArrayFila auxiliar para armazenar somente os elementos da Fila em ordem
    int auxInicio = Inicio;                             // Variável auxiliar de inicio

    for (int i = 0; i < Size(); i++)
    {
      arrayFila[i] = ArrayFila[auxInicio];              // Adiciona apenas os elementos no ArrayFila auxiliar
      auxInicio = (auxInicio + 1) % Capacidade;         // Incrementa a variável auxiliar de inicio
    }

    return arrayFila;                                   // Retorna o array contendo os elementos da Fila
  }
}