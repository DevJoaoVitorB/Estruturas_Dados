<h1 align="center">📚 TAD - Pilha</h1>
<p align="center">🎯 <strong>Estrutura LIFO (Last In, First Out)</strong></p>
<p align="center">⚠️ Elemento <strong>inserido por último</strong> é o <strong>primeiro a ser removido</strong>.</p>

## 🔧 Operações Principais

* `push(object)` → Adiciona um elemento ao **topo**.
* `object pop()` → Remove e retorna o elemento do **topo** da pilha.

## 🧰 Operações Auxiliares

* `object top()` ou `object peek()` → Retorna o elemento do topo **sem remover**.
* `integer size()` → Retorna o **número de elementos** na pilha.
* `boolean isEmpty()` → Verifica se a pilha está **vazia**.

<br>

## ⚠️ Exceções

* **EPilhaVazia:** Tentativa de `pop()` ou `top()` com a pilha vazia.
* **EPilhaCheia:** Tentativa de `push()` em uma pilha sem espaço disponível.

<br>

## 🛠️ Exemplos Práticos

* Navegação de páginas no **browser** (voltar)
* Botão **Desfazer** em editores de texto
* Execução de **algoritmos recursivos**
* Parte integrante de **outras estruturas de dados**

<br>

## 🧱 Implementação Usando Array (Pilhas baseadas em Arrays)

> Utiliza-se um **vetor/array** como estrutura de armazenamento.

* Forma **simples** de implementação
* Elementos são adicionados da **esquerda para a direita**
* Uso de uma **variável auxiliar** que armazena o índice do topo

<br>

### ⏱️ Desempenho das Operações

| Operação            | Complexidade | Descrição |
|---------------------|--------------|-----------|
| `push(object)`      | O(1)         | Adiciona no topo (incrementa índice) |
| `object pop()`      | O(1)         | Remove do topo (decrementa índice)   |
| `object top()`      | O(1)         | Retorna o topo                       |
| `integer size()`    | O(1)         | Retorna a quantidade de elementos    |
| `boolean isEmpty()` | O(1)         | Verifica se está vazia               |

<br>

### ⚠️ Limitações das Pilhas Baseadas em Arrays

* **Capacidade Fixa**: Arrays possuem capacidade fixa. Quando a pilha atinge seu limite, operações como `push(object)` se tornam inviáveis, gerando problemas de **overflow**.
* **Espaço Desperdiçado**: Inicialmente, o array reserva um espaço fixo de memória, que pode não ser totalmente utilizado quando a pilha está parcialmente vazia.

> ⚠️ Por isso, para garantir a eficiência e escalabilidade das pilhas, são implementadas estratégias de **redimensionamento dinâmico**.

<br>

### 🔃 Estratégias de Redimensionamento

Ao atingir a capacidade máxima, o array da pilha é substituído por um novo array maior. As duas principais estratégias são:

### 1. Estratégia Incremental

* ❓ **Como funciona?**
  * Aumenta a capacidade do array em um valor fixo `c` a cada vez que ele fica cheio.
  * Simples de implementar, mas pode ser ineficiente quando `n` cresce muito.

* 📊 **Análise Matemática**
  * A cada `c` inserções, é necessário realocar um novo array maior e copiar os elementos antigos.
  * Se fizermos `n` operações `push`, teremos `k = n / c` redimensionamentos.
  * O custo total será:

```math
T(n) = n + c + 2c + 3c + \dots + kc
     = n + c(1 + 2 + 3 + \dots + k)
     = n + c \cdot \frac{k(k+1)}{2}
```
---

> [!WARNING]
> Substituindo `k = n / c`:
> ```math
> T(n) = n + c \cdot \frac{(n/c)(n/c + 1)}{2} = O(n + n^2/c) = O(n^2)
> ```

---

* ⏲️ **Tempo Amortizado:**

```math
\frac{T(n)}{n} = O(n)
```

* 📋 **Resumo**:
  * Redimensiona linearmente, mas tem custo **quadrático total**.
  * Ineficiente para muitos elementos.

<br>

### 2. Estratégia Duplicativa (Exponencial)

* ❓ **Como funciona?**
  * A cada vez que o array fica cheio, sua capacidade é duplicada.
  * Mais eficiente para crescimento exponencial da pilha.

* 📊 **Análise Matemática**
  * O número de redimensionamentos será `k = log₂(n)`.
  * A cada redimensionamento, o custo de cópia é proporcional ao tamanho anterior:

