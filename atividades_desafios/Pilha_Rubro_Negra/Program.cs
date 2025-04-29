using System;
					
public class Program
{
	public static void Main()
	{
		PilhaRubroNegra<object> Pilha = new PilhaRubroNegra<object>(10, 0);

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
					case 2:
						object objeto;

						if(valor == 1)
						{
							Console.Write("Inserindo Valor Vermelho - Qual o Valor: ");
							objeto = Console.ReadLine();
							Pilha.PushVermelho(objeto);
						} else 
						{
							Console.Write("Inserindo Valor Preto - Qual o Valor: ");
							objeto = Console.ReadLine();
							Pilha.PushPreto(objeto);
						}

						break;
					case 3:
					case 4:
						if(valor == 3) Console.WriteLine($"Elemento Vermelho Removido -> {Pilha.PopVermelho()}\n");
						else Console.WriteLine($"Elemento Preto Removido -> {Pilha.PopPreto()}\n");
						break;
					case 5:
					case 6:
						if(valor == 5) Console.WriteLine($"Elemento do Topo Vermelho -> {Pilha.TopVermelho()}\n");
						else Console.WriteLine($"Elemento do Topo Preto -> {Pilha.TopPreto()}\n");
						break;
					case 7:
						Pilha.exibirPilhaRubroNegra();
						break;
					case 8:
						Console.WriteLine($"Quantidade de Elementos da Pilha Rubro-Negra -> {Pilha.Size()}\n");
						break;
					default:
						Console.WriteLine("Operação informada inexistente!");
						break;
				}
			} 
			catch (PilhaVaziaExcecao ex) { Console.WriteLine(ex.mensagem); }
			catch (Exception) { Console.WriteLine($"Valor inválido para essa operação!"); }	
		}
	}
	
	public static int Menu()
	{
		Console.WriteLine("------------- Operações da PilhaArray Rubro-Negra -------------");
		Console.WriteLine("\n[1]Inserir Elemento Lado Vermelho   [5]Elemento do Topo Vermelho");
		Console.WriteLine("[2]Inserir Elemento Lado Preto      [6]Elemento do Topo Preto");
		Console.WriteLine("[3]Remover Elemento Lado Vermelho   [7]Exibir Pilha Rubro-Negra");
		Console.WriteLine("[4]Remover Elemento Lado Preto      [8]Quantidade de Elementos da Pilha Rubro-Negra");
		Console.WriteLine("[0]Sair\n");
		Console.Write("Informe uma Operação: ");		
		return int.Parse(Console.ReadLine());
	}
}