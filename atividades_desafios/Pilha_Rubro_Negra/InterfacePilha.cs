interface Pilha<T>
{
    void aumentarCapacidade();
    void pushVermelho(T objeto);
    void pushPreto(T objeto);
    void reduzirCapacidade();
    T popVermelho();
    T popPreto();
    T topVermelho();
    T topPreto();
    void isEmptyVermelho();
    void isEmptyPreto();
    int size();
}