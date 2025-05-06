<h1 align="center">📚 TAD - Lista</h1>
<p align="center">🎯 <strong>Estrutura Sequencial Linear Abstrata</strong></p>
<p align="center">⚠️ Permite inserções, remoções e acessos em posições arbitrárias.</p>

## 🔧 Operações Principais
- `insertFirst(object)` → Insere um elemento no **início** da lista.
- `insertLast(object)` → Insere um elemento no **final** da lista.
- `insertAfter(object, object)` → Insere elemento **depois** de outro elemento.
- `insertBefore(object, object)` → Insere um elemento **antes** de outro elemento.
- `replaceElement(object, object)` → Substitui um **elemento antigo** por um **elemento novo**.
- `swapElement(object, object)` → Troca de posição de um elemento com outro elemento.
- `object remove(object)` → Remove e retorna um elemento da lista.

## 🧰 Operações Auxiliares
- `object first()` → Retorna o **primeiro elemento**.
- `object last()` → Retorna o **último elemento**.
- `boolean inFirst(object)` → Verifica se o elemento está na **primeira posição**.
- `boolean inLast(object)` → Verifica se o elemento está na **última posição**.
- `object after(object)` → Retorna um elemento **posterior** a outro elemento.
- `object before(object)` → Retorna um elemento **anterior** a outro elemento.
- `interger size()` → Retorna o **número de elementos** na lista.
- `boolean isEmpty()` → Verifica se a lista está **vazia**.
- `object search(object)` → Retorna o **elemento** da lista se ele existir.

<br>

## ⚠️ Exceções

- **EListaVazia:** Tentativa de remoção, troca ou retorno com a lista vazia.
- **ENaoEncontrado:** Elemento não encontrado durante o `search()`.

<br>

## 🛠️ Exemplos Práticos

- Editor de texto (inserção/remoção no meio de parágrafos)
- Listas de reprodução (playlists)
- Navegação (voltar/avançar em histórico)
- Gerenciadores de tarefas encadeadas

<br>

## 🧱 Implementação Usando Lista **Simplesmente Ligada**

> Cada nó aponta apenas para o **próximo**. A lista usa nós **sentinelas** para Head e Tail.

### 🔧 Estrutura Básica

```text
Head -> [A] -> [B] -> [C] -> Tail
```

- A lista possui dois nós especiais: `Head` e `Tail`
- O primeiro elemento da lista vem **após `Head`**
- O fim da lista é **antes de `Tail`**
- A estrutura evita `null` e facilita inserções/remoções

<br>

### ⚙️ Modo de Funcionamento

- `Head` aponta para o primeiro **nó real** (ou para `Tail` se estiver vazia).
- Cada nó aponta para o **próximo**, até chegar ao `Tail`.
- Inserções são feitas redirecionando ponteiros do nó anterior.
- Remoções são feitas pulando o nó a ser removido.
- Para acessar um nó anterior (`Before()`), é necessário percorrer a lista desde o `Head`.

<br>

### ❌ Limitações

- Acesso aleatório **não é eficiente** → precisa iterar do início.
- Percorrer `before(position)` é **custoso**, pois não há ponteiro para o nó anterior.

<br>

