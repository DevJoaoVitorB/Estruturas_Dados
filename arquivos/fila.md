<h1 align="center">📚 TAD - Fila</h1>
<p align="center">🎯 <strong>Estrutura FIFO (First In, First Out)</strong></p>
<p align="center">⚠️ Elemento <strong>inserido primeiro</strong> é o <strong>primeiro a ser removido</strong>.</p>

## 🔧 Operações Principais

- `enqueue(object)` → Adiciona um elemento ao **fim** da fila.
- `object dequeue()` → Remove e retorna o elemento do **inicio** da pilha.

## 🧰 Operações Auxiliares

- `object first()` ou `object peek()` → Retorna o elemento do inicio **sem remover**.
- `integer size()` → Retorna o **número de elementos** na fila.
- `boolean isEmpty()` → Verifica se a fila está **vazia**.

<br>

## ⚠️ Exceções

- **EFilaVazia:** Tentativa de `dequeue()` ou `first()` com a fila vazia.
- **EFilaCheia:** Tentativa de `enqueue()` em uma fila sem espaço disponível.

<br>

## 🛠️ Exemplos Práticos

- Filas de espera
- Programação paralela
- Execução de multitarefas em ordens (**Downloads em Fila**)
- Filas de processos no sistema operacional

<br>

## 🧱 Implementação Usando Array (Filas baseadas em Array Circular)

> Uma implementação de fila utilizando um **array fixo**, que pode ser otimizada com a técnica de **alocação circular**.

### 🔧 Estrutura Básica

- Utiliza-se um **array de tamanho fixo `N`**.
- A fila é controlada por **dois índices**:
  - `i` 👉 Índice do **início da fila** (onde os elementos são removidos).
  - `f` 👉 Índice **imediatamente após o fim da fila** (onde os elementos são inseridos).

<br>

### ⚙️ Modo de Funcionamento

#### 🧩 Configuração Padrão (Sem Circularidade)

- À medida que elementos são **removidos**, o índice `i` é incrementado.
- O índice `f` cresce com as **inserções**.
- **Problema:** Mesmo com espaço livre no início do array, ele **não é reutilizado**.
- **Resultado:** Pode parecer que a fila está cheia mesmo havendo espaço ― desperdício de memória.

<br>

#### 🔁 Configuração Circular (Otimizada)

- O array é tratado como um **anel fechado**.
- Quando `f` chega ao fim do array, ele **retorna ao início** (`f = 0`) e começa a preencher os espaços vazios deixados por `i`.
- A fila está **cheia** quando:
  ```text
  (f + 1) % N == i
  ```
- **✅ Isso garante que:**
  - O array seja **plenamente utilizado**.
  - Não haja desperdício de espaço.
  - A fila continue funcionando de forma eficiente mesmo com remoções e inserções contínuas.

- **🔍 Visualização (Fila Circular)**

```text
Array:   [ - ][ B ][ C ][ D ][ - ][ - ]
Índices:        ↑              ↑
              i = 1          f = 4
```

- **📖 Explicação**
  - Elementos `B`, `C`, `D` estão na fila. \
  - Após mais inserções, `f` pode voltar ao índice `0` para reutilizar a posição vazia.

<br>

### ⏱️ Desempenho das Operações

| Operação            | Complexidade | Descrição                         |
|---------------------|--------------|-----------------------------------|
| `enqueue(object)`   | O(1)         | Adiciona no final                 |
| `object dequeue()`  | O(1)         | Remove do inicio                  |
| `object first()`    | O(1)         | Retorna o primeiro elemento       |
| `interger size()`   | O(1)         | Retorna a quantidade de elementos |
| `boolean isEmpty()` | O(1)         | Verifica se está vazia            |

<br>

### ⚠️ Limitações das Filas Baseadas em Arrays

