using System;
using System.Collections;

class FilaArrayList : Fila
{
    private ArrayList FilaArray;                        // ArrayList Fila

    public FilaArrayList()
    {
        FilaArray = new ArrayList();                    // Inicializando a FilaArrayList
    }

    public void Enqueue(object objeto)
    {
        FilaArray.Add(objeto);
    }

    public object Dequeue()
    {
        if(IsEmpty()) throw new FilaVaziaExcecao();     // Verificar se a FilaArray está vazia

        object removido = FilaArray[0];                 // Primeiro elemento da FilaArray
        FilaArray.RemoveAt(0);                          // Remover o primeiro elemento da FilaArray e deslocar todos os elementos para a esquerda
        return removido;                                // Retorna o elemento removido
    }

    public object First()
    {
        if(IsEmpty()) throw new FilaVaziaExcecao();     // Verificar se a FilaArray está vazia

        return FilaArray[0];
    }

    public bool IsEmpty()
    {
        return FilaArray.Count == 0;                    // Verifica se possui elementos na FilaArray
    }

    public int Size()
    {
        return FilaArray.Count;                         // Retorna a quantidade de elementos na FilaArray
    }

    public void ExibirFilaArrayList()
	{
		Console.WriteLine("Fila usando ArrayList");

		for (int i = 0; i < FilaArray.Count; i++)					// Exibir todos os elementos da FilaArray
		{
			if (i == 0)											    // Exibir o primeiro elemento da FilaArray
			{
				Console.ForegroundColor = ConsoleColor.Green;            
				Console.Write($"| {FilaArray[i]} |");
				Console.ResetColor();
			}
			else													// Exibir os elementos da FilaArray
			{            
				Console.Write($"| {FilaArray[i]} |");
			}
		}

		Console.WriteLine("\n");
	} 
}