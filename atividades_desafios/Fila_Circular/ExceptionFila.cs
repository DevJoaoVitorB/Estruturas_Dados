using System;

class FilaVaziaExcecao : Exception      // Classe de Exceção de Fila Vazia
{
  public FilaVaziaExcecao() : base("A Fila está vazia!") {}
  public FilaVaziaExcecao(string mensagem) : base(mensagem) {}
  public FilaVaziaExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}