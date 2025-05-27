<h1 align="center">🔢 TAD - Sequência</h1>
<p align="center">🎯 <strong>Estrutura Sequencial com Suporte a Acesso por Rank e Posicional</strong></p>
<p align="center">⚠️ Permite operações tanto por <strong>índice</strong> (rank) quanto por <strong>posição</strong> (ponteiro para elemento).</p>

## 🔧 Operações Genéricas

* `integer size()` → Retorna o **número de elementos** na sequência.
* `boolean isEmpty()` → Verifica se a sequência está **vazia**.

## 🗂️ Operações de Vetor (Baseadas em Rank)

* `insertAtRank(integer, object)` → **Insere** o elemento `X` na posição `R`, deslocando os demais.
* `object removeAtRank(integer)` → **Remove** o elemento da posição `R`, ajustando as demais posições.
* `object replaceAtRank(integer, object)` → **Substitui** o elemento na posição `R` por `X`.
* `object elemAtRank(integer)` → Retorna o **elemento na posição** `R`.

## 📋 Operações de Lista (Baseadas em Posicional)

- `insertFirst(object)` → Insere um elemento no **início**.
- `insertLast(object)` → Insere um elemento no **final**.
- `insertAfter(object, object)` → Insere elemento **depois** de outro elemento.
- `insertBefore(object, object)` → Insere um elemento **antes** de outro elemento.
- `object replaceElement(object, object)` → Substitui um **elemento antigo** por um **elemento novo**.
- `swapElement(object, object)` → Troca de posição de um elemento com outro elemento.
- `object remove(object)` → Remove e retorna um elemento.
- `object first()` → Retorna o **primeiro elemento**.
- `object last()` → Retorna o **último elemento**.
- `boolean inFirst(object)` → Verifica se o elemento está na **primeira posição**.
- `boolean inLast(object)` → Verifica se o elemento está na **última posição**.
- `object after(object)` → Retorna um elemento **posterior** a outro elemento.
- `object before(object)` → Retorna um elemento **anterior** a outro elemento.
- `object search(object)` → Retorna o **elemento** se ele existir.

## 🔀 Operações Ponte (Rank ⇄ Positional)

* `object atRank(integer)` → Retorna o **elemento** correspondente a posição `R`.
* `integer rankOf(object)` → Retorna a **posição (index)** correspondente ao elemento.

<br>

## ⚠️ Exceções

* **ERankInvalido**: Posição fora dos limites da sequência.
* **ENaoEncontrado:** Elemento não encontrado durante o `search()`.
* **ESequenciaVazia**: Tentativa de acessar/remover elemento de uma sequência **vazia**.
* **ESequenciaCheia**: Tentativa de inserir em sequência **cheia**.

<br>

## 🛠️ Exemplos Práticos

* Manipulação de documentos (texto, listas, histórico)
* Modelagem de editores com cursor (lista posicional)
* Acesso rápido por índice e operações locais com ponteiros
* Navegação em menus, playlists e comandos
* Pequenos Bancos de dados (e.g., Agenda de endereços)

<br>

## 🧱 Implementação com Array Circular

> A sequência é representada com um **array circular** contendo **nós como objetos**. Cada nó possui:
>
> * O **valor** armazenado
> * O **rank (posição lógica)** em que se encontra (diferente do índice do array)

### 🔧 Estrutura Básica

* 🔹 Cada elemento do array é um objeto Nó, que armazena o valor e seu rank lógico na estrutura.
* 🔹 O array é circular: quando se alcança o final, volta-se ao início.
* 🔹 O rank não é o mesmo que o índice do array - é a posição lógica baseada na ordem de inserção.
* 🔹 Ao remover um elemento do meio, os ranks são reajustados para manter a sequência lógica.
* 🔹 Operações de leitura são rápidas, mas inserções e remoções internas são custosas por envolver deslocamento de elementos.

```text
Array Circular: 
[ Nó(30, rank=2) ] [ -- ][ -- ][ Nó(10, rank=0) ] [ Nó(20, rank=1) ]
Tamanho: 3
Capacidade: 5
```

