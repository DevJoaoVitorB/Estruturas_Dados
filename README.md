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

## 📁 Arquivos de TADs
1. [TAD - Pilha](arquivos/pilha.md)
2. [TAD - Fila](arquivos/fila.md) 

> ✅ **Resumo:** TADs, como a pilha e a fila, facilitam a construção de sistemas robustos por meio da **separação entre interface e implementação**.
