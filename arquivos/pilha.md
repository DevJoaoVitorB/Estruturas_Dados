<h1 align="center">📚 TAD - Pilha</h1>
<p align="center">🎯 <strong>Estrutura LIFO (Last In, First Out)</strong></p>
<p align="center">⚠️ Elemento <strong>inserido por último</strong> é o <strong>primeiro a ser removido</strong>.</p>

## 🌍 Analogia do Mundo Real:
Imagine uma pilha de pratos em um restaurante:
- Você só pode adicionar novos pratos no **topo** da pilha (push)
- Você só pode remover pratos do **topo** (pop)
- Não pode pegar um prato do meio sem desmontar a pilha

<br>

## 🔧 Operações Principais

* `push(object)` → Adiciona um elemento ao **topo**.
  - **Comportamento**: Incrementa o topo e armazena o novo elemento
  - **Pré-condição**: Pilha não está cheia (a menos que seja redimensionável)
  - **Pós-condição**: Tamanho da pilha aumenta em 1

* `object pop()` → Remove e retorna o elemento do **topo** da pilha.
  - **Comportamento**: Retorna o elemento atual do topo e decrementa o topo
  - **Pré-condição**: Pilha não está vazia
  - **Pós-condição**: Tamanho da pilha diminui em 1

<br>

## 🧰 Operações Auxiliares

* `object top()` ou `object peek()` → Retorna o elemento do topo **sem remover**.
  - **Uso típico**: Quando você precisa inspecionar o topo sem modificar a pilha

* `integer size()` → Retorna o **número de elementos** na pilha.
  - **Importante**: Para verificar o estado atual da pilha

* `boolean isEmpty()` → Verifica se a pilha está **vazia**.
  - **Eficiência**: Operação O(1) crucial para evitar operações inválidas

<br>

## ⚠️ Exceções (Tratamento de Erros)

* **EPilhaVazia:** 
  - Ocorre quando tentamos `pop()` ou `top()` em uma pilha vazia
  - **Solução**: Sempre verificar `isEmpty()` antes dessas operações