- **Capacidade Fixa**: Arrays possuem capacidade fixa. Quando a fila atinge seu limite, operações como `enqueue(object)` se tornam inviáveis, gerando problemas de **overflow**.
- **Espaço Desperdiçado**: Em uma fila simples baseada em array linear (sem circularidade), quando você remove elementos do início com `dequeue()`, os espaços não são reutilizados automaticamente, gerando uma exceção de EFilaCheia com espaços disponivéis.

> ⚠️ Por isso, para garantir a eficiência e escalabilidade das filas, são implementadas estratégias de **redimensionamento dinâmico** ([**Estratégia Incremental**](pilha.md/#1-estratégia-incremental) e [**Estratégia Duplicativa (Exponencial)**](pilha.md/#2-estratégia-duplicativa-exponencial).) e **configuração circular**.

<br>

### ✏️ Implementação em C#
```csharp
using System;

class FilaVaziaExcecao : Exception      // Classe de Exceção de Fila Vazia
{
  public FilaVaziaExcecao() : base("A Fila está vazia!") {}
  public FilaVaziaExcecao(string mensagem) : base(mensagem) {}
  public FilaVaziaExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}

interface Fila<T>                       // Interface com os Métodos de uma Fila
{
  void Enqueue(T objeto);               // Método para Adicionar Elemento no Final da Fila
  T Dequeue();                          // Método para Remover Elemento do Inicio da Fila
  T First();                            // Método de Retorno do Primeiro Elemento da Fila
  bool IsEmpty();                       // Método para Verificar se a Fila está Vazia
  int Size();                           // Método de Retorno da Quantidade de Elementos da Fila
}

using System;

class FilaArray<T> : Fila<T>
{
  private int Inicio;                   // Atributo de referência do Inicio da Fila
  private int Final;                    // Atributo de referência do Final da Fila
  private int FC;                       // Fator de Crescimento da FilaArray - Incremental ou Duplicativa
  private int Capacidade;               // Capacidade da FilaArray
  private T[] ArrayFila;                // Array utilizado como Fila

  public FilaArray(int capacidade, int crescimento)
  {
    Capacidade = capacidade;          // Definir a capacidade da FilaArray
    Inicio = Final = 0;               // Sem elementos na FilaArray
    if(crescimento <= 0) FC = 0;      // Fator de Crescimento por Duplicação
    else FC = crescimento;            // Fator de Crescimento por Incrementação
    ArrayFila = new T[Capacidade];    // Inicializando a FilaArray
  }

  public void Enqueue(T objeto)
  {
    if(Size() == Capacidade - 1)
    {
      int novaCapacidade = Capacidade;                                // Variável auxiliar contendo a nova capacidade da FilaArray

      if(FC == 0) novaCapacidade *= 2;                                // Redimensionamento por Duplicação
      else novaCapacidade += FC;                                      // Redimensionamento por Incrementação

      T[] tempArray = new T[novaCapacidade];                          // Criação de um Array temporário
      int inicioAux = Inicio;                                         // Variável auxiliar contendo o Inicio da FilaArray

      for(int i = 0; i < Size(); i++)
      {
        tempArray[i] = ArrayFila[inicioAux];                          // Colocar os elementos do antigo Array (ArrayFila) para o novo Array (tempArray)
        inicioAux = (inicioAux + 1) % Capacidade;                     // Iterar por todos os elementos da FilaArray
      }

      ArrayFila = tempArray;                                          // tempArray passa a ser o novo Array
      Inicio = 0;                                                     // Novo Inicio
      Final = Size();                                                 // Novo Final
      Capacidade = novaCapacidade;                                    // Nova Capacidade
    }

    ArrayFila[Final] = objeto;                  // Adicionar o novo elemento a FilaArray
    Final = (Final + 1) % Capacidade;           // Novo Final
  }

  public T Dequeue()
  {
    if(IsEmpty()) throw new FilaVaziaExcecao();     // Verificar se a FilaArray está Vazia
    T removido = ArrayFila[Inicio];                 // Remover o elemento do Inicio da FilaArray
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
}
```