### ✏️ Implementação em C#
```csharp
using System;

class ListaVaziaExcecao : Exception                 // Classe de Exceção de Lista Vazia
{
    public ListaVaziaExcecao() : base("A Lista está vazia!") {}
    public ListaVaziaExcecao(string mensagem) : base(mensagem) {}
    public ListaVaziaExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}

class ObjetoNaoEncontradoExcecao : Exception         // Classe de Exceção de Objeto não Encontrado na Lista
{
    public ObjetoNaoEncontradoExcecao() : base("Objeto não foi encontrado na Lista!") {}
    public ObjetoNaoEncontradoExcecao(string mensagem) : base(mensagem) {}
    public ObjetoNaoEncontradoExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}

interface Lista<T>
{
    void InsertFirst(T objeto);                     // Método para Inserir Elemento no Início da Lista
    void InsertLast(T objeto);                      // Método para Inserir Elemento no Final da Lista
    void InsertAfter(T objetoRef, T objeto);        // Método para Inserir Elemento Depois de Outro Elemento da Lista
    void InsertBefore(T objetoRef, T objeto);       // Método para Inserir Elemento Antes de Outro Elemento da Lista
    void ReplaceElement(T objetoRef, T objeto);     // Método para Substituir Elemento Antigo da Lista por Elemento Novo
    void SwapElement(T objetoRef1, T objetoRef2);   // Método para Trocar Posição do Elemento com Outro Elemento da Lista
    T Remove(T objeto);                             // Método para Remover e Retornar Elemento da Lista
    T First();                                      // Método para Retornar o Primeiro Elemento da Lista
    T Last();                                       // Método para Retornar o Último Elemento da Lista
    bool InFirst(T objeto);                         // Método para Verificar se Elemento está na Primeira Posição da Lista
    bool InLast(T objeto);                          // Método para Verificar se Elemento está na Última Posição da Lista
    T After(T objeto);                              // Método para Retornar Elemento Posterior a Outro Elemento da Lista
    T Before(T objeto);                             // Método para Retornar Elemento Anterior a Outro Elemento da Lista
    int Size();                                     // Método para Retornar Número de Elementos da Lista
    bool IsEmpty();                                 // Método para Verificar se a Lista está Vazia
    T search(T objeto);                             // Método para Retornar Elemento da Lista se Existir
}

class No<T>
{
    public No<T> Next {get; set;}                   // Nó de referência próximo
    public T Objeto {get; set;}                     // Objeto do Nó

    public No(T objeto = default)
    {
        Objeto = objeto;                            // Adicionando um objeto ao Nó
        Next = null;                                // Inicializando a referência para o próximo Nó como NULL
    }
}

class ListaSimplismenteLigada<T> : Lista<T>
{
    private No<T> Head;                             // Nó Sentinela Head
    private No<T> Tail;                             // Nó Sentinela Tail
    private int QtdElement;                         // Quantidade de elementos da Lista

    public ListaSimplismenteLigada()
    {
        Head = new No<T>();                         // Inicializando o Nó Sentinela Head
        Tail = new No<T>();                         // Inicializando o Nó Sentinela Tail
        Head.Next = Tail;                           // Referência do próximo do Nó Head é o Nó Tail
        QtdElement = 0;                             // Lista está vazia
    }

    public void InsertFirst(T objeto)
    {
        No<T> novoNo = new No<T>();                 // Criando um novo Nó
        novoNo.Objeto = objeto;                     // Adicionando o objeto ao Nó
        novoNo.Next = Head.Next;                    // Referência do próximo do novo Nó é o próximo de Head 
        Head.Next = NovoNo;                         // O próximo de Head passa a ser o novo Nó
        QtdElement++;                               // Quantidade de elementos +1
    }

    public void InsertLast(T objeto)
    {
        No<T> novoNo = new No<T>();                 // Criando um novo Nó
        novoNo.Objeto = objeto;                     // Adicionando o objeto ao Nó
        No<T> ultimoElemento = Last();              // Encontrar o último elemento antes de Tail
        novoNo.Next = Tail;                         // Referência do próximo do novo Nó é Tail
        ultimoElemento.Next = novoNo;               // Referência do próximo do antigo último elemento é o novo Nó 
        QtdElement++;                               // Quantidade de elementos +1
    }

    public void InsertAfter(T objetoRef, T objeto)
    {
        No<T> novoNo = new No<T>();                 // Criando um novo Nó
        novoNo.Objeto = objeto;                     // Adicionando o objeto ao Nó
        No<T> noReferencia = Search(objetoRef);     // Nó de referência para adicionar um outro Nó após
        novoNo.Next = noReferencia.Next;            // Referência do próximo do novo Nó é o próximo do Nó de referência
        noReferencia.Next = novoNo;                 // Referência do próximo do Nó de referência é o novo Nó
        QtdElement++;                               // Quantidade de elementos +1
    }

    public void InsertBefore(T objetoRef, T objeto)
    {
        No<T> novoNo = new No<T>();                 // Criando um novo Nó
        novoNo.Objeto = objeto;                     // Adicionando o objeto ao Nó
        No<T> noReferencia = Search(objetoRef);     // Nó de referência para adicionar um outro Nó antes
        No<T> atualNo = Head;                       // Conseguir uma referência auxiliar do começo da Lista
        while(atualNo.Next != noReferencia)
        {
            atualNo = atualNo.Next;                 // Encontra o Nó anterior ao Nó de referência
        }
        novoNo.Next = noReferencia;                 // Referência do próximo do novo Nó é o Nó de referência
        atualNo.Next = novoNo;                      // Referência do Nó anterior ao Nó de referência é o novo Nó
        QtdElement++;                               // Quantidade de elementos +1
    }

    public void ReplaceElement(T objetoRef, T objeto)
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> novoNo = new No<T>();                     // Criando um novo Nó
        novoNo.Objeto = objeto;                         // Adicionando o objeto ao Nó
        No<T> noReferencia = Search(objetoRef);         // Nó de referência para ser substituido pelo novo Nó
        novoNo.Next = noReferencia.Next;                // Referência posterior do novo Nó é a referência posterior do Nó de referência
        No<T> atualNo = Head;                           // Conseguir uma referência auxiliar do começo da Lista
        while(atualNo.Next != noReferencia)
        {
            atualNo = atualNo.Next;                     // Encontra o Nó anterior ao Nó de referência
        }
        atualNo.Next = novoNo;                          // Referência posterior da referência anterior do Nó de referência é o novo Nó
        noReferencia.Next = null;                       // Anular o próximo do Nó que será substituido
    }

    public void SwapElement(T objetoRef1, T objetoRef2)
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> noReferencia1 = Search(objetoRef1);       // Nó de referência 1 que irá troca de lugar com o Nó de referência 2
        No<T> noReferencia2 = Search(objetoRef2);       // Nó de referência 2 que irá troca de lugar com o Nó de referência 1
        No<T> atualNo = Head;                           // Conseguir uma referência auxiliar do começo da Lista
        while(atualNo.Next != noReferencia1)
        {
            atualNo = atualNo.Next;                 // Encontra o Nó anterior ao Nó de referência 1
        }
        No<T> prevRef1 = atualNo;                   // Armazenar o Nó anterior ao Nó de referência 1
        atualNo = Head;                             // Novamente atualNo passa a ser a referência auxiliar do começo da Lista
        while(atualNo.Next != noReferencia2)
        {
            atualNo = atualNo.Next;                 // Encontra o Nó anterior ao Nó de referência 2
        }
        noReferencia1.Next = noReferencia2.Next;    // Referência do próximo do Nó de referência 1 passa a ser o próximo do Nó de referência 2
        atualNo.Next = noReferencia1;               // Próximo do Nó anterior ao Nó de referência 2 passa a ser o Nó de referência 1
        noReferencia2.Next = noReferencia1.Next;    // Referência do próximo do Nó de referência 2 passa a ser o próximo do Nó de referência 1
        prevRef1.Next = noReferencia2;              // Próximo do Nó anterior ao Nó de referência 1 passa a ser o Nó de referência 2
    }

    public T Remove(T objeto)
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> noRemovido = Search(objeto);              // Encontrar o Nó que será removido
        No<T> atualNo = Head;                           // Conseguir uma referência auxiliar do começo da Lista
        while(atualNo.Next != noRemovido)
        {
            atualNo = atualNo.Next                      // Encontra o Nó anterior ao Nó que será removido
        }
        atualNo.Next = noRemovido.Next;                 // Próximo do Nó anterior ao Nó que será removida passa a ser o próximo do Nó que será removido
        noRemovido.Next = null;                         // Anular o próximo do Nó que será removido
        QtdElement--;                                   // Quantidade de elementos -1
        return noRemovido.Objeto;                       // Retorna o elemento do Nó que será removido
    }

    public T First()
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        return Head.Next;                               // Retorna o primeiro Nó da Lista
    }

    public T Last()
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> atualNo = Head;                           // Conseguir uma referência auxiliar do começo da Lista
        while (atualNo.Next != Tail)
        {
            atualNo = atualNo.Next                      // Encontra o último Nó - anterior ao Tail
        }
        return atualNo;                                 // Retorna o último Nó da Lista
    }

    public bool InFirst(T objeto)
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> noReferencia = Search(objeto);            // Nó de referência que quer saber se está no inicio da Lista
        bool inFirst = false;                           // Váriavel auxiliar para saber se o Nó de referência está no inicio da Lista
        if(Head.Next == noReferencia) inFirst = true;   // Verificação para saber se o Nó de referência está no inicio da Lista
        return inFirst;                                 // Retorna a reposta - TRUE ou FALSE - se o Nó de referência está no inicio da Lista
    }

    public bool InLast(T objeto)
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> noReferencia = Search(objeto);            // Nó de referência que quer saber se está no final da Lista
        bool inLast = false;                            // Váriavel auxiliar para saber se o Nó de referência está no final da Lista
        if(Last() == noReferencia) inLast = true;       // Verificação para saber se o Nó de referência está no final da Lista
        return inLast;                                  // Retorna a reposta - TRUE ou FALSE - se o Nó de referência está no final da Lista
    }

    public T After(T objeto)
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> noReferencia = Search(objeto);            // Nó de referência para encontrar o próximo Nó a ele
        return noReferencia.Next;                       // Retorna o próximo Nó ao Nó de referência
    }

    public T Before(T objeto)
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> noReferencia = Search(objeto);            // Nó de referência para encontrar o Nó anterior a ele
        No<T> atualNo = Head;                           // Conseguir uma referência auxiliar do começo da Lista
        while(atualNo.Next != noReferencia)
        {
            atualNo = atualNo.Next;                     // Encontra o Nó anterior ao Nó de referência
        }
        return atualNo;                                 // Retorna o Nó anterior ao Nó de referência
    }

    public int Size()
    {
        return QtdElement;                              // Retorna a quantidade de Nós da Lista
    }

    public bool IsEmpty()
    {
        return Head.Next == Tail;                       // Verificar se a Lista está vazia
    }

    public T Search(T objeto)
    {
        No<T> atualNo = Head;                                                   // Conseguir uma referência auxiliar do começo da Lista
        while (atualNo.Objeto != objeto)
        {
            atualNo = atualNo.Next                                              // Encontra o Nó que possui o elemento
        }
        if(atualNo.Objeto != objeto) throw new ObjetoNaoEncontradoExcecao();    // Verificar se existi o Nó com o elemento na Lista
        return atualNo;                                                         // Retorna se existir o Nó com o elemento
    }
}

```

