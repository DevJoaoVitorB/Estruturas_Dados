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
  - Tipos de TADs:
      1. [Pilha](https://github.com/DevJoaoVitorB/Estruturas_Dados_Lineares/tree/tad-pilha).
      2. [Fila](https://github.com/DevJoaoVitorB/Estruturas_Dados_Lineares/tree/tad-fila).
