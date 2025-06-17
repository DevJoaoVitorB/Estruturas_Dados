<h1 align="center">🗂️ TAD - Lista</h1>
<p align="center">🎯 <strong>Estrutura Linear com Inserção/Remoção Flexível</strong></p>
<p align="center">⚠️ Acesso sequencial com operações em qualquer posição (complexidade O(n) para buscas)</p>

## 🌍 Analogia do Mundo Real:
Imagine um comboio ferroviário com terminais especiais:
- **Estação Inicial (Head)**: Marco de início vazio, apenas sinaliza o ponto de partida
- **Estação Final (Tail)**: Marco de término vazio, apenas sinaliza o ponto final
- **Vagões Reais**: Transportam passageiros (dados) entre as estações terminais
- **Operações**:
  - Adicionar vagões em qualquer posição
  - Remover vagões específicos
  - Nunca modificamos as estações terminais

<br>

## 🔧 Operações Principais

* `insertFirst(object)` → Insere elemento no início
  - **Comportamento**: Adiciona após o nó head
  - **Pré-condição**: Nenhuma
  - **Pós-condição**: Tamanho aumenta em 1

* `insertLast(object)` → Insere elemento no final
  - **Comportamento**: Adiciona antes do nó tail
  - **Pré-condição**: Nenhuma
  - **Pós-condição**: Tamanho aumenta em 1

* `insertAfter(object, object)` → Insere após elemento existente
  - **Comportamento**: Busca elemento e insere novo nó após ele
  - **Pré-condição**: Elemento de referência deve existir
  - **Pós-condição**: Tamanho aumenta em 1

* `insertBefore(object, object)` → Insere antes de elemento existente
  - **Comportamento**: Busca elemento e insere novo nó antes dele
  - **Pré-condição**: Elemento de referência deve existir
  - **Pós-condição**: Tamanho aumenta em 1

* `object replaceElement(object, object)` → Substitui elemento
  - **Comportamento**: Busca e substitui valor do nó
  - **Pré-condição**: Elemento a ser substituído deve existir
  - **Pós-condição**: Valor alterado, tamanho mantido

* `swapElement(object, object)` → Troca posição de elementos
  - **Comportamento**: Busca dois elementos e troca seus valores
  - **Pré-condição**: Ambos elementos devem existir
  - **Pós-condição**: Valores trocados, estrutura inalterada

* `object remove(object)` → Remove elemento específico
  - **Comportamento**: Busca e remove nó, ajustando referências
  - **Pré-condição**: Elemento deve existir
  - **Pós-condição**: Tamanho diminui em 1

<br>

## 🧰 Operações Auxiliares

* `object first()` → Retorna primeiro elemento real
  - **Detalhe**: Retorna head.Proximo.Dado
  - **Pré-condição**: Lista não vazia

* `object last()` → Retorna último elemento real
  - **Detalhe**: Retorna tail.Anterior.Dado
  - **Pré-condição**: Lista não vazia

* `boolean isFirst(object)` → Verifica se é o primeiro
  - **Critério**: elemento == head.Proximo.Dado

* `boolean isLast(object)` → Verifica se é o último
  - **Critério**: elemento == tail.Anterior.Dado

* `object after(object)` → Retorna próximo elemento
  - **Comportamento**: Busca elemento e retorna seu sucessor
  - **Pré-condição**: Elemento existe e não é o último

* `object before(object)` → Retorna elemento anterior
  - **Comportamento**: Busca elemento e retorna seu predecessor
  - **Pré-condição**: Elemento existe e não é o primeiro

* `integer size()` → Retorna número de elementos válidos
  - **Exclusão**: Não conta nós sentinelas

* `boolean isEmpty()` → Verifica se está vazia
  - **Critério**: tamanho == 0

* `object search(object)` → Busca elemento
  - **Área de Busca**: Apenas entre head e tail (exclusivo)
  - **Retorno**: Elemento encontrado ou null

<br>

## ⚠️ Exceções (Tratamento de Erros)

* **EListaVazia:** 
  - Lançada em first/last/remove com lista vazia
  - **Causa**: Tentativa de acessar dados quando size == 0

* **EElementoNaoEncontrado:** 
  - Lançada em operações de busca
  - **Causa**: Elemento não existe entre os sentinelas

* **EOperacaoInvalidaSentinelas:** 
  - Lançada se tentar remover/modificar head/tail
  - **Causa**: Tentativa de alterar nós sentinelas

<br>

## 🛠️ Exemplos Práticos (Aplicações Reais)

1. **Editores de Texto**:
   - Buffer de texto com navegação eficiente
   - Operações de undo/redo

2. **Navegadores Web**:
   - Gerenciamento de abertas com histórico
   - Session storage

3. **Sistemas de Arquivos**:
   - Navegação em diretórios
   - Listagem ordenada de arquivos

