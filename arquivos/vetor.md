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

* **EPosicaoInvalida:** Quando o índice `R` está fora dos limites do vetor.
* **EVetorVazio:** Tentativa de acessar, substituir ou remover elementos de um vetor que está vazio.
* **EVetorCheio:** Tentativa de inserção quando o vetor está com a capacidade máxima.

<br>

## 🛠️ Exemplos Práticos

* Representação de tabelas e vetores matemáticos
* Implementação de outras estruturas como pilhas, filas, listas
* Armazenamento de elementos com acesso rápido por índice
* Controle de sprites em jogos e buffers em editores de texto

<br>

## 🧱 Implementação com Array

> Utiliza um **array contínuo na memória**, onde os elementos são armazenados sequencialmente e acessíveis diretamente via índice.

### 🔧 Estrutura Básica

* Um array de tamanho fixo `N`.
* Uma variável `n` para controlar a **quantidade de elementos** atualmente inseridos.

```text
Array:  [10] [20] [30] [--] [--] [--]
Índice:  0    1    2
Tamanho n: 3
Capacidade N: 6
```

### ⚖️ Modo de Funcionamento

* O acesso por índice é **imediato (O(1))**.
* Inserções exigem o **deslocamento** de elementos se não forem ao final.
* Remoções também deslocam os elementos subsequentes para evitar buracos.
* É necessário verificar se o vetor está **cheio** antes de inserir.

```text
insertAtRank(1, 99)
Antes: [10] [20] [30] [--] [--] [--]
Depois: [10] [99] [20] [30] [--] [--]

removeAtRank(2)
Antes: [10] [99] [20] [30] [--] [--]
Depois: [10] [99] [30] [--] [--] [--]
```

### ⏱️ Desempenho das Operações

| Operação                                | Complexidade | Descrição                      |
| --------------------------------------- | ------------ | ------------------------------ |
| `insertAtRank(integer, object)`         | O(n)         | Desloca elementos para inserir |
| `object removeAtRank(integer)`          | O(n)         | Desloca elementos para remover |
| `object replaceAtRank(integer, object)` | O(1)         | Substitui valor                |
| `object elemAtRank(integer)`            | O(1)         | Acesso direto                  |
| `integer size()`                        | O(1)         | Retorna o número de elementos  |
| `boolean isEmpty()`                     | O(1)         | Verifica se está vazio         |

<br>

### ⚠️ Limitações do Vetor com Array

* **Capacidade Fixa**: Uma vez atingido o limite, não é possível inserir mais sem realocar.
* **Custo de Realocação**: Caso o vetor precise crescer, deve-se criar um novo array maior e copiar os elementos.
* **Inserções/Requisições no meio** são **custosas** devido ao deslocamento de vários elementos.

