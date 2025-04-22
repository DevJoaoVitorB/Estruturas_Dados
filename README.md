<h1 align="center">Estruturas de Dados Lineares</h1>

<h2>Tipos Abstratos de Dados (TADs)</h2>

  - Abstração de uma Estrutura de Dados descrevendo o seu tipo e suas operações sem especificar como as operações são implementadas. 
  - Especifica:
      1. Dados Armazenados (Estrutura)
      2. Operações sobre os Dados (Comportamentos)
      3. Condições de Erros Associadas à Opers, Operações realizadas em Tipos Abstratos de Dados (Exceções)
  - Exemplo de Funcionamento de um TAD:
      - Sistema de Controle de Estoque
           - Dados -> Pedidos de Compra/Venda.
           - Operações -> `Comprar(produto, preco)`, `Vender(produto, preco)` e `Cancelar(pedido)`.
           - Condições de Erro -> Comprar/Vender Produto inexistente e Cancelar Venda inexistente.
  - Os TADs possibilitam o desenvolvimento de conceitos de estruturas sem a necessidade da ideia da forma como seram implementadas.

<h3 align="center">TAD - Pilha</h3>

  - 📌 Esquema LIFO: Inserção e Remoção de Objetos na Pilha fazendo uso do esquema LIFO (Last In, First Out -> Último a Entra, Primeiro a Sair).

  - 📌 Opers Principais:
      - `push(object)`: Adiciona um elemento `x` ao topo da Pilha.
      - `object pop()`: Remove o elemento do topo da Pilha e retorna o valor.

  - 📌 Opers Auxiliares:
      - `object top()` ou `object peek()`: Apenas retorna o elemento do topo da Pilha.
      - `integer size()`: Retorna o número de elementos armazenados na Pilha.
      - `boolean isEmpty()`: Verifica se a Pilha está vazia.

  - 📌 Exceções no Uso da Pilha:
      - Exceção de Pilha Vazia(*EPilhaVazia*): Causada quando é executado uma operação que depende de ter Objetos na Pilha, como exemplo, o `object pop()` e o `object top()`.
      - Exceção de Pilha Cheia(*EPilhaCheia*): Causada quando é executado uma operação que depende de espaço na Pilha, como exemplo, o `push(object)`.

  - 📌 Exemplos Práticos:
      - Retorno de Página do Browser;
      - O **"Desfazer"** de um Editor de Texto;
      - Algoritmos de Recursão;
      - Componente de Outras Estruturas de Dados.

  - 📌 Implementações:
      - Array: Utilizção de um Vetor/Array para armazenamento dos elementos.
          - Forma + simples de implementação da Pilha.
          - Adiciona elementos no Array da esquerda para a direita.
          - Uso de uma Variável Auxiliar que guarda a Posição/Índice do elemento do topo da Pilha.
          - Desempenho das Opers:
              - `push(object)`: O(1) - Desempenha um fluxo constante de operações sendo a adição do `object` no topo da Pilha(incrementar o índice).
              - `object pop()`: O(1) - Desempenha um fluxo constante de operações sendo a remoção do topo decrementando o índice do topo.
              - `object top()`: O(1) - Desempenha um fluxo constante de operações sendo o retorno do elemento do topo da Pilha.
              - `boolean isEmpty()`: O(1) - Desempenha um fluxo constante de operações sendo a verificação se a Pilha está vazia.
              - `int size()`: O(1) - Desempenha um fluxo constante de operações sendo o retorno da quantidade de elementos da Pilha.
          - Implementação em C#
          > ```csharp
          > class PilhaVaziaExcecao : Exception      // Classe de Exceção de Pilha Vazia
          > {
          >     public PilhaVaziaExcecao() : base("A Pilha está vazia!") {}
          >     public PilhaVaziaExcecao(string mensagem) : base(mensagem) {}
          >     public PilhaVaziaExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
          > }
          > 
          > class Pilha<T>
          > {
          >     private int capacidade;   // Capacidade da PilhaArray
          >     private int topo;         // Atributo de referência do Topo da Pilha
          >     private int FC;           // Fator de Crescimento da PilhaArray - Incremental ou Duplicativa
          >     private T[] pilhaArray;   // Array utilizado como Pilha
          >
          >     public Pilha(int capacidade, int crescimento)
          >     {
          >         this.capacidade = capacidade;    // Definir a capacidade da PilhaArray
          >         topo = -1;                       // Sem elementos na PilhaArray
          >         if(crescimento <= 0) FC = 0;     // Fator de Crescimento por Duplicação
          >         else FC = crescimento;           // Fator de Crescimento por Incrementação
          >         pilhaArray = new T[capacidade];  // Inicializando a PilhaArray
          >     }
          >
          >     public void Push(T objeto)                 // Método de Adicionar Elemento no Topo da Pilha
          >     {
          >         if(topo >= capacidade-1)               // Redimensionamento do tamanho da PilhaArray - Excedeu o Limite
          >         {
          >             if(FC == 0) capacidade *= 2;       // Redimensionamento por Duplicação
          >             else capacidade += FC;             // Redimensionamento por Incrementação
          >
          >             T[] tempArray = new T[capacidade]; // Criação de um Array temporário
          >             for(int i = 0; i < pilhaArray.Length; i++)
          >             {
          >                 tempArray[i] = pilhaArray[i];  // Colocar os elementos do antigo Array (pilhaArray) para o novo Array (tempArray)
          >             }
          >             pilhaArray = tempArray;            // pilhaArray passa a ser o novo Array
          >         }
          >         pilhaArray[++topo] = objeto;           // Adicionar o novo elemento a PilhaArray
          >     }
          >
          >     public T Pop()                                  // Método de Remover Elemento do Topo da Pilha
          >     {
          >         if(IsEmpty()) throw new PilhaVaziaExcecao;  // Verificar se a PilhaArray está Vazia
          >         T removido = pilhaArray[topo--];            // Remover o elemento do Topo da PilhaArray
          >         return removido;                            // Retorna o elemento removido
          >     }
          >
          >     public T Top()                                  // Método de Retorno do Elemento do Topo da Pilha
          >     {
          >         if(IsEmpty()) throw new PilhaVaziaExcecao;  // Verificar se a PilhaArray está Vazia
          >         return pilhaArray[topo];                    // Retorna o elemento do Topo
          >     }
          >
          >     public bool IsEmpty()                      // Método de Verificar se a Pilha está Vazia
          >     {
          >         return topo == -1;                     // Verificar se a Topo da PilhaArray é igual a -1, ou seja, está Vazia
          >     }
          >
          >     public int Size()                          // Método de Retorna a Quantidade de Elementos da Pilha
          >     {
          >         return topo + 1;                       // Retorna a quantidade de elementos da PilhaArray
          >     }
          > }

  - 📌 Limitações das Pilhas Baseadas em Arrays:
      - Capacidade Fixa: O Array possui uma capacidade fixa, ou seja, ao atingir seu limite operações como o `push(object)` são inviáveis gerando problemas de **Overflow**. Dessa forma, é necessário implementar uma estratégia de redimensionamento do tamanho do Array.
      - Espaço não Utilizado: Inicialmente com a Pilha parcialmente vazia o espaço de memória reservado está sendo desperdiçado.

  - 📌 Estratégias para Redimensionanto de Pilhas
      - Quando o Array está cheio, ao invés de levantar uma exceção, acontece a subtituição de Array por um maior. 
      - Estratégia Incremental: Essa estratégia utiliza do aumento da capacidade do Array por um valor fixo cada vez que esse Array fica sem espaço. Embora seja simples, essa estratégia a longo prazo para um crescimento exponencial da Pilha pode causar ineficiência devido a alta alocação de memória.
          - Substituímos o Array `k = n/c` vezes (`k` = Quantidades de Subtituições; `n` = Quantidade de Elementos; `c` = Constante de Aumento do Array).