4. **Jogos Digitais**:
   - Inventários dinâmicos
   - Sequência de ações do jogador

<br>

## 🧱 Implementação com Sentinelas

### 🔧 Estrutura Básica

- **Componentes:**
    - Nodo head: Sentinela inicial (dado = null)
    - Nodo tail: Sentinela final (dado = null)
    - int tamanho: Contagem de elementos válidos

    ```text
    [HEAD] ⇄ (elemento1) ⇄ (elemento2) ⇄ ... ⇄ [TAIL]
    ```
  
<br>

### ⚙️ Modo de Funcionamento

#### 1. **Inicialização:**
* Dois nós sentinelas criados (`head` e `tail`)
* `head.Proximo` aponta para `tail`
* `tail.Anterior` aponta para `head`
* `tamanho` inicializado em 0
  ```text
  [HEAD] ⇄ [TAIL]
  ```

#### 2. **Operações Básicas:**
* **Inserção no Início (InsertFirst):**
  * Novo nó criado após head
  * Ajusta ponteiros:
  ```text
  [HEAD] ⇄ [NOVO] ⇄ [OLD_FIRST]...
  ```

* **Inserção no Fim (InsertLast):**
  * Novo nó criado antes de tail
  * Ajusta ponteiros:
  ```text
  ... ⇄ [OLD_LAST] ⇄ [NOVO] ⇄ [TAIL]
  ```

* **Inserção no Meio:**
  * Localiza nó de referência
  * Novo nó ligado entre anterior e referência

* **Remoção**:
  * Remove o nó trocando a referência dos nós de referência
  * Ajusta ponteiros:
  ```text
  ... ⇄ [PREV] ⇄ [REMOVE] ⇄ [NEXT] ⇄ ...
  ... ⇄ [PREV] ⇄ [NEXT] ⇄ ...
  ```

* **Troca de Elementos:**
  * Troca o elemento do nó de referência por um novo

* **Substituição de Elementos:**
  * Substitui o elemento do nó de referência por outro da lista

#### 3. **Controle de Estado:**
* **`Size()`** - contador tamanho
* **`IsEmpty()`** - tamanho == 0
* **`Search()`** - Percorre da head.Proximo até tail

<br>

### ⏱️ Desempenho das Operações
| Operação                              | Complexidade |	Descrição           |
|---------------------------------------|--------------|----------------------|
| insertFirst(object)	                  | O(1)         | Inserção no início   |
| insertLast(object)	                  | O(1)	       | Inserção no final    |
| insertAfter(object, object)	          | O(n)	       | Busca + Inserção     |
| insertBefore(object, object)          | O(n)	       | Busca + Inserção     |
| object replaceElement(object, object) | O(n)	       | Busca + Substituição |
| swapElement(object, object)	          | O(n)	       | Busca + Troca        |
| object remove(object)	                | O(n)	       | Busca + Remoção      |
| object first()	                      | O(1)	       | Acesso ao primeiro   |
| object last()	                        | O(1)	       | Acesso ao último     |
| boolean isFirst(object)	              | O(1)	       | Verificar primeiro   |
| boolean isLast(object)	              | O(1)	       | Verificar último     |
| object after(object)	                | O(n)	       | Busca + Acesso       |
| object before(object)	                | O(n)	       | Busca + Acesso       |
| interger size()	                      | O(1)	       | Retorna contador     |
| boolean isEmpty()	                    | O(1)	       | Verifica contador    |
| object search(object)	                | O(n)	       | Percorre lista       |