```math
T(n) = n + 1 + 2 + 4 + 8 + \dots + 2^k
```

---

> [!WARNING]
> Essa é uma **progressão geométrica**, cuja soma é:
> ```math
>  1 + 2 + 4 + \dots + 2^k = 2^{k+1} - 1 \leq 2n - 1
> ```
> Então:
> ```math
> T(n) \leq n + (2n - 1) = 3n - 1 = O(n)
> ```

---

* ⏲️ **Tempo Amortizado:**

```math
\frac{T(n)}{n} = O(1)
```

* 📋 **Resumo**:
  * Redimensiona exponencialmente.
  * Muito mais eficiente: custo total linear e tempo amortizado constante.

##### 📊 Comparativo Final

| Estratégia        | T(n) Total     | Tempo Amortizado  | Eficiência  |
|-------------------|----------------|-------------------|-------------|
| Incremental       | `O(n²)`        | `O(n)`            | Baixa       |
| Duplicativa       | `O(n)`         | `O(1)`            | Alta        |

<br>

### ✏️ Implementação em C#
```csharp
using System;

class PilhaVaziaExcecao : Exception         // Classe de Exceção de Pilha Vazia
{
    public PilhaVaziaExcecao() : base("A Pilha está vazia!") {}
    public PilhaVaziaExcecao(string mensagem) : base(mensagem) {}
    public PilhaVaziaExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}

interface Pilha<T>                          // Interface com os Métodos de uma Pilha
{
    void Push(T objeto);                      // Método para Adicionar Elemento no Topo da Pilha
    T Pop();                                  // Método para Remover Elemento do Topo da Pilha
    T Top();                                  // Método de Retorno do Elemento do Topo da Pilha
    int Size();                               // Método de Retorno da Quantidade de Elementos da Pilha
    bool IsEmpty();                           // Método para Verificar se a Pilha está Vazia
}
 
class PilhaArray<T> : Pilha<T>
{
    private int Topo;         // Atributo de referência do Topo da Pilha
    private int FC;           // Fator de Crescimento da PilhaArray - Incremental ou Duplicativa
    private int Capacidade;   // Capacidade da PilhaArray
    private T[] ArrayPilha;   // Array utilizado como Pilha

    public PilhaArray(int capacidade, int crescimento)
    {
        Capacidade = capacidade;          // Definir a capacidade da PilhaArray
        Topo = -1;                        // Sem elementos na PilhaArray
        if(crescimento <= 0) FC = 0;      // Fator de Crescimento por Duplicação
        else FC = crescimento;            // Fator de Crescimento por Incrementação
        ArrayPilha = new T[Capacidade];   // Inicializando a PilhaArray
    }

    public void Push(T objeto)
    {
        if(Topo >= Capacidade-1)                // Redimensionamento do tamanho da PilhaArray - Excedeu o Limite
        {
            if(FC == 0) Capacidade *= 2;          // Redimensionamento por Duplicação
            else Capacidade += FC;                // Redimensionamento por Incrementação

            T[] tempArray = new T[Capacidade];    // Criação de um Array temporário
            for(int i = 0; i < ArrayPilha.Length; i++)
            {
              tempArray[i] = ArrayPilha[i];       // Colocar os elementos do antigo Array (ArrayPilha) para o novo Array (tempArray)
            }
            ArrayPilha = tempArray;               // tempArray passa a ser o novo Array
        }
        ArrayPilha[++Topo] = objeto;            // Adicionar o novo elemento a PilhaArray
    }

    public T Pop()
    {
        if(IsEmpty()) throw new PilhaVaziaExcecao();  // Verificar se a PilhaArray está Vazia
        T removido = ArrayPilha[Topo--];              // Remover o elemento do Topo da PilhaArray
        return removido;                              // Retorna o elemento removido
    }

    public T Top()
    {
        if(IsEmpty()) throw new PilhaVaziaExcecao();  // Verificar se a PilhaArray está Vazia
        return ArrayPilha[Topo];                      // Retorna o elemento do Topo
    }

    public int Size()
    {
        return Topo + 1;                       // Retorna a quantidade de elementos da PilhaArray
    }

    public bool IsEmpty()
    {
        return Topo == -1;                     // Verificar se a Topo da PilhaArray é igual a -1, ou seja, está Vazia
    }
}
```
