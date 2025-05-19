using System;
					
public class Program
{
	public static void Main()
	{
		VetorListaDuplamenteLigada<object> Vetor = new VetorListaDuplamenteLigada<object>();       // Inicializando o Vetor

		int valor = -1;
		while(valor != 0)
		{
			try
			{
				valor = Menu();
				Console.Clear();
                
                object objeto;   //  Variavel para guarda os objetos a serem colocados no Vetor
                int posicao;     //  Variavel para guarda a posição de um objeto do Vetor

				switch (valor)
                {
                    case 0:
                        break;
                    case 1:
                        Vetor.ExibirVetor();
                        Console.Write("Posição de Referência - Qual a Posição: ");
                        posicao = int.Parse(Console.ReadLine());
                        Console.Write("\nInserindo Valor na Posição de Referência - Qual o Valor: ");
                        objeto = Console.ReadLine();
                        Vetor.InsertAtRank(posicao, objeto);
                        break;
                    case 2:
                        Vetor.ExibirVetor();
                        Console.Write("Remover Valor da Posição X - Qual a Posição: ");
                        posicao = int.Parse(Console.ReadLine());
                        Console.WriteLine($"\nValor Removido do Vetor -> {Vetor.RemoveAtRank(posicao)} \n");
                        break;
                    case 3:
                        Vetor.ExibirVetor();
                        Console.Write("Posição do Valor à Substituir - Qual a Posição: ");
                        posicao = int.Parse(Console.ReadLine());
                        Console.Write("\nValor Substituto - Qual o Valor: ");
                        objeto = Console.ReadLine();
                        Console.WriteLine($"\nValor Substituido do Vetor -> {Vetor.ReplaceAtRank(posicao, objeto)} \n");
                        break;
                    case 4:
                        Vetor.ExibirVetor();
                        Console.Write("Posição do Valor do Vetor - Qual a Posição: ");
                        posicao = int.Parse(Console.ReadLine());
                        Console.WriteLine($"\nValor na Posição {posicao} do Vetor -> {Vetor.ElemAtRank(posicao)} \n");
                        break;
                    case 5:
                        Console.WriteLine($"A Vetor possui {Vetor.Size()} Elementos! \n");
                        break;
                    case 6:
                        Vetor.ExibirVetor();
                        break;
                    default:
                        Console.WriteLine("Operação informada inexistente! \n");
                        break;
                }
			} 
			catch (VetorVazioExcecao ex) { Console.WriteLine(ex.Message); }
			catch (PosicaoInvalidaExcecao  ex) { Console.WriteLine(ex.Message); }
			catch (Exception) { Console.WriteLine($"Valor inválido para essa operação! \n"); }	
		}
	}
	
	public static int Menu()
	{
		Console.WriteLine("-------------------- Operações da Vetor com Lista Duplamente Ligada --------------------");
		Console.WriteLine("\n[1]Inserir Elemento no Vetor    [4]Exibir Elemento do Vetor");
		Console.WriteLine("[2]Remover Elemento do Vetor    [5]Quantidade de Elementos no Vetor");
		Console.WriteLine("[3]Substituir Elemento do Vetor [6]Exibir Elementos do Vetor");
		Console.WriteLine("[0]Sair\n");
		Console.Write("Informe uma Operação: ");		
		return int.Parse(Console.ReadLine());
	}
}