### ✏️ Implementação Completa em C#
```csharp
using System;

// Exceções customizadas
public class ListaVaziaException : InvalidOperationException {
    public ListaVaziaException() : base("Lista vazia") {}
    public ListaVaziaException(string mensagem) : base(mensagem) {}
}

public class ElementoNaoEncontradoException : InvalidOperationException {
    public ElementoNaoEncontradoException(object elemento) 
        : base($"Elemento {elemento} não encontrado") {}
    public ElementoNaoEncontradoException(string mensagem) : base(mensagem) {}
}

// Interface do TAD Lista
public interface ILista<T> where T : IEquatable<T> {
    void InsertFirst(T elemento);
    void InsertLast(T elemento);
    void InsertAfter(T referencia, T elemento);
    void InsertBefore(T referencia, T elemento);
    T ReplaceElement(T antigo, T novo);
    void SwapElement(T elem1, T elem2);
    T Remove(T elemento);
    T First();
    T Last();
    bool IsFirst(T elemento);
    bool IsLast(T elemento);
    T After(T elemento);
    T Before(T elemento);
    int Size();
    bool IsEmpty();
    T Search(T elemento);
}

private class Nodo {
    public T Dado { get; set; }
    public Nodo Anterior { get; set; }
    public Nodo Proximo { get; set; }

    public Nodo(T dado) {
        Dado = dado;
    }
}

// Implementação concreta usando lista duplamente ligada
public class ListaDuplamenteEncadeada<T> : ILista<T> where T : IEquatable<T> {
    private readonly Nodo head;
    private readonly Nodo tail;
    private int tamanho;

    public ListaDuplamenteEncadeada() {
        head = new Nodo(default(T));
        tail = new Nodo(default(T));
        head.Proximo = tail;
        tail.Anterior = head;
        tamanho = 0;
    }

    public int Size() => tamanho;
    public bool IsEmpty() => tamanho == 0;

    public void InsertFirst(T elemento) {
        Nodo novo = new Nodo(elemento);
        novo.Anterior = head;
        novo.Proximo = head.Proximo;
        
        head.Proximo.Anterior = novo;
        head.Proximo = novo;
        tamanho++;
    }

    public void InsertLast(T elemento) {
        Nodo novo = new Nodo(elemento);
        novo.Proximo = tail;
        novo.Anterior = tail.Anterior;
        
        tail.Anterior.Proximo = novo;
        tail.Anterior = novo;
        tamanho++;
    }

    public void InsertAfter(T referencia, T elemento) {
        Nodo alvo = BuscarNodo(referencia);
        if (alvo == null || alvo == tail) 
            throw new ElementoNaoEncontradoException(referencia);

        Nodo novo = new Nodo(elemento);
        novo.Anterior = alvo;
        novo.Proximo = alvo.Proximo;
        
        alvo.Proximo.Anterior = novo;
        alvo.Proximo = novo;
        tamanho++;
    }

    public void InsertBefore(T referencia, T elemento) {
        Nodo alvo = BuscarNodo(referencia);
        if (alvo == null || alvo == head) 
            throw new ElementoNaoEncontradoException(referencia);

        Nodo novo = new Nodo(elemento);
        novo.Proximo = alvo;
        novo.Anterior = alvo.Anterior;
        
        alvo.Anterior.Proximo = novo;
        alvo.Anterior = novo;
        tamanho++;
    }

    public T ReplaceElement(T antigo, T novo) {
        Nodo alvo = BuscarNodo(antigo);
        if (alvo == null || alvo == head || alvo == tail)
            throw new ElementoNaoEncontradoException(antigo);

        T dadoAntigo = alvo.Dado;
        alvo.Dado = novo;
        return dadoAntigo;
    }

    public void SwapElement(T elem1, T elem2) {
        if (elem1.Equals(elem2)) return;

        Nodo nodo1 = BuscarNodo(elem1);
        Nodo nodo2 = BuscarNodo(elem2);

        if (nodo1 == null || nodo1 == head || nodo1 == tail || 
            nodo2 == null || nodo2 == head || nodo2 == tail) {
            throw new ElementoNaoEncontradoException(nodo1 == null ? elem1 : elem2);
        }

        T temp = nodo1.Dado;
        nodo1.Dado = nodo2.Dado;
        nodo2.Dado = temp;
    }

    public T Remove(T elemento) {
        Nodo alvo = BuscarNodo(elemento);
        if (alvo == null || alvo == head || alvo == tail)
            throw new ElementoNaoEncontradoException(elemento);

        alvo.Anterior.Proximo = alvo.Proximo;
        alvo.Proximo.Anterior = alvo.Anterior;
        tamanho--;

        return alvo.Dado;
    }

    public T First() {
        if (IsEmpty()) throw new ListaVaziaException();
        return head.Proximo.Dado;
    }

    public T Last() {
        if (IsEmpty()) throw new ListaVaziaException();
        return tail.Anterior.Dado;
    }

    public bool IsFirst(T elemento) {
        if (IsEmpty()) return false;
        return head.Proximo.Dado.Equals(elemento);
    }

    public bool IsLast(T elemento) {
        if (IsEmpty()) return false;
        return tail.Anterior.Dado.Equals(elemento);
    }

    public T After(T elemento) {
        Nodo alvo = BuscarNodo(elemento);
        if (alvo == null || alvo == tail || alvo.Proximo == tail)
            throw new ElementoNaoEncontradoException(elemento);

        return alvo.Proximo.Dado;
    }

    public T Before(T elemento) {
        Nodo alvo = BuscarNodo(elemento);
        if (alvo == null || alvo == head || alvo.Anterior == head)
            throw new ElementoNaoEncontradoException(elemento);

        return alvo.Anterior.Dado;
    }

    public T Search(T elemento) {
        Nodo atual = head.Proximo;
        while (atual != tail) {
            if (atual.Dado.Equals(elemento)) {
                return atual.Dado;
            }
            atual = atual.Proximo;
        }
        return default(T);
    }

    private Nodo BuscarNodo(T elemento) {
        Nodo atual = head.Proximo;
        while (atual != tail) {
            if (atual.Dado.Equals(elemento)) {
                return atual;
            }
            atual = atual.Proximo;
        }
        return null;
    }
}
```
