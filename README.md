<h1 align="center">🧠 Tipos Abstratos de Dados (TADs)</h1>
<p align="center"><strong>TAD (Tipo Abstrato de Dado)</strong> é a <strong>abstração de uma estrutura de dados</strong>, descrevendo seu tipo e operações, <strong>sem especificar como essas operações são implementadas</strong>.</p> 

## 📌 O que um TAD Especifica?

1. **Dados Armazenados** (estrutura dos dados)
2. **Operações sobre os Dados** (comportamentos)
3. **Condições de Erro** associadas às operações (exceções)

> 📓 Os TADs permitem a construção de estruturas **sem a preocupação com sua implementação interna**.

<br>

## 💡 Exemplo: Sistema de Controle de Estoque

- **Dados:** Pedidos de Compra/Venda
- **Operações:**
  - `Comprar(produto, preco)`
  - `Vender(produto, preco)`
  - `Cancelar(pedido)`
- **Condições de Erro:**
  - Comprar/Vender produto inexistente
  - Cancelar venda inexistente

<br>

<h2 align="center">📚 TAD - Pilha</h2>
<p align="center">🎯 <strong>Estrutura LIFO (Last In, First Out)</strong></p>
<p align="center">⚠️ Elemento <strong>inserido por último</strong> é o <strong>primeiro a ser removido</strong>.</p>


### 🔧 Operações Principais

- `push(object)` → Adiciona um elemento ao **topo** da pilha.
- `object pop()` → Remove e retorna o elemento do **topo** da pilha.


### 🧰 Operações Auxiliares

- `object top()` ou `object peek()` → Retorna o elemento do topo **sem remover**.
- `integer size()` → Retorna o **número de elementos** na pilha.
- `boolean isEmpty()` → Verifica se a pilha está **vazia**.

<br>

### ⚠️ Exceções

- **EPilhaVazia:** Tentativa de `pop()` ou `top()` com a pilha vazia.
- **EPilhaCheia:** Tentativa de `push()` em uma pilha sem espaço disponível.

<br>

### 🛠️ Exemplos Práticos

- Navegação de páginas no **browser** (voltar)
- Botão **Desfazer** em editores de texto
- Execução de **algoritmos recursivos**
- Parte integrante de **outras estruturas de dados**

<br>

### 🧱 Implementação Usando Array (Pilhas baseadas em Arrays)

> Utiliza-se um **vetor/array** como estrutura de armazenamento.

- Forma **simples** de implementação
- Elementos são adicionados da **esquerda para a direita**
- Uso de uma **variável auxiliar** que armazena o índice do topo

<br>

#### ⏱️ Desempenho das Operações

| Operação         | Complexidade | Descrição |
|------------------|--------------|-----------|
| `push(object)`   | O(1)         | Adiciona no topo (incrementa índice) |
| `object pop()`   | O(1)         | Remove do topo (decrementa índice)   |
| `object top()`   | O(1)         | Retorna o topo                       |
| `isEmpty()`      | O(1)         | Verifica se está vazia               |
| `size()`         | O(1)         | Retorna a quantidade de elementos    |

<br>

#### ⚠️ Limitações das Pilhas Baseadas em Arrays

- **Capacidade Fixa**: Arrays possuem capacidade fixa. Quando a pilha atinge seu limite, operações como `push(object)` se tornam inviáveis, gerando problemas de **overflow**.
- **Espaço Desperdiçado**: Inicialmente, o array reserva um espaço fixo de memória, que pode não ser totalmente utilizado quando a pilha está parcialmente vazia.

> ⚠️ Por isso, para garantir a eficiência e escalabilidade das pilhas, são implementadas estratégias de **redimensionamento dinâmico**.

<br>

#### 🔃 Estratégias de Redimensionamento

Ao atingir a capacidade máxima, o array da pilha é substituído por um novo array maior. As duas principais estratégias são:

#### 1. Estratégia Incremental

- ❓ **Como funciona?**
  - Aumenta a capacidade do array em um valor fixo `c` a cada vez que ele fica cheio.
  - Simples de implementar, mas pode ser ineficiente quando `n` cresce muito.

- 📊 **Análise Matemática**
  - A cada `c` inserções, é necessário realocar um novo array maior e copiar os elementos antigos.
  - Se fizermos `n` operações `push`, teremos `k = n / c` redimensionamentos.
  - O custo total será:

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

