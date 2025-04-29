interface Pilha<T>
{
    void AumentarCapacidade();
    void PushVermelho(T objeto);
    void PushPreto(T objeto);
    void ReduzirCapacidade();
    T PopVermelho();
    T PopPreto();
    T TopVermelho();
    T TopPreto();
    void IsEmptyVermelho();
    void IsEmptyPreto();
    int Size();
}