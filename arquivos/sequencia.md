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
| `replaceAtRank(integer, object)`        | O(1)          | O(n)                    | Substitui o **elemento** na **posição X** da sequência por outro **elemento** |
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
