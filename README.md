<h1 align="center">Estruturas de Dados Lineares</h1>

<h2>Conteúdo</h2>

  -  Tipos Abstratos de Dados(TADs)
      - Abstração de uma Estrutura de Dados
      - Pilha: Armazenamento de Objetos Arbitrários(OBJECT)
          - Inserção e Remoção: Esquema LIFO (Último a Entra - Primeiro a Sair)
          - Exemplo: Pilha de Pratos, Retorna do Browser etc.
          - Métodos:
              - `push(object)`: Inserir Elementos
              - `object pop()`: Remover e Retorna o Último Elemento Inserido
          - Métodos Auxiliares:
              - `object top()`: Apenas Retorna o Último Elemento Inserido
              - `integer size()`: Retorna o Número de Elementos Armazenados
              - `boolean isEmpty()`: Indica se há ou não Elementos na Pilha
          - Exceções:
              - Casos de Excessões: Acessar Objeto Inexistênte e Acessar o Topo da Pilha
          - Aplicações:
          - Implementações:
              - Array    
