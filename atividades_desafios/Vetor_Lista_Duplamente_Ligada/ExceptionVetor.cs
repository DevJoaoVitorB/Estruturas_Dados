using System;

class VetorVazioExcecao : Exception         // Classe de Exceção de Vetor Vazio
{
    public VetorVazioExcecao() : base("O Vetor esta vazio!") {}
    public VetorVazioExcecao(string mensagem) : base(mensagem) {}
    public VetorVazioExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}

class PosicaoInvalidaExcecao : Exception    // Classe de Exceção de Posição Inválida no Vetor
{
    public PosicaoInvalidaExcecao() : base("Posição informada invalida!") {}
    public PosicaoInvalidaExcecao(string mensagem) : base(mensagem) {}
    public PosicaoInvalidaExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}