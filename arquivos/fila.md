<h1 align="center">📚 TAD - Fila</h1>
<p align="center">🎯 <strong>Estrutura FIFO (First In, First Out)</strong></p>
<p align="center">⚠️ Elemento <strong>inserido primeiro</strong> é o <strong>primeiro a ser removido</strong>.</p>

## 🌍 Analogia do Mundo Real:
Imagine uma fila de banco:
- Novas pessoas chegam e se colocam no **final** da fila (enqueue)
- A pessoa atendida é sempre a **primeira** da fila (dequeue)
- Não é permitido furar a fila ou atender alguém do meio

<br>

## 🔧 Operações Principais

* `enqueue(object)` → Adiciona um elemento ao **final**.
  - **Comportamento**: Armazena no índice `fim` e atualiza ponteiro
  - **Pré-condição**: Fila não está cheia (a menos que seja redimensionável)
  - **Pós-condição**: Tamanho da fila aumenta em 1

* `object dequeue()` → Remove e retorna o elemento do **início** da fila.
  - **Comportamento**: Retorna o elemento em `inicio` e avança o ponteiro
  - **Pré-condição**: Fila não está vazia
  - **Pós-condição**: Tamanho da fila diminui em 1

<br>

## 🧰 Operações Auxiliares

* `object first()` → Retorna o elemento do início **sem remover**.
  - **Uso típico**: Verificar quem é o próximo a ser atendido

* `integer size()` → Retorna o **número de elementos** na fila.
  - **Cálculo**: `(capacidade - inicio + fim) % capacidade`

* `boolean isEmpty()` → Verifica se a fila está **vazia**.
  - **Critério**: `inicio == fim`

<br>

## ⚠️ Exceções (Tratamento de Erros)

* **EFilaVazia:** 
  - Ocorre quando tentamos `dequeue()` ou `first()` em uma fila vazia
  - **Solução**: Sempre verificar `isEmpty()` antes dessas operações

* **EFilaCheia:** 
  - Ocorre em filas estáticas quando tentamos `enqueue()` na capacidade máxima
  - **Solução**: Implementar [redimensionamento dinâmico](pilha.md/#-estratégias-de-redimensionamento)

<br>

## 🛠️ Exemplos Práticos (Aplicações Reais)

1. **Sistemas Operacionais**: 
   - Escalonamento de processos
   - Buffer de teclado

2. **Serviços Online**:
   - Filas de mensagens (RabbitMQ, Kafka)
   - Sistemas de ticket de suporte

3. **Simulações**:
   - Filas de supermercado
   - Tráfego em semáforos

4. **Algoritmos**:
   - Busca em largura (BFS)
   - Cache FIFO

<br>

## 🧱 Implementação Usando Array Circular

### 🔧 Estrutura Básica

A implementação de fila usando array consiste em:
- Um **array** para armazenar os elementos
- Dois **ponteiros**:
  - `inicio`: índice do primeiro elemento
  - `fim`: índice após o último elemento
- **Capacidade máxima** do array

    ```csharp
    private T[] elementos;  // Array de armazenamento
    private int inicio;     // Índice do primeiro elemento (0 inicialmente)
    private int fim;        // Índice após o último elemento (0 inicialmente)
    private int capacidade; // Capacidade total do array
    ```

### ⚙️ Modo de Funcionamento

#### 🧩 Configuração Linear (Não Circular)

* **`Enqueue()`:**
    * O índice f (fim) avança conforme novos elementos são adicionados.
* **`Dequeue()`:**
    * O índice i (início) avança quando elementos são removidos.
* ❌ **Desvantagens:**
    * Espaços liberados no início do array não são reutilizados.
    * Mesmo com áreas vazias, a fila pode atingir o limite máximo sem usar toda a capacidade disponível → desperdício de memória.
* 🖼️ **Exemplo Visual:**
    ```text
    Array:   [ - ][ - ][ B ][ C ][ D ][ E ]  
    Índices:           ↑i=2           ↑f=5      
    ```

<br>

#### 🔁 Configuração Circular (Otimizada)

* **Array como Anel Contínuo:**
    * Quando fim alcança o final do array, ele reinicia na posição 0, aproveitando os espaços livres deixados por remoções.
* **Fórmulas críticas:**
    * Cheio: (fim + 1) % capacidade == inicio - Sempre deixe 1 posição vazia para distinguir cheio/vazio
    * Vazio: inicio == fim
    * Tamanho: (fim - inicio + capacidade) % capacidade
* ✅ **Vantagens:**
    * Reutilização de espaços liberados.
    * Uso otimizado da memória (sem "buracos" vazios).
    * Operações O(1) mesmo com inserções/remoções sucessivas.
* 🖼️ **Exemplo Visual:**
    ```text
    Array:   [ F ][ - ][ B ][ C ][ D ][ E ]  
    Índices: ↑f=0      ↑i=2      
    ```

<br>

### ⏱️ Desempenho das Operações

| Operação            | Complexidade | Descrição                                                  |
|---------------------|--------------|------------------------------------------------------------|
| `enqueue(object)`   | O(1)*        | Adiciona no final - *O(n) apenas durante redimensionamento |
| `object dequeue()`  | O(1)         | Remove do inicio                                           |
| `object first()`    | O(1)         | Retorna o primeiro elemento                                |
| `integer size()`    | O(1)         | Retorna a quantidade de elementos                          |
| `boolean isEmpty()` | O(1)         | Verifica se está vazia                                     |

<br>

### ✏️ Implementação Completa em C#

```csharp
using System;

// Exceção personalizada para fila vazia
public class FilaVaziaException : Exception {
    public FilaVaziaException() : base("Operação inválida: fila vazia!") {}
    public FilaVaziaException(string mensagem) : base(mensagem) {}
}

// Interface do TAD Fila
public interface IFila<T> {
    void Enqueue(T elemento);
    T Dequeue();
    T First();
    int Size();
    bool IsEmpty();
}

// Implementação concreta usando array circular
public class FilaArrayCircular<T> : IFila<T> {
    private T[] elementos;
    private int inicio;
    private int fim;
    private int capacidade;

    // Construtor
    public FilaArrayCircular(int capacidadeInicial = 10) {
        capacidade = capacidadeInicial;
        elementos = new T[capacidade];
        inicio = fim = 0;
    }

    public int Size() => (fim - inicio + capacidade) % capacidade;
    public bool IsEmpty() => inicio == fim;

    public void Enqueue(T elemento) {
        if ((fim + 1) % capacidade == capacidade)
            Redimensionar();
        
        elementos[fim] = elemento;
        fim = (fim + 1) % capacidade;
    }

    public T Dequeue() {
        if (IsEmpty())
            throw new FilaVaziaException();
        
        T elemento = elementos[inicio];
        inicio = (inicio + 1) % capacidade;
        
        return elemento;
    }

    public T First() {
        if (IsEmpty())
            throw new FilaVaziaException();
        
        return elementos[inicio];
    }

    private void Redimensionar() {

        int novaCapacidade = capacidade * 2;

        T[] novoArray = new T[novaCapacidade];
        
        // Copia os elementos para o novo array
        for (int i = 0; i < contador; i++) {
            int indiceOriginal = (inicio + i) % capacidade;
            novoArray[i] = elementos[indiceOriginal];
        }
        
        elementos = novoArray;
        fim = Size();
        inicio = 0;
        capacidade = novaCapacidade;
    }
}
