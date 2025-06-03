<h1 align="center">🗂️ TAD - Vetor</h1>
<p align="center">🎯 <strong>Estrutura Sequencial Indexada</strong></p>
<p align="center">⚠️ Acesso direto por índice (rank) com complexidade O(1)</p>

## 🌍 Analogia do Mundo Real:
Imagine uma fileira de cadeiras numeradas em um auditório:
- Cada cadeira tem um número fixo (índice) que nunca muda
- Você pode sentar diretamente em qualquer cadeira vazia
- Se quiser inserir uma cadeira no meio, precisa deslocar todas as outras
- Quando alguém sai de uma cadeira do meio, as outras devem fechar a lacuna

<br>

## 🔧 Operações Principais

* `insertAtRank(integer, object)` → Insere elemento na posição especificada
  - **Comportamento**: Desloca elementos à direita para abrir espaço
  - **Pré-condição**: 0 ≤ posição ≤ tamanho atual
  - **Pós-condição**: Tamanho aumenta em 1, elementos são reorganizados

* `object removeAtRank(integer)` → Remove e retorna elemento da posição
  - **Comportamento**: Desloca elementos à esquerda para preencher lacuna
  - **Pré-condição**: Vetor não vazio e posição válida
  - **Pós-condição**: Tamanho diminui em 1, elementos são reorganizados

* `object replaceAtRank(integer, object)` → Substitui elemento na posição
  - **Comportamento**: Atualiza valor sem alterar estrutura
  - **Pré-condição**: Posição válida e vetor não vazio
  - **Pós-condição**: Valor alterado, tamanho mantido

<br>

## 🧰 Operações Auxiliares

* `object elemAtRank(integer)` → Retorna elemento sem remover
  - **Uso típico**: Consulta rápida por índice conhecido

* `integer size()` → Retorna quantidade de elementos
  - **Cálculo**: Variável de controle incrementada/decrementada nas operações

* `boolean isEmpty()` → Verifica se vetor está vazio
  - **Critério**: tamanho == 0

<br>

## ⚠️ Exceções (Tratamento de Erros)

* **ERankInvalido:** 
  - Ocorre quando índice < 0 ou índice >= ou > tamanho atual
  - **Solução**: Validar índice antes de operações

* **EVetorVazio:** 
  - Ocorre em remove/replace/elemAtRank com vetor vazio
  - **Solução**: Verificar isEmpty() antes dessas operações

* **EVetorCheio:** 
  - Ocorre em inserção com capacidade máxima (em implementações estáticas)
  - **Solução**: Implementar [redimensionamento dinâmico](pilha.md/#-estratégias-de-redimensionamento)

<br>

## 🛠️ Exemplos Práticos (Aplicações Reais)

1. **Sistemas de Banco de Dados**: 
   - Armazenamento de registros com acesso rápido
   - Implementação de tabelas hash

2. **Processamento de Imagens**:
   - Representação de pixels em matrizes
   - Buffers de frames em vídeos

3. **Jogos Digitais**:
   - Inventários de itens com slots fixos
   - Grids para mapas e colisões

4. **Computação Científica**:
   - Armazenamento de vetores e matrizes
   - Cálculos algébricos e estatísticos

<br>

## 🧱 Implementação com Array Dinâmico

### 🔧 Estrutura Básica

Componentes essenciais:
- `T[] elementos`: Array genérico para armazenamento
- `int tamanho`: Contador de elementos ativos
- `int capacidade`: Limite atual do array

```text
Array:  [10] [20] [30] [--] [--] [--]
Índices:  0    1    2    3    4    5
Tamanho: 3
Capacidade: 6
```


### ⚙️ Modo de Funcionamento

* **`InsertAtRank()`:**
    * No final: O(1) amortizado
    * No meio/inicio: O(n) devido a deslocamentos (deslocamento para direita)
        ```text
        insertAtRank(1, 99)
        Antes: [10] [20] [30] [--] [--] [--]
        Depois: [10] [99] [20] [30] [--] [--]
        ```
* **`RemoveAtRank()`:**
    * Do final: O(1)
    * Do meio/inicio: O(n) devido a deslocamentos (deslocamento para esquerda)
        ```text
        removeAtRank(2)
        Antes: [10] [99] [20] [30] [--] [--]
        Depois: [10] [99] [30] [--] [--] [--]
        ```
* **`ElemAtRank()`**:
    * Qualquer posição: O(1) direto

<br>

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

### ✏️ Implementação Completa em C#
```csharp
using System;

// Exceções customizadas
public class VetorVazioException : Exception {
    public VetorVazioException() : base("Operação inválida: vetor vazio!") {}
    public VetorVazioException(string mensagem) : base(mensagem) {}
}

public class RankInvalidoException : Exception {
    public RankInvalidoException(int pos, int tamanho) 
        : base($"Rank {pos} inválido para vetor com {tamanho} elementos!") {}
    public RankInvalidoException(string mensagem) : base(mensagem) {}
}

// Interface do TAD Vetor
public interface IVetor<T> {
    void InsertAtRank(int rank, T elemento);
    T RemoveAtRank(int rank);
    T ReplaceAtRank(int rank, T novoElemento);
    T ElemAtRank(int rank);
    int Size();
    bool IsEmpty();
}

// Implementação concreta
public class VetorArray<T> : IVetor<T> {
    private T[] elementos;
    private int tamanho;
    private int capacidade;

    public VetorArray(int capacidadeInicial = 10) {
        capacidade = capacidadeInicial;
        elementos = new T[capacidade];
        tamanho = 0;
    }

    public int Size() => tamanho;
    public bool IsEmpty() => tamanho == 0;

    public void InsertAtRank(int rank, T elemento) {
        if (rank < 0 || rank > tamanho)
            throw new RankInvalidaException(rank, tamanho);
        
        if (tamanho == capacidade)
            Redimensionar();

        // Deslocar elementos para direita
        for (int i = tamanho; i > rank; i--) {
            elementos[i] = elementos[i - 1];
        }
        
        elementos[rank] = elemento;
        tamanho++;
    }

    public T RemoveAtRank(int rank) {
        if (IsEmpty()) 
            throw new VetorVazioException();
        
        VerificarRank(rank);
        
        T elementoRemovido = elementos[rank];
        
        // Deslocar elementos para esquerda
        for (int i = rank; i < tamanho - 1; i++) {
            elementos[i] = elementos[i + 1];
        }
        
        tamanho--;
        return elementoRemovido;
    }

    public T ReplaceAtRank(int rank, T novoElemento) {
        if (IsEmpty()) 
            throw new VetorVazioException();
        
        VerificarRank(rank);
        
        T elementoAntigo = elementos[rank];
        elementos[rank] = novoElemento;
        return elementoAntigo;
    }

    public T ElemAtRank(int rank) {
        if (IsEmpty()) 
            throw new VetorVazioException();
        
        VerificarRank(rank);
        
        return elementos[rank];
    }

    private void VerificarRank(int rank) {
        if (rank < 0 || rank >= tamanho)
            throw new RankInvalidaException(rank, tamanho);
    }

    private void Redimensionar() {
        int novaCapacidade = capacidade * 2;
        T[] novoArray = new T[novaCapacidade];
        
        for (int i = 0; i < tamanho; i++) {
            novoArray[i] = elementos[i];
        }
        
        elementos = novoArray;
        capacidade = novaCapacidade;
    }
}
```