<br>

## 🧱 Implementação Usando Lista **Duplamente Ligada**

> Cada nó aponta para o **próximo** e o **anterior**. Também usa sentinelas `Head` e `Tail`.

### 🔧 Estrutura Básica

```text
Head <-> [A] <-> [B] <-> [C] <-> Tail
```

- `Head` aponta para o primeiro nó válido
- `Tail` aponta para o último nó válido
- Inserções e remoções são feitas com ajustes em dois ponteiros

<br>

### ⚙️ Modo de Funcionamento

- `Head` aponta para o primeiro **nó real** através de `Head.After()`.
- `Tail` é apontado pelo último nó real através de `Tail.Before()`.
- Cada nó possui ponteiros **para frente e para trás**, permitindo acesso eficiente nas duas direções.
- Inserções e remoções em qualquer posição são feitas em **tempo constante**, desde que a posição seja conhecida.

<br>

### ✅ Vantagens

- Operações `before()` e `after()` são **eficientes** - O(1)
- Fácil de percorrer nos dois sentidos
- Remoções e trocas de elementos são mais diretas

<br>

### ❌ Limitações

- Ocupa **mais memória** por conta do ponteiro extra
- Levemente mais complexa de implementar

<br>

### ✏️ Implementação em C#
```csharp
using System;

class ListaVaziaExcecao : Exception                 // Classe de Exceção de Lista Vazia
{
    public ListaVaziaExcecao() : base("A Lista está vazia!") {}
    public ListaVaziaExcecao(string mensagem) : base(mensagem) {}
    public ListaVaziaExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}

class ObjetoNaoEncontradoExcecao : Exception         // Classe de Exceção de Objeto não Encontrado na Lista
{
    public ObjetoNaoEncontradoExcecao() : base("Objeto não foi encontrado na Lista!") {}
    public ObjetoNaoEncontradoExcecao(string mensagem) : base(mensagem) {}
    public ObjetoNaoEncontradoExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}

interface Lista<T>
{
    void InsertFirst(T objeto);                     // Método para Inserir Elemento no Início da Lista
    void InsertLast(T objeto);                      // Método para Inserir Elemento no Final da Lista
    void InsertAfter(T objetoRef, T objeto);        // Método para Inserir Elemento Depois de Outro Elemento da Lista
    void InsertBefore(T objetoRef, T objeto);       // Método para Inserir Elemento Antes de Outro Elemento da Lista
    void ReplaceElement(T objetoRef, T objeto);     // Método para Substituir Elemento Antigo da Lista por Elemento Novo
    void SwapElement(T objetoRef1, T objetoRef2);   // Método para Trocar Posição do Elemento com Outro Elemento da Lista
    T Remove(T objeto);                             // Método para Remover e Retornar Elemento da Lista
    T First();                                      // Método para Retornar o Primeiro Elemento da Lista
    T Last();                                       // Método para Retornar o Último Elemento da Lista
    bool InFirst(T objeto);                         // Método para Verificar se Elemento está na Primeira Posição da Lista
    bool InLast(T objeto);                          // Método para Verificar se Elemento está na Última Posição da Lista
    T After(T objeto);                              // Método para Retornar Elemento Posterior a Outro Elemento da Lista
    T Before(T objeto);                             // Método para Retornar Elemento Anterior a Outro Elemento da Lista
    int Size();                                     // Método para Retornar Número de Elementos da Lista
    bool IsEmpty();                                 // Método para Verificar se a Lista está Vazia
    T search(T objeto);                             // Método para Retornar Elemento da Lista se Existir
}

class No<T>
{
    public No<T> Next {get; set;}                   // Nó de referência próximo
    public No<T> Prev {get; set;}                   // Nó de referência anterior
    public T Objeto {get; set;}                     // Objeto do Nó

    public No(T objeto = default)
    {
        Objeto = objeto;                            // Adicionando um objeto ao Nó
        Next = Prev = null;                         // Inicializando a referência para o próximo e o anterior do Nó como NULL
    }
}

class ListaDuplamenteLigada<T> : Lista<T>
{
    private No<T> Head;                             // Nó Sentinela Head
    private No<T> Tail;                             // Nó Sentinela Tail
    private int QtdElement;                         // Quantidade de elementos da Lista

    public ListaDuplamenteLigada()
    {
        Head = new No<T>();                         // Inicializando o Nó Sentinela Head
        Tail = new No<T>();                         // Inicializando o Nó Sentinela Tail
        Head.Next = Tail;                           // Referência do próximo do Nó Head é o Nó Tail
        Tail.Prev = Head;                           // Referência do anterior do Nó Tail é o Nó Head
        QtdElement = 0;                             // Lista está vazia
    }

    public void InsertFirst(T objeto)
    {
        No<T> novoNo = new No<T>();                 // Criando um novo Nó
        novoNo.Objeto = objeto;                     // Adicionando o objeto ao Nó
        No<T> primeiroNo = Head.Next;               // primeiro Nó - posterior a Head
        novoNo.Next = primeiroNo;                   // Referência posterior do novo Nó é o próximo de Head - primeiro Nó
        novoNo.Prev = Head;                         // Referência anterior do novo Nó é Head     
        Head.Next = NovoNo;                         // Referência posterior de Head passa a ser o novo Nó
        primeiroNo.Prev = NovoNo;                   // Referência anterior do antigo primeiro Nó passa a ser o novo Nó    
        QtdElement++;                               // Quantidade de elementos +1
    }

    public void InsertLast(T objeto)
    {
        No<T> novoNo = new No<T>();                 // Criando um novo Nó
        novoNo.Objeto = objeto;                     // Adicionando o objeto ao Nó
        No<T> ultimoNo = Tail.Prev                  // último Nó - anterior a Tail
        novoNo.Next = Tail;                         // Referência posterior do novo Nó é Tail
        novoNo.Prev = ultimoNo;                     // Referência anterior do novo Nó é o anterior de Tail - último Nó
        ultimoNo.Next = novoNo;                     // Referência posterior do antigo último Nó passa a ser o novo Nó    
        Tail.Prev = novoNo;                         // Referência anterior de Tail passa a ser o novo Nó
        QtdElement++;                               // Quantidade de elementos +1
    }

    public void InsertAfter(T objetoRef, T objeto)
    {
        No<T> novoNo = new No<T>();                 // Criando um novo Nó
        novoNo.Objeto = objeto;                     // Adicionando o objeto ao Nó
        No<T> noReferencia = Search(objetoRef);     // Nó de referência para adicionar um outro Nó após
        No<T> noRefNext = noReferencia.Next;        // Referência posterior do Nó de referência
        novoNo.Next = noRefNext;                    // Referência posterior do novo Nó é a referência posterior do Nó de referência
        novoNo.Prev = noReferencia;                 // Referência anterior do novo Nó é o Nó de referência
        noReferencia.Next = novoNo;                 // Referência posterior do Nó de referência é o novo Nó
        noRefPrev.Prev = novoNo;                    // Referência anterior da antiga referência posterior do Nó de referência é o novo Nó
        QtdElement++;                               // Quantidade de elementos +1
    }

    public void InsertBefore(T objetoRef, T objeto)
    {
        No<T> novoNo = new No<T>();                 // Criando um novo Nó
        novoNo.Objeto = objeto;                     // Adicionando o objeto ao Nó
        No<T> noReferencia = Search(objetoRef);     // Nó de referência para adicionar um outro Nó antes
        No<T> noRefPrev =  noReferencia.Prev;       // Referência anterior do Nó de referência
        novoNo.Next = noReferencia;                 // Referência posterior do novo Nó é o Nó de referência
        novoNo.Prev = noRefPrev;                    // Referência anterior do novo Nó é a referência anterior do Nó de referência
        noRefPrev.Next = novoNo;                    // Referência posterior da antiga referência anterior do Nó de referência é o novo Nó
        noReferencia.Prev = novoNo;                 // Referência anterior do Nó de referência é o novo Nó
        QtdElement++;                               // Quantidade de elementos +1
    }

     public void ReplaceElement(T objetoRef, T objeto)
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> novoNo = new No<T>();                     // Criando um novo Nó
        novoNo.Objeto = objeto;                         // Adicionando o objeto ao Nó
        No<T> noReferencia = Search(objetoRef);         // Nó de referência para ser substituido pelo novo Nó
        No<T> noRefNext = noReferencia.Next;            // Referência posterior do Nó de referência
        No<T> noRefPrev = noReferencia.Prev;            // Referência anterior do Nó de referência
        novoNo.Next = noRefNext;                        // Referência posterior do novoNo é a referência posterior do Nó de referência
        novoNo.Prev = noRefPrev;                        // Referência anterior do novoNo é a referência anterior do Nó de referência
        noRefNext.Prev = novoNo;                        // Referência anterior da referência posterior do Nó de referência é o novo Nó
        noRefPrev.Next = novoNo;                        // Referência posterior da referência anterior do Nó de referência é o novo Nó
        noReferencia.Next = noReferencia.Prev = null    // Anular a referência posterior e anterior do Nó que será substituido 
    }

    public void SwapElement(T objetoRef1, T objetoRef2)
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> noReferencia1 = Search(objetoRef1);       // Nó de referência 1 que irá troca de lugar com o Nó de referência 2
        No<T> noReferencia2 = Search(objetoRef2);       // Nó de referência 2 que irá troca de lugar com o Nó de referência 1
        No<T> noRefNext1 = noReferencia1.Next;          // Referência posterior do Nó de referência 1
        No<T> noRefPrev1 = noReferencia1.Prev;          // Referência anterior do Nó de referência 1
        No<T> noRefNext2 = noReferencia2.Next;          // Referência posterior do Nó de referência 2
        No<T> noRefPrev2 = noReferencia2.Prev;          // Referência anterior do Nó de referência 2
        No<T> noAuxiliar = noReferencia1                // Nó auxiliar para a operação de troca - Inicializando como Nó de referência 1
        noAuxiliar.Next = noReferencia2.Next            // Referencia posterior do Nó de referência 1 é a referência posterior do Nó de referência 2
        noAuxiliar.Prev = noReferencia2.Prev            // Referencia anterior do Nó de referência 1 é a referência anterior do Nó de referência 2
        noReferencia2.Next = noReferencia1.Next         // Referencia posterior do Nó de referência 2 é a referência posterior do Nó de referência 1
        noReferencia2.Prev = noReferencia1.Prev         // Referencia anterior do Nó de referência 2 é a referência anterior do Nó de referência 1
        noReferencia1 = noAuxiliar;                     // Novas informações para o Nó de referência 1
        noRefNext1.Prev = noReferencia2;                // Referência anterior da referência posterior do Nó de referência 1 é o Nó de referência 2
        noRefPrev1.Next = noReferencia2;                // Referência posterior da referência anterior do Nó de referência 1 é o Nó de referência 2
        noRefNext2.Prev = noReferencia1;                // Referência anterior da referência posterior do Nó de referência 2 é o Nó de referência 1
        noRefPrev2.Next = noReferencia1;                // Referência posterior da referência anterior do Nó de referência 2 é o Nó de referência 1
    }

    public T Remove(T objeto)
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> noRemovido = Search(objeto);              // Encontrar o Nó que será removido
        No<T> noRemoveNext = noRemovido.Next;           // Referência posterior do Nó que será removido
        No<T> noRemovePrev = noRemovido.Prev;           // Referência anterior do Nó que será removido
        noRemoveNext.Prev = noRemovePrev;               // Referência anterior da referência posterior do Nó que será removido é a referência anterior do Nó que será removido
        noRemovePrev.Next = noRemoveNext;               // Referência posterior da referência anterior do Nó que será removido é a referência posterior do Nó que será removido
        noRemovido.Next = noRemovido.Prev = null;       // Anular a referência posterior e anterior do Nó que será removido
        QtdElement--;                                   // Quantidade de elementos -1
        return noRemovido.Objeto;                       // Retorna o elemento do Nó que será removido
    }

    public T First()
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        return Head.Next;                               // Retorna o primeiro Nó da Lista
    }

    public T Last()
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        return Tail.Prev;                               // Retorna o último Nó da Lista
    }

    public bool InFirst(T objeto)
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> noReferencia = Search(objeto);            // Nó de referência que quer saber se está no inicio da Lista
        bool inFirst = false;                           // Váriavel auxiliar para saber se o Nó de referência está no inicio da Lista
        if(Head.Next == noReferencia) inFirst = true;   // Verificação para saber se o Nó de referência está no inicio da Lista
        return inFirst;                                 // Retorna a reposta - TRUE ou FALSE - se o Nó de referência está no inicio da Lista
    }

    public bool InLast(T objeto)
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> noReferencia = Search(objeto);            // Nó de referência que quer saber se está no final da Lista
        bool inLast = false;                            // Váriavel auxiliar para saber se o Nó de referência está no final da Lista
        if(Tail.Prev == noReferencia) inLast = true;    // Verificação para saber se o Nó de referência está no final da Lista
        return inLast;                                  // Retorna a reposta - TRUE ou FALSE - se o Nó de referência está no final da Lista
    }

    public T After(T objeto)
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> noReferencia = Search(objeto);            // Nó de referência para encontrar o próximo Nó a ele
        return noReferencia.Next;                       // Retorna o próximo Nó ao Nó de referência
    }

    public T Before(T objeto)
    {
        if(IsEmpty()) throw new ListaVaziaExcecao();    // Verificar se a Lista está vazia
        No<T> noReferencia = Search(objeto);            // Nó de referência para encontrar o Nó anterior a ele
        return noReferencia.Prev;                                 // Retorna o Nó anterior ao Nó de referência
    }

    public int Size()
    {
        return QtdElement;                              // Retorna a quantidade de Nós da Lista
    }

    public bool IsEmpty()
    {
        return Head.Next == Tail;                       // Verificar se a Lista está vazia
    }

    public T Search(T objeto)
    {
        No<T> atualNo = Head;                                                   // Conseguir uma referência auxiliar do começo da Lista
        while (atualNo.Objeto != objeto)
        {
            atualNo = atualNo.Next                                              // Encontra o Nó que possui o elemento
        }
        if(atualNo.Objeto != objeto) throw new ObjetoNaoEncontradoExcecao();    // Verificar se existi o Nó com o elemento na Lista
        return atualNo;
    }                     
}
```

