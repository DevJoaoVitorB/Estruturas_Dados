<h1 align="center">📚 TAD - Deque</h1>
<p align="center">🎯 <strong>Estrutura Linear Duplamente Acessível</strong></p>
<p align="center">⚠️ Permite inserções e remoções em <strong>ambas as extremidades</strong>.</p>

## 🔧 Operações Principais

* `addFirst(object)` → Adiciona um elemento no **início**.
* `addLast(object)` → Adiciona um elemento no **final**.
* `object removeFirst()` → Remove e retorna o elemento do **início**.
* `object removeLast()` → Remove e retorna o elemento do **final**.

## 🧰 Operações Auxiliares

* `object first()` → Retorna o primeiro elemento **sem remover**.
* `object last()` → Retorna o último elemento **sem remover**.
* `integer size()` → Retorna o **número de elementos** no deque.
* `boolean isEmpty()` → Verifica se o deque está **vazio**.

<br>

## ⚠️ Exceções

* **EDequeVazio:** Tentativa de `removeFirst()`, `removeLast()`, `first()` ou `last()` em um deque vazio.
* **EDequeCheio:** Tentativa de `addFirst()` ou `addLast()` quando não há espaço disponível (no caso de implementação com capacidade fixa).

<br>

## 🛠️ Exemplos Práticos

* **Filas de impressão** com prioridade reversa
* Algoritmos como **palíndromos** (verifica dos dois lados)
* Navegação com **avanço e retorno** (como no navegador)
* Implementação de **algoritmos de busca BFS/DFS**
* Estrutura de apoio para **sistemas operacionais** (gerenciamento de tarefas)

<br>

## 🧱 Implementação Usando Array (Deque baseado em Array Circular)

> Utiliza-se um **array circular** com controle de início e fim.

### 🔧 Estrutura Básica

* Permite inserções e remoções nas **duas extremidades**
* Utiliza dois ponteiros: `inicio` e `fim`
* Exige controle de **"wrap-around"** (retorno ao início do array)

<br>

### ⚙️ Modo de Funcionamento

#### 🧩 Configuração Padrão (Sem Circularidade)

* Elementos podem ser **inseridos ou removidos** tanto no **início** quanto no **fim**.
* Os índices `início` e `fim` crescem conforme as operações.
* **Problema:** Quando há remoções no início, o espaço liberado **não é reutilizado**.
* **Resultado:** Mesmo com posições vazias no array, o deque pode ser considerado **cheio**.

> ❌ Ineficiente: pode causar **desperdício de memória** e limitações desnecessárias.

<br>

#### 🔁 Configuração Circular (Deque Circular)

* O array é tratado como um **anel fechado** (circular).
* Os índices de **início** e **fim** dão a volta ao atingir o fim do array:
  ```csharp
  inicio = (inicio - 1 + N) % N; // ao inserir no início
  fim = (fim + 1) % N;           // ao inserir no final
  ```
* **✅ Isso garante que:**
    * O deque **utilize todas as posições disponíveis** do array de forma eficiente.
    * Reaproveita o espaço do array.
    * Aconteça o melhor uso da memória.
    * Haja suporte a inserções e remoções contínuas nas duas extremidades sem necessidade de redimensionamento imediato.

* **⛔ Condição de Deque Cheio**
    * O deque está **cheio** quando:
    ```text
    (fim + 1) % N == inicio
    ```
> Ou seja, a próxima posição após o fim é o próprio início.

* **✅ Cálculo do Tamanho (Size)**

    * O número de elementos do deque pode ser calculado por:
    ```csharp
    (N - inicio + fim) % N
    ```
> Ou seja, a distância entre `inicio` e `fim`, corrigida para circularidade.

* **🔍 Visualização (Deque Circular)**

```text
Array:   [ - ][ B ][ C ][ D ][ - ][ - ]
Índices:        ↑              ↑
              i = 1          f = 4
```
* **📖 Explicação**
    * `B`, `C` e `D` estão no deque.
    * Após mais inserções, `f` pode **voltar ao índice `0`** e preencher espaços vazios.

<br>

### ⏱️ Desempenho das Operações

| Operação              | Complexidade | Descrição |
|-----------------------|--------------|-----------|
| `addFirst(object)`    | O(1)         | Insere no início                   |
| `addLast(object)`     | O(1)         | Insere no final                    |
| `object removeFirst()`| O(1)         | Remove do início                   |
| `object removeLast()` | O(1)         | Remove do final                    |
| `object first()`      | O(1)         | Acessa início sem remover          |
| `object last()`       | O(1)         | Acessa final sem remover           |
| `integer size()`      | O(1)         | Retorna a quantidade de elementos  |
| `boolean isEmpty()`   | O(1)         | Verifica se está vazio             |

<br>

### ⚠️ Limitações dos Deques Baseados em Arrays

* **Capacidade Fixa**: Assim como pilhas, arrays possuem limite máximo.
* **Gerenciamento de índices**: É necessário controle do "loop circular" ao usar array fixo.
* **Redimensionamento necessário**: Para permitir crescimento dinâmico, exige realocação com cópia.

> ⚠️ Por isso, para garantir a eficiência e escalabilidade dos Deques, são implementadas estratégias de **redimensionamento dinâmico** usado em TADs Pilha e Fila como:
>  * [**Estratégia Incremental**](pilha.md/###1-estratégia-incremental) 
>  * [**Estratégia Duplicativa (Exponencial)**](pilha.md/###2-estratégia-duplicativa-exponencial)

<br>

## ✏️ Implementação em C#

```csharp
using System;

public class DequeVazioException : Exception
{
    public DequeVazioException() : base("Operação inválida: deque vazio!") { }
    public DequeVazioException(string mensagem) : base(mensagem) { }
    public DequeVazioException(string mensagem, Exception inner) : base(mensagem, inner) { }
}

public interface IDeque<T>
{
    void AddFirst(T item);
    void AddLast(T item);
    T RemoveFirst();
    T RemoveLast();
    T First();
    T Last();
    int Size();
    bool IsEmpty();
}

public class DequeArray<T> : IDeque<T>
{
    private T[] array;
    private int inicio;
    private int fim;
    private int capacidade;

    public DequeArray(int capacidadeInicial = 10)
    {
        capacidade = capacidadeInicial;
        array = new T[capacidade];
        inicio = 0;
        fim = 0;
    }

    public void AddFirst(T item)
    {
        if (Size() == capacidade - 1)
        {
            Redimensionar();
        }

        inicio = (inicio - 1 + capacidade) % capacidade;
        array[inicio] = item;
    }

    public void AddLast(T item)
    {
        if (Size() == capacidade - 1)
        {
            Redimensionar();
        }

        array[fim] = item;
        fim = (fim + 1) % capacidade;
    }

    public T RemoveFirst()
    {
        if (IsEmpty()) throw new DequeVazioException();

        T removido = array[inicio];
        array[inicio] = default;
        inicio = (inicio + 1) % capacidade;
        return removido;
    }

    public T RemoveLast()
    {
        if (IsEmpty()) throw new DequeVazioException();

        fim = (fim - 1 + capacidade) % capacidade;
        T removido = array[fim];
        array[fim] = default;
        return removido;
    }

    public T First()
    {
        if (IsEmpty()) throw new DequeVazioException();

        return array[inicio];
    }

    public T Last()
    {
        if (IsEmpty()) throw new DequeVazioException();

        return array[(fim - 1 + capacidade) % capacidade];
    }

    public int Size()
    {
        return (capacidade - inicio + fim) % capacidade;
    }

    public bool IsEmpty()
    {
        return inicio == fim;
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
