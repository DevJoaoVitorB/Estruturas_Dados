<h1 align="center">📚 TAD - Fila</h1>
<p align="center">🎯 <strong>Estrutura FIFO (First In, First Out)</strong></p>
<p align="center">⚠️ Elemento <strong>inserido primeiro</strong> é o <strong>primeiro a ser removido</strong>.</p>

## 🔧 Operações Principais

- `enqueue(object)` → Adiciona um elemento ao **fim** da fila.
- `object dequeue()` → Remove e retorna o elemento do **inicio** da pilha.


## 🧰 Operações Auxiliares

- `object first()` ou `object peek()` → Retorna o elemento do inicio **sem remover**.
- `integer size()` → Retorna o **número de elementos** na fila.
- `boolean isEmpty()` → Verifica se a fila está **vazia**.

<br>

## ⚠️ Exceções

- **EFilaVazia:** Tentativa de `dequeue()` ou `first()` com a fila vazia.
- **EFilaCheia:** Tentativa de `enqueue()` em uma fila sem espaço disponível.

<br>

## 🛠️ Exemplos Práticos

- Filas de espera
- Programação paralela
- Execução de multitarefas em ordens (**Downloads em Fila**)
- Filas de processos no sistema operacional

<br>

## 🧱 Implementação Usando Array (Filas baseadas em Arrays)

> Uma implementação de fila utilizando um **array fixo**, que pode ser otimizada com a técnica de **alocação circular**.

### 🔧 Estrutura Básica

- Utiliza-se um **array de tamanho fixo `N`**.
- A fila é controlada por **dois índices**:
  - `i` 👉 Índice do **início da fila** (onde os elementos são removidos).
  - `f` 👉 Índice **imediatamente após o fim da fila** (onde os elementos são inseridos).

<br>

### ⚙️ Modo de Funcionamento

#### 🧩 Configuração Padrão (Sem Circularidade)

- À medida que elementos são **removidos**, o índice `i` é incrementado.
- O índice `f` cresce com as **inserções**.
- **Problema:** Mesmo com espaço livre no início do array, ele **não é reutilizado**.
- **Resultado:** Pode parecer que a fila está cheia mesmo havendo espaço ― desperdício de memória.

<br>

#### 🔁 Configuração Circular (Otimizada)

- O array é tratado como um **anel fechado**.
- Quando `f` chega ao fim do array, ele **retorna ao início** (`f = 0`) e começa a preencher os espaços vazios deixados por `i`.
- A fila está **cheia** quando:
  ```text
  (f + 1) % N == i
  ```
- Isso garante que:
  - O array seja **plenamente utilizado**.
  - Não haja desperdício de espaço.
  - A fila continue funcionando de forma eficiente mesmo com remoções e inserções contínuas.

- **🔍 Visualização (Fila Circular)**

```text
Array:   [ - ][ B ][ C ][ D ][ - ][ - ]
Índices:   ↑                   ↑
         i = 1               f = 4
```

- **📖 Explicação**
  - Elementos `B`, `C`, `D` estão na fila. \
  - Após mais inserções, `f` pode voltar ao índice `0` para reutilizar a posição vazia.

<br>

### ⏱️ Desempenho das Operações

| Operação           | Complexidade | Descrição |
|--------------------|--------------|-----------|
| `enqueue(object)`  | O(1)         | Adiciona no final e incrementa -> `(f + 1) % N` |
| `object dequeue()` | O(1)         | Remove do inicio e incrementa -> `(i + 1) % N`  |
| `object first()`   | O(1)         | Retorna o primeiro elemento                     |
| `isEmpty()`        | O(1)         | Verifica se está vazia                          |
| `size()`           | O(1)         | Retorna a quantidade de elementos               |

<br>

### ⚠️ Limitações das Filas Baseadas em Arrays

- **Capacidade Fixa**: Arrays possuem capacidade fixa. Quando a fila atinge seu limite, operações como `enqueue(object)` se tornam inviáveis, gerando problemas de **overflow**.
- **Espaço Desperdiçado**: Em uma fila simples baseada em array linear (sem circularidade), quando você remove elementos do início com `dequeue()`, os espaços não são reutilizados automaticamente, gerando uma exceção de EFilaCheia com espaços disponivéis.

> ⚠️ Por isso, para garantir a eficiência e escalabilidade das filas, são implementadas estratégias de **redimensionamento dinâmico** e **configuração circular**.

<br>

### 🔃 Estratégias de Redimensionamento

Ao atingir a capacidade máxima, o array da fila é substituído por um novo array maior. As duas principais estratégias são: [**Estratégia Incremental**](pilha.md/#1-estratégia-incremental) e [**Estratégia Duplicativa (Exponencial)**](pilha.md/#2-estratégia-duplicativa-exponencial).

<br>

### ✏️ Implementação em C#
```csharp
using System;

class FilaVaziaException : Exception
{
     public FilaVaziaExcecao() : base("A Fila está vazia!") {}
     public FilaVaziaExcecao(string mensagem) : base(mensagem) {}
     public FilaVaziaExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}

interface Fila<T>
{
      void Enqueue(T objeto);
      T Dequeue();
      T First();
      bool IsEmpty();
      int Size();
}

class FilaArray<T> : Fila<T>
{
      
}
```

<br>
