using System.Collections;

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
        IEnumerator iterator = node.GetChildren();
        while (iterator.MoveNext())
            contador += Count((Node<T>)iterator.Current);

        return contador;
    }
    public bool IsEmpty() => Root == null;
    public IEnumerator<T> Elements(Node<T> node)
    {
        List<T> elements = new List<T>();

        // Adicionar elemento do Nó atual na lista de elementos
        elements.Add(node.GetElement());

        // Criar um Enumerator com todos os filhos do Nó atual
        IEnumerator iterator = Children(node);

        // Adicionar todos os elementos dos filhos dos filhos do Nó atual
        while (iterator.MoveNext())
        {
            // Filho atual
            Node<T> child = (Node<T>)iterator.Current;

            // Criar um Enumerator com todos os elementos dos filhos do filho atual
            IEnumerator subElements = Elements(child);
            while (subElements.MoveNext())
                // Adicionar todos os elementos dos filhos do filho atual na lista de elementos
                elements.Add((T)subElements.Current);
        }

        return elements.GetEnumerator();
    }
    public IEnumerator<Node<T>> Nodes(Node<T> node)
    {
        List<Node<T>> nodes = new List<Node<T>>();

        // Adicionar o Nó atual na lista de Nós
        nodes.Add(node);

        // Criar um Enumerator com todos os filhos do Nó atual
        IEnumerator iterator = Children(node);

        // Adicionar todos os filhos dos filhos do Nó atual
        while (iterator.MoveNext())
        {
            // Filho atual
            Node<T> child = (Node<T>)iterator.Current;

            // Criar um Enumerator com todos os filhos do filho atual
            IEnumerator subElements = Nodes(child);
            while (subElements.MoveNext())
                // Adicionar todos os filhos do filho atual na lista de Nós
                nodes.Add((Node<T>)subElements.Current);
        }

        return nodes.GetEnumerator();
    }

    // Métodos de Acesso
    public Node<T> GetRoot() => Root;
    public Node<T>? Parent(Node<T> child) => child.GetParent();
    public IEnumerator Children(Node<T> parent) => parent.GetChildren();

    // Métodos de Consulta
    public bool IsRoot(Node<T>? node) => node == Root;
    public int Height(Node<T> node) => HeightCalc(node);
    private int HeightCalc(Node<T> node)
    {
        int height;
        IEnumerator iterator;

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
    public int DepthCalc(Node<T> node)
    {
        if (IsRoot(node))
            return 0;
        else
            return 1 + DepthCalc(node.GetParent());
    }

    // Métodos de Atualização
    public void AddChild(Node<T> parent, T newElement)
    {
        Node<T> newChild = new Node<T>(newElement, parent);
        parent.AddChild(newChild);
    }
    public T? RemoveChild(Node<T> child)
    {
        Node<T> parent = child.GetParent();
        if (!IsRoot(parent) && child.IsExternal())
        {
            parent.RemoveChild(child);
            T elementChild = child.GetElement();
            return elementChild;
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

        IEnumerator iterator = node.GetChildren();
        while (iterator.MoveNext())
            PreOrderTraversal((Node<T>)iterator.Current);
    }

    public void PostOrder() => PostOrderTraversal(Root);
    private void PostOrderTraversal(Node<T> node)
    {
        if (node == null) return;

        IEnumerator iterator = node.GetChildren();
        while (iterator.MoveNext())
            PostOrderTraversal((Node<T>)iterator.Current);

        Console.Write(node.GetElement() + " - ");
    }
}