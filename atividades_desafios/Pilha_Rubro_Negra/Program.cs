using System;
					
public class Program
{
	public static void Main()
	{
		PilhaRubroNegra<object> pilha = new PilhaRubroNegra<object>(10, 0);
		int valor = -1;
		while(valor != 0)
		{
			try
			{
				valor = menu();
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
							pilha.pushVermelho(objeto);
						} else 
						{
							Console.Write("Inserindo Valor Preto - Qual o Valor: ");
							objeto = Console.ReadLine();
							pilha.pushPreto(objeto);
						}

						break;
					case 3:
					case 4:
						if(valor == 3) Console.WriteLine($"Elemento Vermelho Removido -> {pilha.popVermelho()}\n");
						else Console.WriteLine($"Elemento Preto Removido -> {pilha.popPreto()}\n");
						break;
					case 5:
					case 6:
						if(valor == 5) Console.WriteLine($"Elemento do Topo Vermelho -> {pilha.topVermelho()}\n");
						else Console.WriteLine($"Elemento do Topo Preto -> {pilha.topPreto()}\n");
						break;
					case 7:
						pilha.exibirPilhaRubroNegra();
						break;
					case 8:
						Console.WriteLine($"Quantidade de Elementos da Pilha Rubro-Negra -> {pilha.size()}\n");
						break;
					default:
						Console.WriteLine("Operação informada inexistente!");
						break;
				}
			} 
			catch (PilhaVaziaExcecao mensagem) { Console.WriteLine(mensagem); }
			catch (Exception) { Console.WriteLine($"Valor inválido para essa operação!"); }	
		}
	}
	
	public static int menu()
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