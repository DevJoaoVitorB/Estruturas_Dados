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

* **EPosicaoInvalida**: Posição fora dos limites da sequência.
* **ENaoEncontrado:** Elemento não encontrado durante o `search()`.
* **ESequenciaVazia**: Tentativa de acessar/remover elemento de uma sequência **vazio**.
* **ESequenciaCheia**: Tentativa de inserir em sequência **cheio**.

<br>

## 🛠️ Exemplos Práticos

* Manipulação de documentos (texto, listas, histórico)
* Modelagem de editores com cursor (lista posicional)
* Acesso rápido por índice e operações locais com ponteiros
* Navegação em menus, playlists e comandos
* Pequenos Bancos de dados (e.g., Agenda de endereços)

<br>

## 🧱 Implementação com Array

> A sequência é representada com um **array fixo** contendo **nós como objetos**. Cada nó possui:
>
> * O **valor** armazenado
> * O **rank (índice lógico)** em que se encontra

### 🔧 Estrutura Básica

  * 🔹 Cada elemento do array é um objeto Nó, que armazena tanto o valor quanto seu índice lógico na estrutura.
  * 🔹 Como é um array, o acesso por posição (rank) é feito diretamente via índice.
  * 🔹 O array possui tamanho limitado. Caso atinja sua capacidade, é necessário redimensioná-lo manualmente ou implementar uma lógica de redimensionamento dinâmico.
  * 🔹 A posição é representada como um wrapper ao índice; o nó sabe sua própria posição, facilitando operações de ponte.
  * 🔹 Operações de leitura são rápidas, mas inserções e remoções internas são custosas por envolver deslocamento de elementos.

```text
Array:  [ Nó(10) ] [ Nó(20) ] [ Nó(30) ] [ -- ] [ -- ] [ -- ]
Ranks:     0         1         2
Tamanho: 3
Capacidade: 6
```

<br>

### ⚙️ Modo de Funcionamento

* Todas as operações (genéricas, de vetor, de lista e de ponte) são suportadas.
* Acesso direto por rank é eficiente (O(1)).
* Inserções e remoções envolvem deslocamento de elementos (O(n)).
* Nós armazenam o índice lógico, facilitando a conversão entre rank e posição.

<br>

### ⚠️ Limitações

