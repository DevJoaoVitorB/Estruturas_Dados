<h1 align="center">📚 TAD - Deque</h1>
<p align="center">🎯 <strong>Estrutura Linear Duplamente Acessível</strong></p>
<p align="center">⚠️ Permite inserções e remoções em <strong>ambas as extremidades</strong>.</p>

## 🌍 Analogia do Mundo Real:
Imagine um elevador de dois lados:
- Pessoas podem entrar tanto pela **porta frontal** quanto pela **traseira**
- Quem entra primeiro por uma porta será o primeiro a sair por ela
- É possível gerenciar o fluxo pelas duas extremidades independentemente

<br>

## 🔧 Operações Principais

* `addFirst(object)` → Adiciona um elemento no **início**.
  - **Comportamento**: Insere no índice `inicio-1` (com ajuste circular)
  - **Pré-condição**: Deque não está cheio
  - **Pós-condição**: Tamanho aumenta em 1

* `addLast(object)` → Adiciona um elemento no **final**.
  - **Comportamento**: Insere no índice `fim` e avança ponteiro
  - **Pré-condição**: Deque não está cheio
  - **Pós-condição**: Tamanho aumenta em 1

* `object removeFirst()` → Remove e retorna o elemento do **início**.
  - **Comportamento**: Retorna elemento em `inicio` e avança ponteiro
  - **Pré-condição**: Deque não está vazio
  - **Pós-condição**: Tamanho diminui em 1

* `object removeLast()` → Remove e retorna o elemento do **final**.
  - **Comportamento**: Retorna elemento em `fim-1` e recua ponteiro
  - **Pré-condição**: Deque não está vazio
  - **Pós-condição**: Tamanho diminui em 1

<br>

## 🧰 Operações Auxiliares

* `object first()` → Retorna o primeiro elemento **sem remover**.
  - **Uso típico**: Verificar o elemento mais antigo

* `object last()` → Retorna o último elemento **sem remover**.
  - **Uso típico**: Verificar o elemento mais recente

* `integer size()` → Retorna o **número de elementos** no deque.
  - **Cálculo**: `(capacidade - inicio + fim) % capacidade`

* `boolean isEmpty()` → Verifica se o deque está **vazio**.
  - **Critério**: `inicio == fim`

<br>

## ⚠️ Exceções (Tratamento de Erros)

* **EDequeVazio:** 
  - Ocorre quando tentamos `removeFirst()`, `removeLast()`, `first()` ou `last()` em deque vazio
  - **Solução**: Sempre verificar `isEmpty()` antes dessas operações

* **EDequeCheio:** 
  - Ocorre em deques estáticos quando tentamos `addFirst()` ou `addLast()` na capacidade máxima
  - **Solução**: Implementar redimensionamento dinâmico

<br>

## 🛠️ Exemplos Práticos (Aplicações Reais)

1. **Sistemas de Navegação**:
   - Histórico de páginas web (avanço/voltar)
   - Navegação em apresentações de slides

2. **Algoritmos Especiais**:
   - Verificação de palíndromos
   - Busca em largura (BFS) com priorização

3. **Controle de Processos**:
   - Escalonamento com tarefas prioritárias
   - Buffer de impressão duplex

4. **Estruturas Híbridas**:
   - Pilha e fila simultâneas
   - Filas com prioridade nas extremidades

<br>

## 🧱 Implementação Usando Array Circular

### 🔧 Estrutura Básica

A implementação de deque usando array consiste em:
- Um **array** para armazenar os elementos
- Dois **ponteiros**:
  - `inicio`: índice do primeiro elemento
  - `fim`: índice após o último elemento
- **Capacidade máxima** do array

    ```csharp
    private T[] elementos;  // Array de armazenamento
    private int inicio;     // Índice do primeiro elemento
    private int fim;        // Índice após o último elemento
    private int capacidade; // Capacidade total do array
    ```

<br>

### ⚙️ Modo de Funcionamento

