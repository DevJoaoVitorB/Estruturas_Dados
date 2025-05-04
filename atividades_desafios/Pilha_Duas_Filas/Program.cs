using System;
					
public class Program
{
	public static void Main()
	{
		PilhaDuasFilas<object> Pilha = new PilhaDuasFilas<object>(10);       // Inicializando a Pilha com 10 de Capacidade e Estrategia Duplicativa

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
                        Console.Write("Inserindo Valor à Pilha - Qual o Valor: ");
						object objeto = Console.ReadLine();
						Pilha.Push(objeto);
						break;
					case 2:
						Console.WriteLine($"Elemento Removido da Pilha -> {Pilha.Pop()}\n");
						break;
					case 3:
						Console.WriteLine($"Elemento do Inicio da Pilha -> {Pilha.Top()}\n");
						break;
					case 4:
						Pilha.ExibirPilhaArray();
						break;
					case 5:
						Console.WriteLine($"Quantidade de Elementos da Pilha -> {Pilha.Size()}\n");
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
		Console.WriteLine("------------- Operações da Pilha com Array -------------");
		Console.WriteLine("\n[1]Inserir Elemento na Pilha      [4]Exibir a Pilha");
		Console.WriteLine("[2]Remover Elemento da Pilha      [5]Quantidade de Elementos da Pilha");
		Console.WriteLine("[3]Primeiro Elemento da Pilha     [0]Sair\n");
		Console.Write("Informe uma Operação: ");		
		return int.Parse(Console.ReadLine());
	}
}