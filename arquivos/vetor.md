<h1 align="center">🗂️ TAD - Vetor</h1>
<p align="center">🎯 <strong>Estrutura Sequencial Baseada em Índices</strong></p>
<p align="center">⚠️ Permite acesso direto a qualquer posição pelo seu índice (rank).</p>

## 🔧 Operações Principais

* `insertAtRank(integer, object)` → **Insere** o elemento `X` na posição `R`, deslocando os demais.
* `object removeAtRank(integer)` → **Remove** o elemento da posição `R`, ajustando as demais posições.
* `object replaceAtRank(integer, object)` → **Substitui** o elemento na posição `R` por `X`.

## 🧰 Operações Auxiliares

* `object elemAtRank(integer)` → Retorna o **elemento na posição** `R`.
* `integer size()` → Retorna o **número de elementos** no vetor.
* `boolean isEmpty()` → Verifica se o vetor está **vazio**.

<br>

## ⚠️ Exceções

* **ERankInvalido:** Quando o índice `R` está fora dos limites do vetor.
* **EVetorVazio:** Tentativa de acessar, substituir ou remover elementos de um vetor que está vazio.
* **EVetorCheio:** Tentativa de inserção quando o vetor está com a capacidade máxima.

<br>

## 🛠️ Exemplos Práticos

* Representação de tabelas e vetores matemáticos
* Implementação de outras estruturas como pilhas, filas, listas
* Armazenamento de elementos com acesso rápido por índice
* Controle de sprites em jogos e buffers em editores de texto

<br>

## 🧱 Implementação com Array Tradicional (Linear)

> A implementação padrão do TAD **Vetor** utiliza um **array linear**, pois ele é otimizado para acesso por índice e suporta inserções/remoções em posições arbitrárias com deslocamentos diretos.

### ✅ Vantagens

* Acesso direto a qualquer posição com complexidade **O(1)**.
* Mantém os elementos em ordem lógica contínua.
* Facilita o deslocamento dos elementos quando necessário (para frente ou para trás).
* Ideal para estruturas com **acesso por rank**, como listas indexadas e vetores dinâmicos.

<br>

### 🧠 Por que não usar Array Circular?

> Apesar de arrays circulares serem eficientes para **filas** e **deques**, eles **não são vantajosos para o TAD Vetor**. Isso porque:

* O TAD Vetor requer que os elementos sejam mantidos em **ordem sequencial lógica**.
* Inserções e remoções no meio do vetor ainda exigem **deslocamento de elementos**, o que **anula os benefícios do array circular**.
* A lógica de modularidade introduz uma complexidade desnecessária para uma estrutura cujo foco é o acesso direto e simples via índice.

<br>

### 🔍 Exemplo Visual (Vetor Linear)

```text
Capacidade: 6
Tamanho: 3

Array:   [10] [20] [30] [--] [--] [--]
Índice:   0    1    2    3     4     5
Lógico:  [10] [20] [30]
```

> Uma inserção no índice 1 (`insertAtRank(1, 99)`) desloca `20` e `30` para a direita:
>
> Resultado:
> `[10] [99] [20] [30]`
>
>
> Uma remoção no índice 2 (`removeAtRank(1)`) desloca `20` e `30` para a esquerda:
>
> Resultado:
> `[10] [20] [30]`

<br>

### ⏱️ Desempenho das Operações

| Operação                                | Complexidade | Descrição |
| --------------------------------------- | ------------ | ----------|
| `insertAtRank(integer, object)`         | O(n)         | Desloca elementos para inserir             |
| `object removeAtRank(integer)`          | O(n)         | Desloca elementos para remover             |
| `object replaceAtRank(integer, object)` | O(1)         | Substitui valor diretamente                |
| `object elemAtRank(integer)`            | O(1)         | Acesso direto via índice                   |
| `integer size()`                        | O(1)         | Retorna o número de elementos              |
| `boolean isEmpty()`                     | O(1)         | Verifica se está vazio                     |

<br>

## ⚠️ Limitações do Vetor com Array

* **Capacidade Fixa**: Ao atingir o limite, não é possível inserir mais sem realocar.
* **Custo de Realocação**: Para crescer, é necessário criar um novo array maior e copiar os elementos.
* **Inserções e remoções no meio** são **custosas**, exigindo deslocamentos de vários elementos.

> 💡 Para garantir eficiência e escalabilidade, o TAD Vetor usa estratégias de **redimensionamento dinâmico** como:
>
> - [**Estratégia Incremental**](pilha.md/###1-estratégia-incremental)  
> - [**Estratégia Duplicativa (Exponencial)**](pilha.md/###2-estratégia-duplicativa-exponencial)

<br>

### ✏️ Implementação em C#
```csharp
using System;

class VetorVazioExcecao : Exception
{
    public VetorVazioExcecao() : base("Operação inválida: vetor vazio!") {}
    public VetorVazioExcecao(string mensagem) : base(mensagem) {}
    public VetorVazioExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}

class RankInvalidoExcecao : Exception
{
    public RankInvalidoExcecao() : base("Rank informado inválido!") {}
    public RankInvalidoExcecao(string mensagem) : base(mensagem) {}
    public RankInvalidoExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}

interface IVetor<T>
{
    void InsertAtRank(int rank, T item);
    T RemoveAtRank(int rank);
    T ReplaceAtRank(int rank, T item);
    T ElemAtRank(int rank);
    int Size();
    bool IsEmpty();
}

class VetorArray<T> : IVetor<T>
{
    private T[] array;
    private int capacidade;
    private int quantidade;

    public VetorArray(int capacidadeInicial = 10)
    {
        array = new T[capacidadeInicial];
        capacidade = capacidadeInicial;
        quantidade = 0;
    }

    public void InsertAtRank(int rank, T item)
    {
        if (rank < 0 || rank > quantidade)
            throw new RankInvalidaExcecao();

        if (quantidade == capacidade)
            Redimensionar();

        for (int i = quantidade; i > rank; i--)
            array[i] = array[i - 1];

        array[rank] = item;
        quantidade++;
    }

    public T RemoveAtRank(int rank)
    {
        if (IsEmpty())
            throw new VetorVazioExcecao();

        if (rank < 0 || rank >= quantidade)
            throw new RankInvalidaExcecao();

        T removido = array[rank];

        for (int i = rank; i < quantidade - 1; i++)
            array[i] = array[i + 1];

        quantidade--;
        return removido;
    }

    public T ReplaceAtRank(int rank, T item)
    {
        if (IsEmpty())
            throw new VetorVazioExcecao();

        if (rank < 0 || rank >= quantidade)
            throw new RankInvalidaExcecao();

        T substituido = array[rank];
        array[rank] = item;
        return substituido;
    }

    public T ElemAtRank(int rank)
    {
        if (IsEmpty())
            throw new VetorVazioExcecao();

        if (rank < 0 || rank >= quantidade)
            throw new RankInvalidaExcecao();

        return array[rank];
    }

    public int Size()
    {
        return quantidade;
    }

    public bool IsEmpty()
    {
        return quantidade == 0;
    }

    private void Redimensionar()
    {
        capacidade *= 2;
        T[] novoArray = new T[capacidade];

        for (int i = 0; i < quantidade; i++)
            novoArray[i] = array[i];

        array = novoArray;
    }
}
```