<br>

### ⏱️ Desempenho das Operações

| Operação                         | Lista Simples | Lista Dupla | Descrição                                                   |
|----------------------------------|---------------|-------------|-------------------------------------------------------------|
| `insertFirst(object)`            | O(1)          | O(1)        | Insere um elemento **X** depois do **Head**                 |
| `insertLast(object)`             | O(1)          | O(1)        | Insere um elemento **X** antes do **Tail**                  |
| `insertAfter(object, object)`    | O(1)          | O(1)        | Insere um elemento **X** depois de um elemento **Y**        |
| `insertBefore(object, object)`   | O(n)          | O(1)        | Insere um elemento **X** antes de um elemento **Y**         |
| `replaceElement(object, object)` | O(n)          | O(1)        | Troca um elemento **X** por um elemento **Y**               |
| `swapElement(object, object)`    | O(n)          | O(1)        | Troca de posição de um elemento **X** por um elemento **Y** |
| `object remove(object)`          | O(n)          | O(1)        | Remove e retorna um elemento **X**                          |
| `object first()`                 | O(1)          | O(1)        | Retorna o **primeiro** elemento                             |
| `object last()`                  | O(n)          | O(1)        | Retorna o **último** elemento                               |
| `boolean inFirst(object)`        | O(1)          | O(1)        | Retorna **True** se o elemento é o **primeiro**             |
| `boolean inLast(object)`         | O(1)          | O(1)        | Retorna **True** se o elemento é o **último**               |
| `object after(object)`           | O(1)          | O(1)        | Retorna o elemento **depois** de um elemento **X**          |
| `object before(object)`          | O(n)          | O(1)        | Retorna o elemento **antes** de um elemento **X**           |
| `interger size()`                | O(1)          | O(1)        | Retorna a quantidade de elementos                           |
| `boolean isEmpty()`              | O(1)          | O(1)        | Verifica se está vazia                                      |
| `object search(object)`          | O(n)          | O(n)        | Encontra um elemento **X**                                  |