* Capacidade fixa (necessita redimensionamento quando cheia: [**Estratégia Incremental**](pilha.md/#1-estratégia-incremental) e [**Estratégia Duplicativa (Exponencial)**](pilha.md/#2-estratégia-duplicativa-exponencial)).
* Deslocamentos custosos em operações de inserção/remoção em posições intermediárias.
* Maior complexidade para manipular posições relativas (before/after).

<br>

### ✏️ Implementação em C#
```csharp
using System;

class SequenciaVaziaExcecao : Exception               // Classe de Exceção de Sequencia Vazia
{
    public SequenciaVaziaExcecao() : base("A Sequência está vazia!") {}
    public SequenciaVaziaExcecao(string mensagem) : base(mensagem) {}
    public SequenciaVaziaExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}

class ObjetoNaoEncontradoExcecao : Exception          // Classe de Exceção de Objeto não Encontrado na Sequência
{
    public ObjetoNaoEncontradoExcecao() : base("Objeto não foi encontrado na Sequência!") {}
    public ObjetoNaoEncontradoExcecao(string mensagem) : base(mensagem) {}
    public ObjetoNaoEncontradoExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}

class PosicaoInvalidaExcecao : Exception              // Classe de Exceção de Posição Inválida na Sequência
{
    public PosicaoInvalidaExcecao() : base("Posição informada invalida!") {}
    public PosicaoInvalidaExcecao(string mensagem) : base(mensagem) {}
    public PosicaoInvalidaExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}'
}

interface Sequencia<T>
{
    void InsertAtRank(int posicao, T objeto);       // Método para Adicionar Elemento em uma Posição X da Sequência
    void InsertFirst(T objeto);                     // Método para Inserir Elemento no Início da Sequência
    void InsertLast(T objeto);                      // Método para Inserir Elemento no Final da Sequência
    void InsertAfter(T objetoRef, T objeto);        // Método para Inserir Elemento Depois de Outro Elemento da Sequência
    void InsertBefore(T objetoRef, T objeto);       // Método para Inserir Elemento Antes de Outro Elemento da Sequência
    T ReplaceAtRank(int posicao, T objeto);         // Método para Substituir um Elemento por Outro em uma Posição X da Sequência
    T ReplaceElement(T objetoRef, T objeto);        // Método para Substituir Elemento Antigo da Sequência por Elemento Novo
    void SwapElement(T objetoRef1, T objetoRef2);   // Método para Trocar Posição do Elemento com Outro Elemento da Sequência
    T RemoveAtRank(int posicao);                    // Método para Remover Elemento em uma Posição X da Sequência
    T Remove(T objeto);                             // Método para Remover e Retornar Elemento da Sequência
    T ElemAtRank(int posicao);                      // Método de Retorno do Elemento da Posição X da Sequência
    No<T> First();                                  // Método para Retornar o Primeiro Elemento da Sequência
    No<T> Last();                                   // Método para Retornar o Último Elemento da Sequência
    bool InFirst(T objeto);                         // Método para Verificar se Elemento está na Primeira Posição da Sequência
    bool InLast(T objeto);                          // Método para Verificar se Elemento está na Última Posição da Sequência
    No<T> After(T objeto);                          // Método para Retornar Elemento Posterior a Outro Elemento da Sequência
    No<T> Before(T objeto);                         // Método para Retornar Elemento Anterior a Outro Elemento da Sequência
    int Size();                                     // Método para Retornar Número de Elementos da Sequência
    bool IsEmpty();                                 // Método para Verificar se a Sequência está Vazia
    No<T> Search(T objeto);                         // Método para Retornar Elemento da Sequência se Existir
    No<T> atRank(int posicao);                      // Método para Retornar Elemento da Posição X da Sequência
    int rankOf(T objeto);                           // Método para Retornar Posição X do Elemento da Sequência
}

class SequenciaArray<T> : Sequencia<T>
{
    private int Capacidade;                         // Capacidade da SequenciaArray
    private int QtdElement;                         // Quantidade de Elementos da Sequência
    private T[] ArraySequencia;                     // Array que Contém os Elementos da Sequência

    public SequênciaArray(int capacidade)
    {
        Capacidade = capacidade;                // Definir a capacidade inicial da SequênciaArray
        QtdElement = 0;                         // Sequência está vazia
        ArraySequencia = new T[Capacidade];     // Inicializando SequênciaArray
    }

    private void Redimensionar()
    {
        Capacidade *= 2;                          // Estratégia Duplicativa
        T[] tempArray = new T[Capacidade];        // Criação de um Array temporário
        for(int i = 0; i < Size(); i++)
        {
            tempArray[i] = ArraySequencia[i];     // Colocar os elementos do antigo Array (ArraySequencia) para o novo Array (tempArray)
        }
        ArraySequencia = tempArray;               // tempArray passa a ser o novo Array
    }

    public void InsertAtRank(int posicao, T objeto)
    {
        if (posicao > Size() || posicao >= Capacidade) throw new PosicaoInvalidaExcecao();    // Verificar se a posição informada está inválida
        if (Size() == Capacidade) Redimensionar();                                            // Verificar se a SequênciaArray está cheia
        if (posicao < Size())
        {
            for (int j = Size(); j > posicao; j--)
            {
                ArraySequencia[j] = ArraySequencia[j - 1];                                    // Deslocar para direita os Elementos da posição X até o último anteriormente adicionado
            }
        }
        ArraySequencia[posicao] = objeto;                                                     // Adicionar elemento a posição X
        QtdElement++;                                                                         // Quantidade de elementos +1
    }

    public void InsertFirst(T objeto)
    {
        if (Size() == Capacidade) Redimensionar();                                      // Verificar se a SequênciaArray está cheia
        for (int i = Size(); i > 0; i--) ArraySequencia[i] = ArraySequencia[i - 1];     // Deslocar os elementos da SequênciaArray para a direita a partir do inicio
        ArraySequencia[0] = objeto;                                                     // Adicionar o elemento no inicio da Sequência
        QtdElement++;                                                                   // Quantidade de elementos +1
    }

    public void InsertLast(T objeto)
    {
        if (Size() == Capacidade) Redimensionar();    // Verificar se a SequênciaArray está cheia
        ArraySequencia[Size()] = objeto;              // Adicionar o elemento no final da Sequência
        QtdElement++;                                 // Quantidade de elementos +1
    }

    public void InsertAfter(int posicao, T objeto)
    {
        if (posicao < 0 || posicao >= Size()) throw new PosicaoInvalidaExcecao();                 // Verificar se a posição está no range da Sequência
        if (Size() == Capacidade) Redimensionar();                                                // Verificar se a SequênciaArray está cheia
        for (int i = Size(); i > posicao + 1; i--) ArraySequencia[i] = ArraySequencia[i - 1];     // Deslocar os elementos da SequênciaArray para a direita a partir do próximo da posição do elemento de referência
        ArraySequencia[posicao + 1] = objeto;                                                     // Adicionar o elemento depois do elemento da posição informada
        QtdElement++;                                                                             // Quantidade de elementos +1
    }

    public void InsertBefore(int posicao, T objeto)
    {
        if (posicao < 0 || posicao >= Size()) throw new PosicaoInvalidaExcecao();             // Verificar se a posição está no range da Sequência
        if (Size() == Capacidade) Redimensionar();                                            // Verificar se a SequênciaArray está cheia
        for (int i = Size(); i > posicao; i--) ArraySequencia[i] = ArraySequencia[i - 1];     // Deslocar os elementos da SequênciaArray para a direita a partir da posição do elemento de referência
        ArraySequencia[posicao] = objeto;                                                     // Adicionar o elemento antes do elemento da posição informada
        QtdElement++;                                                                         // Quantidade de elementos +1
    }

    public T ReplaceAtRank(int posicao, T objeto)
    {
        if (IsEmpty()) throw new SequenciaVazioExcecao();                                       // Verificar se o SequênciaArray está Vazio
        if (posicao >= Size() || posicao >= Capacidade) throw new PosicaoInvalidaExcecao();     // Verificar se a posição informada está inválida

        T objetoSubstituido = ArraySequencia[posicao];                                          // Guarda o objeto que será substituido
        ArraySequencia[posicao] = objeto;                                                       // Substituir o objeto antigo pelo objeto novo
        return objetoSubstituido;                                                               // Retorna o objeto que será substituido
    }

    public T ReplaceElement(int posicao, T objeto)
    {
        if (posicao < 0 || posicao >= Size()) throw new PosicaoInvalidaExcecao();         // Verificar se a posição está no range da Sequência
        T elementSubstituido = ArraySequencia[posicao];                                   // Elemento que será substituido 
        ArraySequencia[posicao] = objeto;                                                 // Substituir o elemento da Sequência da posição informada por outro elemento
        return elementSubstituido;                                                        // Retorna elemento que será substituido
    }

    public void SwapElement(int posicao1, int posicao2)
    {
        if (posicao1 < 0 || posicao1 >= Size() || posicao2 < 0 || posicao2 >= Size()) throw new PosicaoInvalidaExcecao();         // Verificar se a posição está no range da Sequência
        T objeto1 = ArraySequencia[posicao1];                                                                                     // Primeiro elemento da troca
        ArraySequencia[posicao1] = ArraySequencia[posicao2];                                                                      // Posição do elemento 1 passa a ser ocupada pelo elemento 2
        ArraySequencia[posicao2] = objeto1;                                                                                       // Posição do elemento 2 passa a ser ocupada pelo elemento 1
    }

    public T RemoveAtRank(int posicao)
    {
        if (IsEmpty()) throw new SequenciaVaziaExcecao();                                           // Verificar se o SequênciaArray está Vazio
        if (posicao >= Size() || posicao >= Capacidade) throw new PosicaoInvalidaExcecao();         // Verificar se a posição informada está inválida
        T objetoRemovido = ArraySequencia[posicao];                                                 // Guardar o objeto a ser removido
        for (int i = posicao; i < Size(); i++)
        {
            ArraySequencia[i] = ArraySequencia[i + 1];                                              // Deslocar para esquerda os Elementos da posição X+1 até o último anteriormente adicionado
        }
        QtdElement--;                                                                               // Quantidade de elementos -1
        return objetoRemovido;                                                                      // Retornando o valor que será removido
    }

    public T Remove(int posicao)
    {
        if (posicao < 0 || posicao >= Size()) throw new PosicaoInvalidaExcecao();               // Verificar se a posição está no range da Sequência
        if (IsEmpty()) throw new SequenciaVaziaExcecao();                                       // Verificar se a Sequência está vazia
        T elementRemovido = ArraySequencia[posicao];                                            // Elemento que será removido
        for (int i = posicao; i < Size() - 1; i++) ArraySequencia[i] = ArraySequencia[i + 1];   // Deslocar os elementos da SequênciaArray para a esquerda a partir da posição do elemento que será removido                   
        QtdElement--;                                                                           // Quantidade de elementos -1
        return elementRemovido;                                                                 // Retorna o elemento que será removido
    }

    public T ElemAtRank(int posicao)
    {
        if (IsEmpty()) throw new SequenciaVazioExcecao();                                       // Verificar se o SequênciaArray está Vazio
        if (posicao >= Size() || posicao >= Capacidade) throw new PosicaoInvalidaExcecao();     // Verificar se a posição informada está inválida

        return ArraySequencia[posicao];                                                         // Retorna o objeto da posição X
    }

    public T First()
    {
        if (IsEmpty()) throw new SequenciaVaziaExcecao();   // Verificar se a Sequência está vazia
        return ArraySequência[0];                           // Retorna o primeiro elemento da Sequência
    }

    public T Last()
    {
        if (IsEmpty()) throw new SequenciaVaziaExcecao();   // Verificar se a Sequência está vazia
        return ArraySequência[Size() - 1];                  // Retorna o último elemento da Sequência
    }

    public bool InFirst(int posicao)
    {
        if (IsEmpty()) throw new SequenciaVaziaExcecao();                                       // Verificar se a Sequência está vazia
        if (posicao < 0 || posicao >= Size()) throw new PosicaoInvalidaExcecao();               // Verificar se a posição está no range da Sequência
        return EqualityComparer<T>.Default.Equals(ArraySequencia[posicao], ArraySequencia[0]);  // Verificar se o elemento da posição informada é o primeiro
    }

    public bool InLast(int posicao)
    {
        if (IsEmpty()) throw new SequenciaVaziaExcecao();                                                 // Verificar se a Sequência está vazia
        if (posicao < 0 || posicao >= Size()) throw new PosicaoInvalidaExcecao();                         // Verificar se a posição está no range da Sequência
        return EqualityComparer<T>.Default.Equals(ArraySequencia[posicao], ArraySequencia[Size() - 1]);   // Verificar se o elemento da posição informada é o último
    }

    public T After(int posicao)
    {
        if (IsEmpty()) throw new SequenciaVaziaExcecao();                                 // Verificar se a Sequência está vazia
        if (posicao < 0 || posicao >= Size()) throw new PosicaoInvalidaExcecao();         // Verificar se a posição está no range da Sequência
        return ArraySequencia[posicao + 1];                                               // Retorna o elemento posterior ao elemento da posição informada
    }

    public T Before(int posicao)
    {
        if (IsEmpty()) throw new SequenciaVaziaExcecao();                                 // Verificar se a Sequência está vazia
        if (posicao <= 0 || posicao >= Size()) throw new PosicaoInvalidaExcecao();        // Verificar se a posição está no range da Sequência
        return ArraySequencia[posicao - 1];                                               // Retorna o elemento anterior ao elemento da posição informada
    }

    public int Size()
    {
        return QtdElement;                              // Retorna a quantidade de Nós da Sequência
    }

    public bool IsEmpty()
    {
        return QtdElement == 0;                         // Verificar se a Sequência está vazia
    }

    public No<T> Search(T objeto)
    {
      
    }

    public No<T> atRank(int posicao)
    {

    }

    public int rankOf(T objeto)
    {

    }
}
```

<br>

## 🔁 Implementação com Lista Duplamente Ligada

> A sequência é implementada como uma **lista duplamente ligada**, com **nós contendo**:
>
> * O **valor** armazenado
> * Ponteiro para o **nó anterior (prev)**
> * Ponteiro para o **nó seguinte (next)**

### 🔧 Estrutura Básica

  * 🔹 Cada nó armazena o valor, além de ponteiros para o nó anterior e o seguinte.
  * 🔹 O primeiro e o último nós (head e tail) são fixos e ajudam a simplificar inserções e remoções nos extremos.
  * 🔹 Graças aos ponteiros, é possível navegar para frente e para trás com eficiência (`before()` e `after()`).
  * 🔹 Exige varredura da lista até alcançar o índice desejado, já que não há indexação direta.
  * 🔹 Inserções e remoções em qualquer ponto são feitas rapidamente com atualização de ponteiros.

```text
[Sentinela Head] ⇄ [ Nó(10) ] ⇄ [ Nó(20) ] ⇄ [ Nó(30) ] ⇄ [Sentinela Tail]
```

<br>

### ⚙️ Modo de Funcionamento

* Suporte completo a todas as operações do TAD Sequência.
* Navegação eficiente com ponteiros (`before()`, `after()`, `insertBefore()`, etc.).
* Conversão entre posição e rank com `atRank()` e `rankOf()`.
* Inserções e remoções em O(1) com ponteiros apropriados.

<br>

### ⚠️ Limitações

* Acesso por rank é O(n) (necessário percorrer da cabeça até o rank desejado).
* Maior uso de memória devido aos ponteiros adicionais por nó.
* Implementação mais complexa devido à manutenção das referências.

<br>

### ✏️ Implementação em C#
```csharp

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
