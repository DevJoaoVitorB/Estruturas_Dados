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

| Operação              | Complexidade | Descrição                          |
|-----------------------|--------------|------------------------------------|
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
>  * [**Estratégia Incremental**](pilha.md/#1-estratégia-incremental) 
>  * [**Estratégia Duplicativa (Exponencial)**](pilha.md/#2-estratégia-duplicativa-exponencial)

<br>

## ✏️ Implementação em C#

```csharp
using System;

class DequeVazioExcecao : Exception     // Classe de Exceção de Deque Vazio
{
    public DequeVazioExcecao() : base("O Deque está vazio!") {}
    public DequeVazioExcecao(string mensagem) : base(mensagem) {}
    public DequeVazioExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}'
}

interface Deque<T>              // Interface com os Métodos de uma Pilha
{
    void AddFirst(T objeto);      // Método para Adicionar Elemento no Inicio do Deque
    void AddLast(T objeto);       // Método para Adicionar Elemento no Final do Deque
    T RemoveFirst();              // Método para Remover Elemento do Inicio do Deque
    T RemoveLast();               // Método para Remover Elemento do Final do Deque
    T First();                    // Método de Retorno do Primeiro Elemento do Deque
    T Last();                     // Método de Retorno do Último Elemento do Deque
    int Size();                   // Método de Retorno da Quantidade de Elementos do Deque
    bool IsEmpty();               // Método para Verificar se o Deque está Vazio
}

class DequeArray<T> : Deque<T>
{
    private int Inicio;       // Atributo de referência do Inicio do Deque
    private int Final;        // Atributo de referência do Final do Deque
    private int FC;           // Fator de Crescimento do DequeArray - Incremental ou Duplicativa
    private int Capacidade;   // Capacidade do DequeArray
    private T[] ArrayDeque;   // Array utilizado como Deque

    public DequeArray(int capacidade, int crescimento)
    {
        Capacidade = capacidade;            // Definir a capacidade do DequeArray
        Inicio = Final = 0;                 // Sem elementos no DequeArray
        if(crescimento <= 0) FC = 0;        // Fator de Crescimento por Duplicação
        else FC = crescimento;              // Fator de Crescimento por Incrementação
        ArrayDeque = new T[Capacidade];     // Inicializando o DequeArray
    }

    private void Redimensionar()
    {
        int novaCapacidade = 0;                                         // Variável auxiliar contendo a nova capacidade do DequeArray

        if(FC == 0) novaCapacidade *= 2;                                // Redimensionamento por Duplicação
        else novaCapacidade += FC;                                      // Redimensionamento por Incrementação
        
        T[] tempArray = new T[novaCapacidade];                          // Criação de um Array temporário
        for (int i = 0; i < Size(); i++)
        {
            tempArray[i] = ArrayDeque[(Inicio + i) % Capacidade];         // Colocar os elementos do antigo Array (ArrayDeque) para o novo Array (tempArray)
        }

        ArrayDeque = tempArray;                                         // tempArray passa a ser o novo Array
        Inicio = 0;                                                     // Novo Inicio
        Final = Size();                                                 // Novo Final
        Capacidade = novaCapacidade;                                    // Nova Capacidade
    }

    public void AddFirst(T objeto)
    {
        if (Size() == Capacidade - 1) Redimensionar();                  // Redimensionamento do tamanho do DequeArray - Excedeu o Limite

        Inicio = (Inicio - 1 + Capacidade) % Capacidade;                // Novo Inicio
        ArrayDeque[Inicio] = objeto;                                    // Adicionar o novo primeiro elemento no DequeArray
    }

    public void AddLast(T objeto)
    {
        if (Size() == Capacidade - 1) Redimensionar();                  // Redimensionamento do tamanho do DequeArray - Excedeu o Limite

        ArrayDeque[Final] = objeto;                                     // Adicionar o novo último elemento no DequeArray
        Final = (Final + 1) % Capacidade;                               // Novo Final
    }

    public T RemoveFirst()
    {
        if (IsEmpty()) throw new DequeVazioExcecao();                   // Verificar se o DequeArray está Vazio
        T removido = ArrayDeque[Inicio];                                // Remover o elemento do Inicio do DequeArray
        Inicio = (Inicio + 1) % Capacidade;                             // Novo Inicio   
        return removido;                                                // Retorna o elemento removido
    }

    public T RemoveLast()
    {
        if (IsEmpty()) throw new DequeVazioExcecao();                   // Verificar se o DequeArray está Vazio
        Final = (Final - 1 + Capacidade) % Capacidade;                  // Remover o elemento do Final do DequeArray
        T removido = ArrayDeque[Final];                                 // Novo Final
        return removido;                                                // Retorna o elemento removido
    }

    public T First()
    {
        if (IsEmpty()) throw new DequeVazioExcecao();                   // Verificar se o DequeArray está Vazio
        return ArrayDeque[Inicio];                                      // Retorna o primeiro elemento 
    }

    public T Last()
    {
        if (IsEmpty()) throw new DequeVazioExcecao();                   // Verificar se o DequeArray está Vazio
        return ArrayDeque[(Final - 1 + Capacidade) % Capacidade];       // Retorna o último elemento 
    }

    public int Size()
    {
        return (Capacidade - Inicio + Final) % Capacidade   // Retorna a quantidade de elementos do DequeArray
    }

    public bool IsEmpty()
    {
        return Inicio == Final;                                         // Verificar se o Deque está vazio
    }
}
```