* **EPilhaCheia:** 
  - Ocorre quando tentamos `push()` em uma pilha com capacidade fixa cheia
  - **Solução**: Implementar [redimensionamento dinâmico](#-estratégias-de-redimensionamento)

<br>

## 🛠️ Exemplos Práticos (Aplicações Reais)

1. **Navegador Web**: 
   - Pilha armazena histórico de páginas
   - Botão "Voltar" = `pop()`
   - Navegar para nova página = `push()`

2. **Editores de Texto**:
   - Funcionalidade "Desfazer" (Ctrl+Z)
   - Cada ação é empilhada
   - Desfazer = desempilhar a última ação

3. **Chamadas de Funções**:
   - Pilha de execução (call stack)
   - Cada chamada de função é um `push`
   - Retorno da função é um `pop`

4. **Algoritmos**:
   - Avaliação de expressões pós-fixadas
   - Busca em profundidade (DFS)
   - Conversão infixa para pós-fixa

<br>

## 🧱 Implementação Usando Array

### 🔧 Estrutura Básica
A implementação de pilha usando array consiste em:
- Um **array** para armazenar os elementos
- Um **inteiro** (topo) que indica a posição do último elemento
- **Capacidade inicial** definida no construtor
- **Fator de crescimento** para redimensionamento

    ```csharp
    private T[] elementos;  // Array de armazenamento
    private int topo = -1;  // Índice do topo (-1 = vazia)
    private int capacidade; // Capacidade total atual
    ```

<br>

### ⚙️ Modo de Funcionamento

#### 1. **Inicialização:**
* Array criado com capacidade inicial
* Topo começa em -1 (vazia)

#### 2. **Operações:**
* Push: Incrementa topo, armazena no índice
* Pop: Retorna elemento no topo, decrementa índice
* Quando cheia, redimensiona conforme estratégia escolhida

#### 3. **Controle:**
* `size()` = topo + 1
* `isEmpty()` = topo == -1

<br>

### ✅ Vantagens:
- **Simplicidade**: Fácil implementação e entendimento
- **Eficiência**: Todas as operações são O(1) (tempo constante)
- **Localidade de referência**: Bom aproveitamento de cache

<br>

### ❌ Desvantagens:
- **Tamanho fixo**: Necessidade de redimensionamento
- **Alocação contígua**: Pode ser problema em sistemas com memória limitada

<br>

### ⏱️ Desempenho das Operações

| Operação            | Complexidade | Explicação                                                                    |
|---------------------|--------------|-------------------------------------------------------------------------------|
| `push(object)`      | O(1)*        | Adiciona no topo (incrementa índice) - *O(n) apenas durante redimensionamento |
| `object pop()`      | O(1)         | Remove do topo (decrementa índice)                                            |
| `object top()`      | O(1)         | Retorna o topo                                                                |
| `integer size()`    | O(1)         | Retorna a quantidade de elementos                                             |
| `boolean isEmpty()` | O(1)         | Verifica se está vazia                                                        |

<br>

### 🔃 Estratégias de Redimensionamento

#### 1. **Incremental (Crescimento Linear)**

##### 📐 Explicação Matemática Simplificada
* A cada overflow, aumenta capacidade em c unidades
* Para n elementos: número de cópias = n/c
* Custo total: n + (c + 2c + 3c + ... + kc) ≈ O(n²/c)

##### ✅ Vantagens
* **Previsível:** Crescimento constante
* **Memória eficiente:** Aumenta apenas o necessário

##### ❌ Desvantagens
* **Baixo desempenho:** Custo quadrático para muitas inserções
* **Cópias frequentes:** A cada c elementos inseridos
    ```csharp
    // Exemplo com c = 10
    novaCapacidade = antigaCapacidade + 10;
    ```

<br>

#### 2. **Duplicativa (Crescimento Exponencial)**

##### 📐 Explicação Matemática Simplificada
* Dobra a capacidade a cada overflow
* Para n elementos: log₂(n) redimensionamentos
* Custo total: n + (1 + 2 + 4 + ... + n) ≈ 3n = O(n)

##### ✅ Vantagens
* **Alta performance:** Custo amortizado constante (O(1))
* **Menos cópias:** Redimensiona com menos frequência

##### ❌ Desvantagens
* **Subutilização:** Pode alocar mais memória que o necessário
* **Passo único:** Cada redimensionamento é mais custoso
    ```csharp
    // Exemplo de duplicação
    novaCapacidade = antigaCapacidade * 2;
    ```

<br>

#### 📊 Comparação Direta
| Critério         | Incremental       | Duplicativa      |
|------------------|-------------------|------------------|
| Custo Amortizado | O(n)	           | O(1)             |
| Memória	       | Mais eficiente	   | Menos eficiente  |
| Operações	       | 1 cópia a cada c  | 1 cópia a cada n |
| Ideal para	   | Baixo crescimento | Alto crescimento |

<br>

### ✏️ Implementação Completa em C#

```csharp
using System;

// Exceção personalizada para pilha vazia
class PilhaVaziaExcecao : Exception
{
    public PilhaVaziaExcecao() : base("Operação inválida: pilha vazia!") {}
    public PilhaVaziaExcecao(string mensagem) : base(mensagem) {}
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

// Implementação concreta usando array
class PilhaArray<T> : IPilha<T>
{
    private T[] elementos;      // Array para armazenamento
    private int topo;           // Índice do topo (-1 para vazia)
    private int capacidade;     // Capacidade total do array
    private readonly int fatorCrescimento;

    // Construtor
    public PilhaArray(int capacidadeInicial = 10, int fatorCrescimento = 0)
    {
        if (capacidadeInicial <= 0)
            throw new ArgumentException("Capacidade deve ser positiva", nameof(capacidadeInicial));
        
        elementos = new T[capacidadeInicial];
        topo = -1;
        capacidade = capacidadeInicial;
        this.fatorCrescimento = fatorCrescimento;
    }

    public int Size() => topo + 1;
    public bool IsEmpty() => topo == -1;

    public void Push(T elemento)
    {
        if (topo == capacidade - 1)
            Redimensionar();
        
        elementos[++topo] = elemento;
    }

    public T Pop()
    {
        if (IsEmpty())
            throw new PilhaVaziaExcecao();
        
        return elementos[topo--];
    }

    public T Top()
    {
        if (IsEmpty())
            throw new PilhaVaziaExcecao();
        
        return elementos[topo];
    }

    private void Redimensionar()
    {
        capacidade = fatorCrescimento == 0 
            ? capacidade * 2                  // Duplicação
            : capacidade + fatorCrescimento;  // Incremento
        
        T[] novoArray = new T[capacidade];
        
        // Copia os elementos para o novo array
        for (int i = 0; i <= topo; i++)
            novoArray[i] = elementos[i];
        
        elementos = novoArray;
    }
}
```