#### 🔄 Configuração Circular
* [Uso do Array Circular](fila.md/#️-modo-de-funcionamento)
* Inserção no início: inicio decrementa (com wrap-around) (**inicio = (inicio - 1 + capacidade) % capacidade**)
* Inserção no final: fim incrementa (com wrap-around) (**fim = (fim + 1) % capacidade**)
* Remoção no início: inicio incrementa (**inicio = (inicio + 1) % capacidade**)
* Remoção no final: fim decrementa (**fim = (fim - 1 + capacidade) % capacidade**)

<br>

### ⏱️ Desempenho das Operações

| Operação              | Complexidade | Descrição                                          |
|-----------------------|--------------|----------------------------------------------------|
| `addFirst(object)`    | O(1)*        | Insere no início - *O(n) durante redimensionamento |
| `addLast(object)`     | O(1)*        | Insere no final - *O(n) durante redimensionamento  |
| `object removeFirst()`| O(1)         | Remove do início                                   |
| `object removeLast()` | O(1)         | Remove do final                                    |
| `object first()`      | O(1)         | Acessa início sem remover                          |
| `object last()`       | O(1)         | Acessa final sem remover                           |
| `integer size()`      | O(1)         | Retorna a quantidade de elementos                  |
| `boolean isEmpty()`   | O(1)         | Verifica se está vazio                             |

<br>

### ✏️ Implementação Completa em C#

```csharp
using System;

public class DequeVazioException : Exception {
    public DequeVazioException() : base("Operação inválida: deque vazio!") {}
    public DequeVazioException(string mensagem) : base(mensagem) {}
}

// Interface do TAD Deque
public interface IDeque<T> {
    void AddFirst(T elemento);
    void AddLast(T elemento);
    T RemoveFirst();
    T RemoveLast();
    T First();
    T Last();
    int Size();
    bool IsEmpty();
}

// Implementação concreta usando array circular
public class Deque<T> : IDeque<T> {
    private T[] elementos;
    private int inicio;
    private int fim;
    private int capacidade;

    public Deque(int capacidadeInicial = 10) {
        elementos = new T[capacidade];
        inicio = fim = 0;
        capacidade = capacidadeInicial;
    }

    public int Size() => (fim - inicio + capacidade) % capacidade;
    public bool IsEmpty() => inicio == fim;

    public void AddFirst(T elemento) {
        if (Size() == capacidade - 1)
            Redimensionar();
        
        inicio = (inicio - 1 + capacidade) % capacidade;
        elementos[inicio] = elemento;
    }

    public void AddLast(T elemento) {
        if (Size() == capacidade - 1)
            Redimensionar();
        
        elementos[fim] = elemento;
        fim = (fim + 1) % capacidade;
    }

    public T RemoveFirst() {
        if (IsEmpty())
            throw new DequeVazioException();
        
        T elemento = elementos[inicio];
        inicio = (inicio + 1) % capacidade;
        return elemento;
    }

    public T RemoveLast() {
        if (IsEmpty())
            throw new DequeVazioException();
        
        fim = (fim - 1 + capacidade) % capacidade;
        T elemento = elementos[fim];
        return elemento;
    }

    public T First() {
        if (IsEmpty())
            throw new DequeVazioException();
        
        return elementos[inicio];
    }

    public T Last() {
        if (IsEmpty())
            throw new DequeVazioException();
        
        return elementos[(fim - 1 + capacidade) % capacidade];
    }

    private void Redimensionar() {
        int novaCapacidade = capacidade * 2;
        T[] novoArray = new T[novaCapacidade];
        int tamanhoAtual = Size();
        
        for (int i = 0; i < tamanhoAtual; i++) {
            int indiceOriginal = (inicio + i) % capacidade;
            novoArray[i] = elementos[indiceOriginal];
        }
        
        elementos = novoArray;
        capacidade = novaCapacidade;
        inicio = 0;
        fim = tamanhoAtual;
    }
}
```