- ⏲️ **Tempo Amortizado:**

```math
T(n)/n = O(n)
```

- 📋 **Resumo**:
  - Redimensiona linearmente, mas tem custo **quadrático total**.
  - Ineficiente para muitos elementos.

<br>

#### 2. Estratégia Duplicativa (Exponencial)

- ❓ **Como funciona?**
  - A cada vez que o array fica cheio, sua capacidade é duplicada.
  - Mais eficiente para crescimento exponencial da pilha.

- 📊 **Análise Matemática**
  - O número de redimensionamentos será `k = log₂(n)`.
  - A cada redimensionamento, o custo de cópia é proporcional ao tamanho anterior:

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

- ⏲️ **Tempo Amortizado:**

```math
T(n)/n = O(1)
```

- 📋 **Resumo**:
  - Redimensiona exponencialmente.
  - Muito mais eficiente: custo total linear e tempo amortizado constante.

##### 📊 Comparativo Final

| Estratégia       | T(n) Total     | Tempo Amortizado | Eficiência |
|-------------------|----------------|-------------------|-------------|
| Incremental       | `O(n^2)`       | `O(n)`            | Baixa       |
| Duplicativa       | `O(n)`         | `O(1)`            | Alta        |

<br>

#### ✏️ Implementação em C#
```csharp
class PilhaVaziaExcecao : Exception      // Classe de Exceção de Pilha Vazia
{
     public PilhaVaziaExcecao() : base("A Pilha está vazia!") {}
     public PilhaVaziaExcecao(string mensagem) : base(mensagem) {}
     public PilhaVaziaExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}
 
class Pilha<T>
{
    private int capacidade;   // Capacidade da PilhaArray
    private int topo;         // Atributo de referência do Topo da Pilha
    private int FC;           // Fator de Crescimento da PilhaArray - Incremental ou Duplicativa
    private T[] pilhaArray;   // Array utilizado como Pilha

    public Pilha(int capacidade, int crescimento)
    {
        this.capacidade = capacidade;    // Definir a capacidade da PilhaArray
        topo = -1;                       // Sem elementos na PilhaArray
        if(crescimento <= 0) FC = 0;     // Fator de Crescimento por Duplicação
        else FC = crescimento;           // Fator de Crescimento por Incrementação
        pilhaArray = new T[capacidade];  // Inicializando a PilhaArray
    }

    public void Push(T objeto)                 // Método de Adicionar Elemento no Topo da Pilha
    {
        if(topo >= capacidade-1)               // Redimensionamento do tamanho da PilhaArray - Excedeu o Limite
        {
            if(FC == 0) capacidade *= 2;       // Redimensionamento por Duplicação
            else capacidade += FC;             // Redimensionamento por Incrementação

            T[] tempArray = new T[capacidade]; // Criação de um Array temporário
            for(int i = 0; i < pilhaArray.Length; i++)
            {
                tempArray[i] = pilhaArray[i];  // Colocar os elementos do antigo Array (pilhaArray) para o novo Array (tempArray)
            }
            pilhaArray = tempArray;            // pilhaArray passa a ser o novo Array
        }
        pilhaArray[++topo] = objeto;           // Adicionar o novo elemento a PilhaArray
    }

    public T Pop()                                  // Método de Remover Elemento do Topo da Pilha
    {
        if(IsEmpty()) throw new PilhaVaziaExcecao;  // Verificar se a PilhaArray está Vazia
        T removido = pilhaArray[topo--];            // Remover o elemento do Topo da PilhaArray
        return removido;                            // Retorna o elemento removido
    }

    public T Top()                                  // Método de Retorno do Elemento do Topo da Pilha
    {
        if(IsEmpty()) throw new PilhaVaziaExcecao;  // Verificar se a PilhaArray está Vazia
        return pilhaArray[topo];                    // Retorna o elemento do Topo
    }

    public bool IsEmpty()                      // Método de Verificar se a Pilha está Vazia
    {
        return topo == -1;                     // Verificar se a Topo da PilhaArray é igual a -1, ou seja, está Vazia
    }

    public int Size()                          // Método de Retorna a Quantidade de Elementos da Pilha
    {
        return topo + 1;                       // Retorna a quantidade de elementos da PilhaArray
    }
}
```
> ✅ **Resumo:** TADs, como a pilha, facilitam a construção de sistemas robustos por meio da **separação entre interface e implementação**.
