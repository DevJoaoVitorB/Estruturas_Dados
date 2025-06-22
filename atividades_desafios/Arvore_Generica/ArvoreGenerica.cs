public class ArvoreGenerica<T> : IArvore<T> where T : IComparable<T>
{
    private Node<T> Root;

    public ArvoreGenerica(T elementRoot)
    {
        Root = new Node<T>(elementRoot);
    }

    // Métodos Genéricos
    public int Size() => Count(Root);
    private int Count(Node<T> node)
    {
        if (node == null)
            return 0;

        int contador = 1;
        IEnumerator<Node<T>> iterator = node.GetChildren();
        while (iterator.MoveNext())
            contador += Count((Node<T>)iterator.Current);

        return contador;
    }
    public bool IsEmpty() => Root == null;
    public IEnumerator<T> Elements()
    {
        List<T> elements = new List<T>();
        GetElements(Root, elements);
        return elements.GetEnumerator();
    }
    private void GetElements(Node<T> node, List<T> elements)
    {
        // Adicionar elemento do Nó atual na lista de elementos
        elements.Add(node.GetElement());

        // Criar um Enumerator com todos os filhos do Nó atual
        IEnumerator<Node<T>> iterator = Children(node);

        // Adicionar todos os elementos dos filhos do Nó atual
        while (iterator.MoveNext())
        {
            GetElements(iterator.Current, elements);
        }
    }
    public IEnumerator<Node<T>> Nodes()
    {
        List<Node<T>> nodes = new List<Node<T>>();
        GetNodes(Root, nodes);
        return nodes.GetEnumerator();
    }
    private void GetNodes(Node<T> node, List<Node<T>> nodes)
    {
        // Adicionar o Nó atual na lista de Nós
        nodes.Add(node);

        // Criar um Enumerator com todos os filhos do Nó atual
        IEnumerator<Node<T>> iterator = Children(node);

        // Adicionar todos os filhos do Nó atual
        while (iterator.MoveNext())
        {
            GetNodes(iterator.Current, nodes);
        }
    }

    // Métodos de Acesso
    public Node<T> GetRoot() => Root;
    public Node<T>? Parent(Node<T> child) => child.GetParent();
    public IEnumerator<Node<T>> Children(Node<T> parent) => parent.GetChildren();

    // Métodos de Consulta
    public bool IsRoot(Node<T>? node) => node == Root;
    public int Height(Node<T> node) => HeightCalc(node);
    private int HeightCalc(Node<T> node)
    {
        int height;
        IEnumerator<Node<T>> iterator;

        if (node.IsExternal())
            return 0;
        else
        {
            height = 0;
            iterator = Children(node);
            while (iterator.MoveNext())
            {
                Node<T> child = (Node<T>)iterator.Current;
                height = Math.Max(height, HeightCalc(child));
            }
            return 1 + height;
        }
    }
    public int Depth(Node<T> node) => DepthCalc(node);
    public int DepthCalc(Node<T>? node)
    {
        if (IsRoot(node))
            return 0;
        return 1 + DepthCalc(node.GetParent());
    }

    // Métodos de Atualização
    public void AddChild(Node<T> parent, T newElement)
    {
        Node<T> newChild = new Node<T>(newElement, parent);
        parent.AddChild(newChild);
    }
    public T? Remove(Node<T> node)
    {   
        Node<T> parent = node.GetParent();
        // Remove Apenas Nós Externos
        if (!IsRoot(parent) && node.IsExternal())
        {
            parent.RemoveChild(node);
            T element = node.GetElement();
            return element;
        }

        return default;
    }
    public void SwapElement(Node<T> node1, Node<T> node2)
    {
        (T element1, T element2) = (node1.GetElement(), node2.GetElement());
        node1.SetElement(element2);
        node2.SetElement(element1);
    }
    public T Replace(Node<T> node, T element)
    {
        T oldElement = node.GetElement();
        node.SetElement(element);
        return oldElement;
    }

    // Métodos de Travessia
    public void PreOrder() => PreOrderTraversal(Root);
    private void PreOrderTraversal(Node<T> node)
    {
        if (node == null) return;

        Console.Write(node.GetElement() + " - ");

        IEnumerator<Node<T>> iterator = node.GetChildren();
        while (iterator.MoveNext())
            PreOrderTraversal((Node<T>)iterator.Current);
    }

    public void PostOrder() => PostOrderTraversal(Root);
    private void PostOrderTraversal(Node<T> node)
    {
        if (node == null) return;

        IEnumerator<Node<T>> iterator = node.GetChildren();
        while (iterator.MoveNext())
            PostOrderTraversal((Node<T>)iterator.Current);

        Console.Write(node.GetElement() + " - ");
    }
}