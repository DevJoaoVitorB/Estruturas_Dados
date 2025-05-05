
<h1 align="center">📚 TAD - Lista</h1>
<p align="center">🎯 <strong>Estrutura Sequencial Linear Abstrata</strong></p>
<p align="center">⚠️ Permite inserções, remoções e acessos em posições arbitrárias.</p>

## 🔧 Operações Principais
- `insertFirst(object)` → Insere um elemento no **início** da lista.
- `insertLast(object)` → Insere um elemento no **final** da lista.
- `insertAfter(object, object)` → Insere elemento **depois** de outro elemento.
- `insertBefore(object, object)` → Insere um elemento **antes** de outro elemento.
- `replaceElement(object, object)` → Substitui um **elemento antigo** por um **elemento novo**.
- `swapElement(object, object)` → Troca um elemento com outro elemento.
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
- `object search(object)` → Retorna o **elemento** se ele existi.

<br>

## ⚠️ Exceções

- **EListaVazia:** Tentativa de remoção, troca ou retorno com a lista vazia.
- **EPosicaoInvalida:** A posição fornecida não existe na lista.
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

- Operações `before()` e `after()` são **eficientes**
- Fácil de percorrer nos dois sentidos
- Remoções e trocas de elementos são mais diretas

<br>

### ❌ Limitações

- Ocupa **mais memória** por conta do ponteiro extra
- Levemente mais complexa de implementar

<br>

### ✏️ Implementação em C#
```csharp

```

<br>

### ⏱️ Desempenho das Operações

| Operação                         | Lista Simples | Lista Dupla | Descrição |
|----------------------------------|---------------|-------------|-----------|
| `insertFirst(object)`            | O(1)          | O(1)        | |
| `insertLast(object)`             | O(1) ou O(n)  | O(1)        | |
| `insertAfter(object, object)`    | O(1)          | O(1)        | |
| `insertBefore(object, object)`   | O(n)          | O(1)        | |
| `replaceElement(object, object)` | | | |
| `swapElement(object, object)`    | | | |
| `object remove(object)`          | O(n)          | O(1)        | |
| `object first()`                 | O(1)          | O(1)        | |
| `object last()`                  | O(1)          | O(1)        | |
| `boolean inFirst(object)`        | | | |
| `boolean inLast(object)`         | | | |
| `object after(object)`           | O(1)          | O(1)        | |
| `object before(object)`          | O(n)          | O(1)        | |
| `interger size()`                | O(1) ou O(n)  | O(1) ou O(n)| |
| `boolean isEmpty()`              | O(1)          | O(1)        | |
| `object search(object)`          | O(n)          | O(n)        | |
