using System;
					
public class Program
{
	public static void Main()
	{
		FilaArrayList Fila = new FilaArrayList();		// Inicializando a Fila feita com ArrayList

		int valor = -1;
		while(valor != 0)
		{
			try
			{
				valor = Menu();
				Console.Clear();
				switch (valor)
				{
                    case 0:
                        break;
					case 1:
                        Console.Write("Inserindo Valor a Fila - Qual o Valor: ");
						object objeto; = Console.ReadLine();
						Fila.Dequeue(objeto);
						break;
					case 2:
						Console.WriteLine($"Elemento Removido da Fila -> {Fila.Enqueue()}\n");
						break;
					case 3:
						Console.WriteLine($"Elemento do Inicio da Fila -> {Fila.First()}\n");
						break;
					case 4:
						Fila.exibirFila();
						break;
					case 5:
						Console.WriteLine($"Quantidade de Elementos da Fila -> {Fila.Size()}\n");
						break;
					default:
						Console.WriteLine("Operação informada inexistente! \n");
						break;
				}
			} 
			catch (FilaVaziaExcecao ex) { Console.WriteLine(ex.Message); }
			catch (Exception) { Console.WriteLine($"Valor inválido para essa operação! \n"); }	
		}
	}
	
	public static int Menu()
	{
		Console.WriteLine("------------- Operações da Fila com ArrayList -------------");
		Console.WriteLine("\n[1]Inserir Elemento na Fila      [4]Exibir a Fila");
		Console.WriteLine("[2]Remover Elemento da Fila      [5]Quantidade de Elementos da Fila");
		Console.WriteLine("[3]Primeiro Elemento da Fila     [0]Sair\n");
		Console.Write("Informe uma Operação: ");		
		return int.tryParse(Console.ReadLine(), out valor);
	}
}