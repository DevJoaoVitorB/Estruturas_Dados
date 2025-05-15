using System;

class PilhaVaziaExcecao : Exception         // Classe de Exceção de Pilha Vazia
{
  public PilhaVaziaExcecao() : base("A Pilha está vazia!") {}
  public PilhaVaziaExcecao(string mensagem) : base(mensagem) {}
  public PilhaVaziaExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}