<br>

### ⚙️ Modo de Funcionamento

* Todas as operações (genéricas, de vetor, de lista e de ponte) são suportadas.
* Acesso direto por rank é eficiente (O(1)) usando busca modular no array circular.
* Inserções e remoções envolvem deslocamento de elementos (O(n)) e ajuste de ranks.
* Ao remover um elemento do meio:
    * Os elementos posteriores são deslocados para esquerda
    * Seus ranks são decrementados em 1
* Nós armazenam o rank lógico, facilitando a conversão entre rank e posição.

<br>

### ⚠️ Limitações

* **Capacidade fixa:** Arrays possuem capacidade fixa. Quando a sequência atinge seu limite, operações de inserção se tornam inviáveis, gerando problemas de **overflow**. Fazendo necessário estrategias de redimensionamento como: 
    1. [**Estratégia Incremental**](pilha.md/###1-estratégia-incremental)
    2. [**Estratégia Duplicativa (Exponencial)**](pilha.md/###2-estratégia-duplicativa-exponencial)
* Deslocamentos custosos em operações de inserção/remoção em posições intermediárias.
* Maior complexidade para manipular posições relativas (before/after).

<br>

### ✏️ Implementação em C#
```csharp
using system;

public class EPosicaoInvalida : Exception {
    public EPosicaoInvalida(string msg) : base(msg) { }
}

public class ENaoEncontrado : Exception {
    public ENaoEncontrado(string msg) : base(msg) { }
}

public class ESequenciaVazia : Exception {
    public ESequenciaVazia(string msg) : base(msg) { }
}

public interface ISequencia<T> {
    int Size();
    bool IsEmpty();

    void InsertAtRank(int rank, T element);
    T RemoveAtRank(int rank);
    T ReplaceAtRank(int rank, T element);
    T ElemAtRank(int rank);

    void InsertFirst(T element);
    void InsertLast(T element);
    void InsertAfter(T target, T element);
    void InsertBefore(T target, T element);
    T ReplaceElement(T oldElement, T newElement);
    void SwapElement(T e1, T e2);
    T Remove(T element);
    T First();
    T Last();
    bool InFirst(T element);
    bool InLast(T element);
    T After(T element);
    T Before(T element);
    T Search(T element);

    No<T> AtRank(int rank);
    int RankOf(No<T> node);
}

public class No<T> {
    public T Element { get; set; }
    public int Rank { get; set; }

    public No(T element, int rank) {
        Element = element;
        Rank = rank;
    }
}

public class SequenciaArray<T> : ISequencia<T> {
    private No<T>[] array;
    private int capacidade;
    private int inicio;
    private int tamanho;

    public SequenciaArray(int capacidadeInicial = 10) {
        capacidade = capacidadeInicial;
        array = new No<T>[capacidade];
        inicio = 0;
        tamanho = 0;
    }

    public int Size() => tamanho;
    public bool IsEmpty() => tamanho == 0;
    private int Index(int r) => (inicio + r) % capacidade;

    private void Redimensionar() {
        int novaCapacidade = capacidade * 2;
        No<T>[] novoArray = new No<T>[novaCapacidade];
        for (int i = 0; i < tamanho; i++)
            novoArray[i] = array[Index(i)];
        array = novoArray;
        capacidade = novaCapacidade;
        inicio = 0;
    }

    public No<T> AtRank(int rank) {
        if (rank < 0 || rank >= tamanho)
            throw new EPosicaoInvalida("Rank inválido.");
        return array[Index(rank)];
    }

    public int RankOf(No<T> no) {
        for (int i = 0; i < tamanho; i++) {
            if (array[Index(i)].Equals(no)) return i;
        }
        throw new ENaoEncontrado("Elemento não encontrado.");
    }

    public void InsertAtRank(int rank, T element) {
        if (rank < 0 || rank > tamanho)
            throw new EPosicaoInvalida("Rank inválido.");
        if (tamanho == capacidade) Redimensionar();
        for (int i = tamanho; i > rank; i--) {
            array[Index(i)] = array[Index(i - 1)];
        }
        array[Index(rank)] = new No<T>(element, rank);
        tamanho++;
    }

    public T RemoveAtRank(int rank) {
        if (IsEmpty()) throw new ESequenciaVazia("Sequência vazia.");
        if (rank < 0 || rank >= tamanho)
            throw new EPosicaoInvalida("Rank inválido.");
        T elemento = array[Index(rank)].Element;
        for (int i = rank; i < tamanho - 1; i++) {
            array[Index(i)] = array[Index(i + 1)];
        }
        array[Index(tamanho - 1)] = null;
        tamanho--;
        return elemento;
    }

    public T ReplaceAtRank(int rank, T element) {
        if (rank < 0 || rank >= tamanho)
            throw new EPosicaoInvalida("Rank inválido.");
        T antigo = array[Index(rank)].Element;
        array[Index(rank)].Element = element;
        return antigo;
    }

    public T ElemAtRank(int rank) {
        return AtRank(rank).Element;
    }

    public void InsertFirst(T element) => InsertAtRank(0, element);
    public void InsertLast(T element) => InsertAtRank(tamanho, element);

    public void InsertAfter(T target, T element) {
        int pos = IndexOf(target);
        InsertAtRank(pos + 1, element);
    }

    public void InsertBefore(T target, T element) {
        int pos = IndexOf(target);
        InsertAtRank(pos, element);
    }

    public T ReplaceElement(T oldElement, T newElement) {
        int pos = IndexOf(oldElement);
        T antigo = array[Index(pos)].Element;
        array[Index(pos)].Element = newElement;
        return antigo;
    }

    public void SwapElement(T e1, T e2) {
        int i1 = IndexOf(e1);
        int i2 = IndexOf(e2);
        var temp = array[Index(i1)].Element;
        array[Index(i1)].Element = array[Index(i2)].Element;
        array[Index(i2)].Element = temp;
    }

    public T Remove(T element) {
        int pos = IndexOf(element);
        return RemoveAtRank(pos);
    }

    public T First() {
        if (IsEmpty()) throw new ESequenciaVazia("Sequência vazia.");
        return array[Index(0)].Element;
    }

    public T Last() {
        if (IsEmpty()) throw new ESequenciaVazia("Sequência vazia.");
        return array[Index(tamanho - 1)].Element;
    }

    public bool InFirst(T element) => IndexOf(element) == 0;
    public bool InLast(T element) => IndexOf(element) == tamanho - 1;

    public T After(T element) {
        int pos = IndexOf(element);
        if (pos == tamanho - 1)
            throw new EPosicaoInvalida("Último elemento não possui sucessor.");
        return array[Index(pos + 1)].Element;
    }

    public T Before(T element) {
        int pos = IndexOf(element);
        if (pos == 0)
            throw new EPosicaoInvalida("Primeiro elemento não possui anterior.");
        return array[Index(pos - 1)].Element;
    }

    public T Search(T element) {
        for (int i = 0; i < tamanho; i++) {
            if (array[Index(i)].Element.Equals(element)) {
                return array[Index(i)].Element;
            }
        }
        throw new ENaoEncontrado("Elemento não encontrado.");
    }

    private int IndexOf(T element) {
        for (int i = 0; i < tamanho; i++) {
            if (array[Index(i)].Element.Equals(element)) return i;
        }
        throw new ENaoEncontrado("Elemento não encontrado.");
    }
}
```

<br>

## 🔁 Implementação com Lista Duplamente Ligada

> A sequência é implementada como uma **lista duplamente ligada**, com **nós contendo**:
>
> * O **valor** armazenado (objeto)
> * O **rank** (posição) do nó na sequência
> * Ponteiro para o **nó anterior (prev)**
> * Ponteiro para o **nó seguinte (next)**

### 🔧 Estrutura Básica

  * 🔹 Cada nó armazena o valor, seu rank, além de ponteiros para o nó anterior e o seguinte.
  * 🔹 O primeiro e o último nós (head e tail) são fixos e ajudam a simplificar inserções e remoções nos extremos.
  * 🔹 Graças aos ponteiros, é possível navegar para frente e para trás com eficiência (`before()` e `after()`).
  * 🔹 Exige varredura da lista até alcançar o índice desejado, já que não há indexação direta.
  * 🔹 Inserções e remoções em qualquer ponto são feitas rapidamente com atualização de ponteiros.
  * 🔹 Ao remover um nó do meio da sequência, os ranks dos nós seguintes são decrementados em 1.

```text
[Sentinela Head] ⇄ [ Nó(10, rank=0) ] ⇄ [ Nó(20, rank=1) ] ⇄ [ Nó(30, rank=2) ] ⇄ [Sentinela Tail]
```

<br>

### ⚙️ Modo de Funcionamento

* Suporte completo a todas as operações do TAD Sequência.
* Navegação eficiente com ponteiros (`before()`, `after()`, `insertBefore()`, etc.).
* Conversão entre posição e rank com `atRank()` e `rankOf()`.
* Inserções e remoções em O(1) com ponteiros apropriados.
* Atualização automática de ranks ao remover nós do meio da sequência.

<br>

### ⚠️ Limitações

* Acesso por rank é O(n) (necessário percorrer da cabeça até o rank desejado).
* Maior uso de memória devido aos ponteiros adicionais por nó.
* Implementação mais complexa devido à manutenção das referências e ranks.
* Necessidade de atualizar ranks após operações de remoção no meio da lista.

<br>

### ✏️ Implementação em C#
```csharp
using System;

// Exceções personalizadas
public class EPosicaoInvalida : Exception {
    public EPosicaoInvalida(string msg) : base(msg) { }
}

public class ENaoEncontrado : Exception {
    public ENaoEncontrado(string msg) : base(msg) { }
}

public class ESequenciaVazia : Exception {
    public ESequenciaVazia(string msg) : base(msg) { }
}

// Interface do TAD Sequência
public interface ISequencia<T> {
    int Size();
    bool IsEmpty();

    void InsertAtRank(int rank, T element);
    T RemoveAtRank(int rank);
    T ReplaceAtRank(int rank, T element);
    T ElemAtRank(int rank);

    void InsertFirst(T element);
    void InsertLast(T element);
    void InsertAfter(No<T> node, T element);
    void InsertBefore(No<T> node, T element);
    T ReplaceElement(No<T> node, T element);
    void SwapElement(No<T> n1, No<T> n2);
    T Remove(No<T> node);
    T First();
    T Last();
    bool InFirst(No<T> node);
    bool InLast(No<T> node);
    No<T> After(No<T> node);
    No<T> Before(No<T> node);
    No<T> Search(T element);

    No<T> AtRank(int rank);
    int RankOf(No<T> node);
}

// Nó da lista duplamente ligada
public class No<T> {
    public T Element { get; set; }
    public No<T> Prev { get; set; }
    public No<T> Next { get; set; }

    public No(T element, No<T> prev = null, No<T> next = null) {
        Element = element;
        Prev = prev;
        Next = next;
    }
}

// Implementação com Lista Duplamente Ligada
public class SequenciaLista<T> : ISequencia<T> {
    private No<T> header; // Sentinela inicial
    private No<T> trailer; // Sentinela final
    private int size;

    public SequenciaLista() {
        header = new No<T>(default); // Nó fictício de início
        trailer = new No<T>(default); // Nó fictício de fim
        header.Next = trailer;
        trailer.Prev = header;
        size = 0;
    }

    public int Size() => size;
    public bool IsEmpty() => size == 0;

    // Insere elemento entre dois nós
    private No<T> InsertBetween(T element, No<T> prev, No<T> next) {
        No<T> novo = new No<T>(element, prev, next);
        prev.Next = novo;
        next.Prev = novo;
        size++;
        return novo;
    }

    // Remove um nó da sequência
    private T RemoveNode(No<T> node) {
        No<T> prev = node.Prev;
        No<T> next = node.Next;
        prev.Next = next;
        next.Prev = prev;
        size--;
        return node.Element;
    }

    // Retorna o nó de posição lógica (rank)
    public No<T> AtRank(int rank) {
        if (rank < 0 || rank >= size)
            throw new EPosicaoInvalida("Rank inválido.");

        No<T> node;

        // Otimização: anda pela esquerda ou pela direita
        if (rank <= size / 2) {
            node = header.Next;
            for (int i = 0; i < rank; i++)
                node = node.Next;
        } else {
            node = trailer.Prev;
            for (int i = size - 1; i > rank; i--)
                node = node.Prev;
        }
        return node;
    }

    // Retorna o rank de um nó
    public int RankOf(No<T> no) {
        No<T> n = header.Next;
        int r = 0;
        while (n != trailer) {
            if (n == no) return r;
            n = n.Next;
            r++;
        }
        throw new ENaoEncontrado("Nó não está na sequência.");
    }

    public void InsertAtRank(int rank, T element) {
        if (rank < 0 || rank > size)
            throw new EPosicaoInvalida("Rank inválido.");
        No<T> refNode = (rank == size) ? trailer : AtRank(rank);
        InsertBefore(refNode, element);
    }

    public T RemoveAtRank(int rank) {
        if (IsEmpty()) throw new ESequenciaVazia("Sequência vazia.");
        return Remove(AtRank(rank));
    }

    public T ReplaceAtRank(int rank, T element) {
       
    }

    public T ElemAtRank(int rank) => AtRank(rank).Element;

    public void InsertFirst(T element) => InsertBetween(element, header, header.Next);

    public void InsertLast(T element) => InsertBetween(element, trailer.Prev, trailer);

    public void InsertAfter(No<T> node, T element) => InsertBetween(element, node, node.Next);

    public void InsertBefore(No<T> node, T element) => InsertBetween(element, node.Prev, node);

    public T ReplaceElement(No<T> node, T element) {
        if (node == header || node == trailer)
            throw new EPosicaoInvalida("Não é possível substituir sentinelas.");

        T antigo = node.Element;

        // Cria novo nó e conecta nos mesmos vizinhos
        No<T> novo = new No<T>(element, node.Prev, node.Next);
        node.Prev.Next = novo;
        node.Next.Prev = novo;

        // Desconecta o nó antigo
        node.Prev = null;
        node.Next = null;

        return antigo;
    }


    public void SwapElement(No<T> n1, No<T> n2) {
        if (n1 == header || n1 == trailer || n2 == header || n2 == trailer)
            throw new EPosicaoInvalida("Não é possível trocar sentinelas.");

        if (n1 == n2) return;

        // Vizinhos de n1 e n2
        No<T> p1 = n1.Prev, n1n = n1.Next;
        No<T> p2 = n2.Prev, n2n = n2.Next;

        // Se os nós forem adjacentes, tratamos diferente
        if (n1.Next == n2) {
            // n1 está antes de n2
            p1.Next = n2;
            n2.Prev = p1;
            n2.Next = n1;
            n1.Prev = n2;
            n1.Next = n2n;
            n2n.Prev = n1;
        } else if (n2.Next == n1) {
            // n2 está antes de n1
            p2.Next = n1;
            n1.Prev = p2;
            n1.Next = n2;
            n2.Prev = n1;
            n2.Next = n1n;
            n1n.Prev = n2;
        } else {
            // Caso geral: nós distantes
            p1.Next = n2;
            n2.Prev = p1;
            n2.Next = n1n;
            n1n.Prev = n2;

            p2.Next = n1;
            n1.Prev = p2;
            n1.Next = n2n;
            n2n.Prev = n1;
        }
    }

    public T Remove(No<T> node) {
        if (node == header || node == trailer)
            throw new EPosicaoInvalida("Não é possível remover sentinelas.");
        return RemoveNode(node);
    }

    public T First() {
        if (IsEmpty()) throw new ESequenciaVazia("Sequência vazia.");
        return header.Next.Element;
    }

    public T Last() {
        if (IsEmpty()) throw new ESequenciaVazia("Sequência vazia.");
        return trailer.Prev.Element;
    }

    public bool InFirst(No<T> node) => node == header.Next;

    public bool InLast(No<T> node) => node == trailer.Prev;

    public No<T> After(No<T> node) {
        if (node.Next == trailer)
            throw new EPosicaoInvalida("Último elemento não tem sucessor.");
        return node.Next;
    }

    public No<T> Before(No<T> node) {
        if (node.Prev == header)
            throw new EPosicaoInvalida("Primeiro elemento não tem anterior.");
        return node.Prev;
    }

    public No<T> Search(T element) {
        No<T> node = header.Next;
        while (node != trailer) {
            if (node.Element.Equals(element)) return node;
            node = node.Next;
        }
        throw new ENaoEncontrado("Elemento não encontrado.");
    }
}
```

<br>

## ⏱️ Desempenho das Operações

| Operação                                | Array com Nós | Lista Duplamente Ligada | Descrição                                                                     |
| --------------------------------------- | ------------- | ----------------------- | ----------------------------------------------------------------------------- |
| `insertAtRank(integer, object)`         | O(n)          | O(n)                    | Insere o **elemento** na **posição X** da sequência e desloca os demais       |
| `insertFirst(object)`                   | O(n)          | O(1)                    | Insere o **elemento** no **início** da sequência                              |
| `insertLast(object)`                    | O(n)          | O(1)                    | Insere o **elemento** no **fim** da sequência                                 |
| `insertAfter(object, object)`           | O(n)          | O(1)                    | Insere o **elemento depois** de outro elemento da sequência                   |
| `insertBefore(object, object)`          | O(n)          | O(1)                    | Insere o **elemento antes** de outro elemento da sequeência                   |
| `object replaceAtRank(integer, object)` | O(1)          | O(n)                    | Substitui o **elemento** na **posição X** da sequência por outro **elemento** |
| `object replaceElement(object, object)` | O(1)          | O(1)                    | Substitui o **elemento** da sequência por **outro elemento**                  |
| `swapElements(object, object)`          | O(1)          | O(1)                    | Troca um **elemento** da sequência por **outro elemento** da sequência        |
| `object removeAtRank(integer)`          | O(n)          | O(n)                    | Remove o **elemento** na **posição X** da sequência                           |
| `object remove(object)`                 | O(n)          | O(1)                    | Remove o **elemento** da sequência                                            |
| `object elemAtRank(integer)`            | O(1)          | O(n)                    | Acessa o **elemento** na **posição X** da sequência                           |
| `object first()`                        | O(1)          | O(1)                    | Retorna o **primeiro elemento** da sequência                                  |
| `object last()`                         | O(1)          | O(1)                    | Retorna o **último elemento** da sequência                                    |
| `boolean inFirst(object)`               | O(1)          | O(1)                    | Verifica se o **elemento** é o **primeiro** da sequência                      |
| `boolean inLast(object)`                | O(1)          | O(1)                    | Verifica se o **elemento** é o **último** da sequência                        |
| `object after(object)`                  | O(1)          | O(1)                    | Retorna o **elemento posterior** ao **elemento** da sequência                 |
| `object before(object)`                 | O(1)          | O(1)                    | Retorna o **elemento anterior** ao **elemento** da sequência                  |
| `object atRank(integer)`                | O(1)          | O(n)                    | Retorna o **elemento** da **posição X** da sequência                          |
| `integer rankOf(object)`                | O(1)          | O(n)                    | Retorna a **posição X** do **elemento** da sequência                          |
| `integer size()`                        | O(1)          | O(1)                    | Retorna a **quantidade** de **elementos** da sequência                        |
| `boolean isEmpty()`                     | O(1)          | O(1)                    | Verifica se a sequência está **vazia**                                        |
| `object search(object)`                 | O(n)          | O(n)                    | Encontra um **elemento** da sequência                                         |

> 📌 Ambas suportam **todas as operações** do TAD Sequência. A escolha entre elas depende do tipo de acesso mais frequente: **acesso rápido por índice (array)** ou **navegação eficiente por posições (lista)**.
