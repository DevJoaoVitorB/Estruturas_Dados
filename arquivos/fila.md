<h1 align="center">📚 TAD - Fila</h1>
<p align="center">🎯 <strong>Estrutura FIFO (First In, First Out)</strong></p>
<p align="center">⚠️ Elemento <strong>inserido primeiro</strong> é o <strong>primeiro a ser removido</strong>.</p>

## 🔧 Operações Principais

* `enqueue(object)` → Adiciona um elemento ao **fim**.
* `object dequeue()` → Remove e retorna o elemento do **inicio**.

## 🧰 Operações Auxiliares

* `object first()` ou `object peek()` → Retorna o elemento do inicio **sem remover**.
* `integer size()` → Retorna o **número de elementos** na fila.
* `boolean isEmpty()` → Verifica se a fila está **vazia**.

<br>

## ⚠️ Exceções

* **EFilaVazia:** Tentativa de `dequeue()` ou `first()` com a fila vazia.
* **EFilaCheia:** Tentativa de `enqueue()` em uma fila sem espaço disponível.

<br>

## 🛠️ Exemplos Práticos

* Filas de espera
* Programação paralela
* Execução de multitarefas em ordens (**Downloads em Fila**)
* Filas de processos no sistema operacional

<br>

## 🧱 Implementação Usando Array (Filas baseadas em Array Circular)

> Uma implementação de fila utilizando um **array fixo**, que pode ser otimizada com a técnica de **alocação circular**.

### 🔧 Estrutura Básica

* Utiliza-se um **array de tamanho fixo `N`**.
* A fila é controlada por **dois índices**:
  * `i` 👉 Índice do **início da fila** (onde os elementos são removidos).
  * `f` 👉 Índice **imediatamente após o fim da fila** (onde os elementos são inseridos).

<br>

### ⚙️ Modo de Funcionamento

#### 🧩 Configuração Padrão (Sem Circularidade)

* À medida que elementos são **removidos**, o índice `i` é incrementado.
* O índice `f` cresce com as **inserções**.
* **Problema:** Mesmo com espaço livre no início do array, ele **não é reutilizado**.
* **Resultado:** Pode parecer que a fila está cheia mesmo havendo espaço ― desperdício de memória.

<br>

#### 🔁 Configuração Circular (Otimizada)

* O array é tratado como um **anel fechado**.
* Quando `f` chega ao fim do array, ele **retorna ao início** (`f = 0`) e começa a preencher os espaços vazios deixados por `i`.
* A fila está **cheia** quando:
  ```text
  (f + 1) % N == i
  ```
* **✅ Isso garante que:**
  * O array seja **plenamente utilizado**.
  * Não haja desperdício de espaço.
  * A fila continue funcionando de forma eficiente mesmo com remoções e inserções contínuas.

* **🔍 Visualização (Fila Circular)**

```text
Array:   [ - ][ B ][ C ][ D ][ - ][ - ]
Índices:        ↑              ↑
              i = 1          f = 4
```

* **📖 Explicação**
  * Elementos `B`, `C`, `D` estão na fila. \
  * Após mais inserções, `f` pode voltar ao índice `0` para reutilizar a posição vazia.

<br>

### ⏱️ Desempenho das Operações

| Operação            | Complexidade | Descrição |
|---------------------|--------------|-----------|
| `enqueue(object)`   | O(1)         | Adiciona no final                 |
| `object dequeue()`  | O(1)         | Remove do inicio                  |
| `object first()`    | O(1)         | Retorna o primeiro elemento       |
| `integer size()`    | O(1)         | Retorna a quantidade de elementos |
| `boolean isEmpty()` | O(1)         | Verifica se está vazia            |

<br>

### ⚠️ Limitações das Filas Baseadas em Arrays

* **Capacidade Fixa**: Arrays possuem capacidade fixa. Quando a fila atinge seu limite, operações como `enqueue(object)` se tornam inviáveis, gerando problemas de **overflow**.
* **Espaço Desperdiçado**: Em uma fila simples baseada em array linear (sem circularidade), quando você remove elementos do início com `dequeue()`, os espaços não são reutilizados automaticamente, gerando uma exceção de EFilaCheia com espaços disponivéis.

> ⚠️ Por isso, para garantir a eficiência e escalabilidade das filas, são implementadas estratégias de **configuração circular** e **redimensionamento dinâmico** como:
>  * [**Estratégia Incremental**](pilha.md/###1-estratégia-incremental) 
>  * [**Estratégia Duplicativa (Exponencial)**](pilha.md/###2-estratégia-duplicativa-exponencial)

<br>

### ✏️ Implementação em C#
```csharp
using System;

public class FilaVaziaException : Exception
{
    public FilaVaziaException() : base("Operação inválida: fila vazia!") { }
    public DequeVazioException(string mensagem) : base(mensagem) { }
    public DequeVazioException(string mensagem, Exception inner) : base(mensagem, inner) { }
}

public interface IFila<T>
{
    void Enqueue(T item);
    T Dequeue();
    T First();
    bool IsEmpty();
    int Size();
}

public class Fila<T> : IFila<T>
{
    private T[] array;
    private int inicio;
    private int fim;
    private int capacidade;

    public Fila(int capacidadeInicial = 10)
    {
        capacidade = capacidadeInicial;
        array = new T[capacidade];
        inicio = 0;
        fim = 0;
    }

    public void Enqueue(T item)
    {
        if (Size() == capacidade)
        {
            Redimensionar();
        }

        array[fim] = item;
        fim = (fim + 1) % capacidade;
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new FilaVaziaException();
        }

        T item = array[inicio];
        array[inicio] = default;
        inicio = (inicio + 1) % capacidade;

        return item;
    }

    public T First()
    {
        if (IsEmpty())
        {
            throw new FilaVaziaException();
        }

        return array[inicio];
    }

    public bool IsEmpty()
    {
        return inicio == fim;
    }

    public int Size()
    {
        return (capacidade - inicio + fim) % capacidade;
    }

    private void Redimensionar()
    {
        int novaCapacidade = capacidade * 2;
        T[] novoArray = new T[novaCapacidade];

        int tamanho = Size();

        for (int i = 0; i < tamanho; i++)
        {
            int indice = (inicio + i) % capacidade;
            novoArray[i] = array[indice];
        }

        array = novoArray;
        capacidade = novaCapacidade;
        inicio = 0;
        fim = tamanho;
    }
}
```
