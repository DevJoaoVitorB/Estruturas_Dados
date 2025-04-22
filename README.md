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

> [!NOTE]
> ```
>      Algoritmo size()
>          retorne t + 1            # Retorna a variavel t + 1 que indica a quantidade de elementos do Array.
>                                   # variavel t contem o último índice ocupado do Array.
>
>     Algoritmo push(x)
>          Se (t = S.length - 1)    # Verifica se o último índice guardado na variavel t é = ao tamanho desse Array 
>              throw EPilhaCheia    # Retorna uma excessão "EPilhaCheia" caso a expressão lógica seja True
>          Senão                    # Caso contrário, ou seja, a expresão lógica seja False
>              t ← t + 1            # O valor armazenado em t passa a ser o próximo índice livre do Array
>              S[t] ← x             # Por fim, o valor x é armazenado nesse índice 
>
>      Algoritmo pop()               
>          Se (estaVazia())        # Verifica se a Pilha está Vazia
>              throw EPilhaVazia   # Retorna uma excessão "EPilhaVazia" caso a expressão lógica seja True
>          Senão                   # Caso contrário, ou seja, a expresão lógica seja False
>              t ← t - 1           # O valor armazenado em t passa a ser o índice anterior ao atual do Array 
>              retorne S[t + 1]    # Por fim, retorna o antigo último alor do Array
> ```

  - 📌 Limitações das Pilhas Baseadas em Arrays:
      - Capacidade Fixa: O Array possui uma capacidade fixa, ou seja, ao atingir seu limite operações como o `push(object)` são inviáveis gerando problemas de **Overflow**. Dessa forma, é necessário implementar uma estratégia de redimensionamento do tamanho do Array.
      - Espaço não Utilizado: Inicialmente com a Pilha parcialmente vazia o espaço de memória reservado está sendo desperdiçado.

  - 📌 Estratégias para Redimensionanto de Pilhas
      - Quando o Array está cheio, ao invés de levantar uma exceção, acontece a subtituição de Array por um maior. 
      - Estratégia Incremental: Essa estratégia utiliza do aumento da capacidade do Array por um valor fixo cada vez que esse Array fica sem espaço. Embora seja simples, essa estratégia a longo prazo para um crescimento exponencial da Pilha pode causar ineficiência devido a alta alocação de memória.
          - Substituímos o Array `k = n/c` vezes (`k` = Quantidades de Subtituições; `n` = Quantidade de Elementos; `c` = Constante de Aumento do Array).
