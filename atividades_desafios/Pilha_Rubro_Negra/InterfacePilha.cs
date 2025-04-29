interface Pilha<T>
{
    void AumentarCapacidade();          // Aumentar a Capacidade da Pilha caso esteja cheia (Estratégia Incremental ou Duplicativa)
    void PushVermelho(T objeto);        // Inserir elementos da Esquerda para Direita lado Vermelho
    void PushPreto(T objeto);           // Inserir elementos da Direita para Esquerda lado Preto
    void ReduzirCapacidade();           // Reduzir a Capacidade da Pilha caso possua 1/3 da sua Capacidade ocupada (Diminuir Capacidade pela Metade)
    T PopVermelho();                    // Remover Elemento do lado Vermelho
    T PopPreto();                       // Remover Elemento do lado Preto
    T TopVermelho();                    // Retorna Elemento do topo Vermelho
    T TopPreto();                       // Retorna Elemento do topo Preto
    void IsEmptyVermelho();             // Verificar se a Pilha Vermelha está vazia
    void IsEmptyPreto();                // Verificar se a Pilha Preta está vazia
    int Size();                         // Verificar a quantidade de Elementos de ambos os lados (Vermelho e Preto)
}