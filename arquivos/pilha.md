<h1 align="center">📚 TAD - Pilha</h1>
<p align="center">🎯 <strong>Estrutura LIFO (Last In, First Out)</strong></p>
<p align="center">⚠️ Elemento <strong>inserido por último</strong> é o <strong>primeiro a ser removido</strong>.</p>

## 🔧 Operações Principais

* `push(object)` → Adiciona um elemento ao **topo**.
* `object pop()` → Remove e retorna o elemento do **topo** da pilha.

## 🧰 Operações Auxiliares

* `object top()` ou `object peek()` → Retorna o elemento do topo **sem remover**.
* `integer size()` → Retorna o **número de elementos** na pilha.
* `boolean isEmpty()` → Verifica se a pilha está **vazia**.

<br>

## ⚠️ Exceções

* **EPilhaVazia:** Tentativa de `pop()` ou `top()` com a pilha vazia.
* **EPilhaCheia:** Tentativa de `push()` em uma pilha sem espaço disponível (em implementações estáticas).

<br>

## 🛠️ Aplicações Práticas

* Navegação de páginas no **browser** (botão Voltar)
* Botão **Desfazer** em editores de texto
* Execução de **algoritmos recursivos**
* Avaliação de expressões matemáticas
* Parte integrante de **outras estruturas de dados**

<br>

## 🧱 Implementação Usando Array

> Utiliza-se um **vetor/array** como estrutura de armazenamento.

* Forma **simples** de implementação
* Elementos são adicionados sequencialmente
* Uso de uma **variável auxiliar** que armazena o índice do topo

<br>

### ⏱️ Complexidade das Operações

| Operação            | Complexidade | Descrição |
|---------------------|--------------|-----------|
| `push(object)`      | O(1)*        | Adiciona no topo (incrementa índice) |
| `object pop()`      | O(1)         | Remove do topo (decrementa índice)   |
| `object top()`      | O(1)         | Retorna o topo                       |
| `integer size()`    | O(1)         | Retorna a quantidade de elementos    |
| `boolean isEmpty()` | O(1)         | Verifica se está vazia               |

> *O(1) amortizado quando usando redimensionamento duplicativo

<br>

### ⚠️ Limitações das Pilhas Baseadas em Arrays

* **Capacidade Fixa:** Arrays possuem tamanho fixo, podendo causar **overflow**.
* **Espaço Desperdiçado:** Pode alocar mais memória do que o necessário.

> ⚠️ Para contornar esses problemas, utilizam-se estratégias de **redimensionamento dinâmico**.

<br>

### 🔃 Estratégias de Redimensionamento

Ao atingir a capacidade máxima, o array é substituído por um maior. Principais abordagens:

<br>

### 1. Estratégia Incremental

* ❓ **Como funciona?**
  * Aumenta a capacidade em um valor fixo `c` quando cheio.
  * Simples, mas ineficiente para grandes volumes.

* 📊 **Análise Matemática**
  * Número de redimensionamentos: `k = n / c`
  * Fator de crescimento: c (constante fixa)
  * Número de cópias após n inserções:
    ```math
    \text{Total cópias} = n + \sum_{k=1}^{n/c} (k \cdot c) = n + \frac{c \cdot (n/c)(n/c + 1)}{2}
    ```
  * Exemplo Prático (c = 10, n = 1000):
    ```math
    \text{Operações} = 1000 + (10 + 20 + 30 + ... + 100) = 1000 + 550 = 1550
    ```
  * Custo total:
    ```math
    T(n) = n + c \cdot \frac{(n/c)(n/c + 1)}{2} = O(n^2)
    ```
  * Tempo Amortizado:
    ```math
    \frac{T(n)}{n} = O(n)
    ```

* 📋 Resumo:

  * ✅ Simples implementação
  * ❌ Custo quadrático total
  * ❌ Ineficiente para muitos elementos

<br>

### 2. Estratégia Duplicativa (Exponencial)

* ❓ Como funciona?
  * Duplica a capacidade quando cheio.
  * Mais eficiente para crescimento rápido.

* 📊 Análise Matemática
  * Número de redimensionamentos: k = log₂(n)
  * Fator de crescimento: 2× (sempre dobra)
  * Número de cópias após n inserções:
    ```math
    \text{Total cópias} = n + \sum_{k=0}^{\lfloor \log_2 n \rfloor} 2^k \approx 3n
    ```
  * Exemplo Prático (n = 1000):
    ```math
    \text{Operações} ≈ 1000 + (1 + 2 + 4 + 8 + 16 + 32 + 64 + 128 + 256 + 512) ≈ 3000
    ```
  * Custo total:
    ```math
    T(n) \leq 3n - 1 = O(n)
    ```
  * Tempo Amortizado:
    ```math
    \frac{T(n)}{n} = O(1)]
    ```
* 📋 Resumo:

  * ✅ Custo linear total
  * ✅ Tempo amortizado constante
  * ✅ Ideal para cenários dinâmicos

<br>

### 📊 Comparativo de Estratégias

| Estratégia	| Custo Total	| Tempo Amortizado |	Adequação      |
|-------------|-------------|------------------|-----------------|
| Incremental	| O(n²)	      | O(n)	           | Casos simples   |
| Duplicativa	| O(n)	      | O(1)	           | Cenários gerais |

<br>

### ✏️ Implementação em C#

```csharp
using System;

// Exceção personalizada para pilha vazia
class PilhaVaziaExcecao : Exception
{
    public PilhaVaziaExcecao() : base("Operação inválida: pilha vazia!") {}
}

// Interface do TAD Pilha
interface IPilha<T>
{
    void Push(T elemento);  
    T Pop();                
    T Top();                
    int Size();             
    bool IsEmpty();
}

// Implementação com array
class PilhaArray<T> : IPilha<T>
{
    private T[] elementos;
    private int topo;
    private int capacidade;
    private readonly int fatorCrescimento;

    public PilhaArray(int capacidadeInicial = 10, int fatorCrescimento = 0)
    {
        this.capacidade = capacidadeInicial;
        this.topo = -1;
        this.fatorCrescimento = fatorCrescimento;
        this.elementos = new T[capacidadeInicial];
    }

    public void Push(T elemento)
    {
        if (topo == capacidade - 1)
        {
            Redimensionar();
        }
        elementos[++topo] = elemento;
    }

    public T Pop()
    {
        if (EstaVazia())
        {
            throw new PilhaVaziaExcecao();
        }
        return elementos[topo--];
    }

    public T Top()
    {
        if (EstaVazia())
        {
            throw new PilhaVaziaExcecao();
        }
        return elementos[topo];
    }

    public int Tamanho()
    {
        return topo + 1;
    }

    public bool EstaVazia()
    {
        return topo == -1;
    }

    // Método privado para redimensionamento
    private void Redimensionar()
    {
        int novaCapacidade = fatorCrescimento == 0 ? 
                            capacidade * 2 : 
                            capacidade + fatorCrescimento;

        T[] novoArray = new T[novaCapacidade];
        
        // Cópia dos elementos
        for (int i = 0; i <= topo; i++)
        {
            novoArray[i] = elementos[i];
        }

        elementos = novoArray;
        capacidade = novaCapacidade;
    }
}
```
