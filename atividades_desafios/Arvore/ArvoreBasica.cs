public class ArvoreBasica<T> : IArvore<T>
{
    Node<T> Raiz;

    public ArvoreBasica(T element)
    {
        Raiz = new Node<T>(element, default);
    }

    public Node<T> Root() => Raiz;
    public Node<T> Parent(Node<T> child) => child.GetParent();
    public IEnumerator<T> Children(Node<T> parent) => (IEnumerator<T>)parent.GetChildren();
    public bool IsInternal(Node<T> node) => node.ChildrenNumber() > 0;
    public bool IsExternal(Node<T> node) => node.ChildrenNumber() == 0;
    public bool IsRoot(Node<T> node) => node == Raiz;
}