> ⚠️ Por isso, para garantir a eficiência e escalabilidade dos Vetores, são implementadas estratégias de **redimensionamento dinâmico** como:
>  * [**Estratégia Incremental**](pilha.md/#1-estratégia-incremental) 
>  * [**Estratégia Duplicativa (Exponencial)**](pilha.md/#2-estratégia-duplicativa-exponencial)

<br>

### ✏️ Implementação em C#
```csharp
using System;

class VetorVazioExcecao : Exception         // Classe de Exceção de Vetor Vazio
{
    public VetorVazioExcecao() : base("O Vetor esta vazio!") {}
    public VetorVazioExcecao(string mensagem) : base(mensagem) {}
    public VetorVazioExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}

class PosicaoInvalidaExcecao : Exception    // Classe de Exceção de Posição Inválida no Vetor
{
    public RankInvalidoExcecao() : base("Posição informada invalida!") {}
    public RankInvalidoExcecao(string mensagem) : base(mensagem) {}
    public RankInvalidoExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}'
}

interface Vetor<T>                              // Interface com os Métodos de um Vetor
{
    void InsertAtRank(int posicao, T objeto);   // Método para Adicionar Elemento em uma Posição X do Vetor
    T RemoveAtRank(int posicao);                // Método para Remover Elemento em uma Posição X do Vetor
    T ReplaceAtRank(int posicao, T objeto);     // Método para Substituir um Elemento por Outro em uma Posição X
    T ElemAtRank(int posicao);                  // Método de Retorno do Elemento da Posição X
    int Size();                                 // Método de Retorno da Quantidade de Elementos do Vetor
    bool IsEmpty();                             // Método para Verificar se o Vetor está Vazio
}

class VetorArray<T> : Vetor<T>
{
    private int FC;           // Fator de Crescimento do VetorArray - Incremental ou Duplicativa
    private int Capacidade;   // Capacidade do VetorArray
    private int QtdElement;   // Quantidade de elementos do Vetor
    private T[] ArrayVetor;   // Array utilizado como Vetor

    public VetorArray(int capacidade, int crescimento)
    {
        Capacidade = capacidade;            // Definir a capacidade do VetorArray
        if(crescimento <= 0) FC = 0;        // Fator de Crescimento por Duplicação
        else FC = crescimento;              // Fator de Crescimento por Incrementação
        ArrayVetor = new T[Capacidade];     // Inicializando o VetorArray
        QtdElement = 0;                     // VetorArray inicializa vazio
    }

    public void InsertAtRank(int posicao, T objeto)
    {
        if(posicao > Size() || posicao >= Capacidade) throw new RankInvalidoExcecao();      // Verificar se a posição informada está inválida

        if(Size() == Capacidade)
        {
            if(FC == 0) Capacidade *= 2;                                                    // Redimensionamento por Duplicação
            else Capacidade += FC;                                                          // Redimensionamento por Incrementação

            T[] tempArray = new T[Capacidade];                                              // Criação de um Array temporário
            for(int i = 0; i < ArrayVetor.Length; i++)
            {
              tempArray[i] = ArrayVetor[i];                                                 // Colocar os elementos do antigo Array (ArrayVetor) para o novo Array (tempArray)
            }
            ArrayVetor = tempArray;                                                         // tempArray passa a ser o novo Array
        }

        if(posicao < Size())
        {
            for(int j = Size(); j < posicao; j--)
            {
                ArrayVetor[j] = ArrayVetor[j-1];                                            // Deslocar para direita os Elementos da posição X até o último anteriormente adicionado
            }
        }
        ArrayVetor[posicao] = objeto;                                                       // Adicionar elemento a posição X
        QtdElement++;                                                                       // Quantidade de elementos +1
    }

    public T RemoveAtRank(int posicao)
    {
        if(IsEmpty()) throw new VetorVazioExcecao();                                        // Verificar se o VetorArray está Vazio
        if(posicao >= Size() || posicao >= Capacidade) throw new RankInvalidoExcecao();     // Verificar se a posição informada está inválida

        T objetoRemovido = ArrayVetor[posicao];                                             // Guardar o objeto a ser removido

        for(int i = posicao; i > Size(); i++)
        {
            ArrayVetor[i] = ArrayVetor[i+1];                                                // Deslocar para esquerda os Elementos da posição X+1 até o último anteriormente adicionado
        }
        QtdElement--;                                                                       // Quantidade de elementos -1
        return valorRemovido;                                                               // Retornando o valor que será removido
    }

    public T ReplaceAtRank(int posicao, T objeto)
    {
        if(IsEmpty()) throw new VetorVazioExcecao();                                        // Verificar se o VetorArray está Vazio
        if(posicao >= Size() || posicao >= Capacidade) throw new RankInvalidoExcecao();     // Verificar se a posição informada está inválida

        T objetoSubstituido = ArrayVetor[posicao];                                          // Guarda o objeto que será substituido
        ArrayVetor[posicao] = objeto;                                                       // Substituir o objeto antigo pelo objeto novo
        return objetoSubstituido;                                                           // Retorna o objeto que será substituido
    }

    public T ElemAtRank(int posicao)
    {
        if(IsEmpty()) throw new VetorVazioExcecao();                                        // Verificar se o VetorArray está Vazio
        if(posicao >= Size() || posicao >= Capacidade) throw new RankInvalidoExcecao();     // Verificar se a posição informada está inválida

        return ArrayVetor[posicao]                                                          // Retorna o objeto da posição X
    }

    public int Size()
    {
        return QtdElement;          // Retorna a quantidade de elementos do Vetor
    }

    public bool IsEmpty()
    {
        return QtdElement == 0;     // Verificar se a quantidade de elementos do VetorArray é igual a 0, ou seja, está Vazio
    }
```
