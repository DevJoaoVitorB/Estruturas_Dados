Teste<int> teste = new Teste<int>();
teste.Executar();

class Teste<T> where T : IComparable<T>
{
    public ArvoreBinariaPesquisa<int> arvore = new ArvoreBinariaPesquisa<int>();

    public void Executar()
    {
        arvore.Insert(8);
        arvore.Insert(3);
        arvore.Insert(10);
        arvore.Insert(1);
        arvore.Insert(6);
        arvore.Insert(4);
        arvore.Insert(7);
        arvore.Insert(14);
        arvore.Insert(13);

        arvore.Arvore();

        arvore.Remove(8);
        Console.WriteLine("\n");

        arvore.Arvore();
    }
}