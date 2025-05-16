using System;

class ListaVaziaExcecao : Exception                 // Classe de Exceção de Lista Vazia
{
    public ListaVaziaExcecao() : base("A Lista está vazia!") {}
    public ListaVaziaExcecao(string mensagem) : base(mensagem) {}
    public ListaVaziaExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}

class ObjetoNaoEncontradoExcecao : Exception         // Classe de Exceção de Objeto não Encontrado na Lista
{
    public ObjetoNaoEncontradoExcecao() : base("Objeto não foi encontrado na Lista!") {}
    public ObjetoNaoEncontradoExcecao(string mensagem) : base(mensagem) {}
    public ObjetoNaoEncontradoExcecao(string mensagem, Exception inner) : base(mensagem, inner) {}
}