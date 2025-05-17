using System;
					
public class Program
{
	public static void Main()
	{
		ListaDuplamenteLigada<object> Lista = new ListaDuplamenteLigada<object>();       // Inicializando a Lista

		int valor = -1;
		while(valor != 0)
		{
			try
			{
				valor = Menu();
				Console.Clear();
                
                object objeto;      //  Variavel para guarda os objetos a serem colocados na Lista
                object objetoRef;   //  Variavel para guarda os objetos de referência
                object objetoRef2;  //  Variavel para guarda os objetos de referência (Caso haja 2 objetos de referência)

				switch (valor)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Write("Inserindo Valor ao Inicio da Lista - Qual o Valor: ");
                        objeto = Console.ReadLine();
                        Lista.InsertFirst(objeto);
                        break;
                    case 2:
                        Console.Write("Inserindo Valor ao Final da Lista - Qual o Valor: ");
                        objeto = Console.ReadLine();
                        Lista.InsertLast(objeto);
                        break;
                    case 3:
                        Lista.ExibirLista();
                        Console.Write("Valor de Referência - Qual o Valor: ");
                        objetoRef = Console.ReadLine();
                        Console.Write("\nInserindo Valor Posterior - Qual o Valor: ");
                        objeto = Console.ReadLine();
                        Lista.InsertAfter(objetoRef, objeto);
                        break;
                    case 4:
                        Lista.ExibirLista();
                        Console.Write("Valor de Referência - Qual o Valor: ");
                        objetoRef = Console.ReadLine();
                        Console.Write("\nInserindo Valor Anterior - Qual o Valor: ");
                        objeto = Console.ReadLine();
                        Lista.InsertBefore(objetoRef, objeto);
                        break;
                    case 5:
                        Lista.ExibirLista();
                        Console.Write("Valor à Substituir - Qual o Valor: ");
                        objetoRef = Console.ReadLine();
                        Console.Write("\nValor Substituto - Qual o Valor: ");
                        objeto = Console.ReadLine();
                        Console.WriteLine($"\nValor Substituido da Lista -> {Lista.ReplaceElement(objetoRef, objeto)} \n");
                        break;
                    case 6:
                        Lista.ExibirLista();
                        Console.Write("Primeiro Valor da Troca - Qual o Valor: ");
                        objetoRef = Console.ReadLine();
                        Lista.ExibirLista();
                        Console.Write("\nSegundo Valor da Troca - Qual o Valor: ");
                        objetoRef2 = Console.ReadLine();
                        Lista.SwapElement(objetoRef, objetoRef2);
                        break;
                    case 7:
                        Lista.ExibirLista();
                        Console.Write("Remover Valor - Qual o Valor: ");
                        objetoRef = Console.ReadLine();
                        Console.WriteLine($"\nValor Removido da Lista -> {Lista.Remove(objetoRef)} \n");
                        break;
                    case 8:
                        Console.WriteLine($"A Lista possui {Lista.Size()} Elementos! \n");
                        break;
                    case 9:
                        Lista.ExibirLista();
                        break;
                    default:
                        Console.WriteLine("Operação informada inexistente! \n");
                        break;
                }
			} 
			catch (ListaVaziaExcecao ex) { Console.WriteLine(ex.Message); }
			catch (ObjetoNaoEncontradoExcecao ex) { Console.WriteLine(ex.Message); }
			catch (Exception) { Console.WriteLine($"Valor inválido para essa operação! \n"); }	
		}
	}
	
	public static int Menu()
	{
		Console.WriteLine("-------------------- Operações da Lista Duplamente Ligada --------------------");
		Console.WriteLine("\n[1]Inserir Elemento no Inicio da Lista      [6]Troca Elementos da Lista");
		Console.WriteLine("[2]Inserir Elemento no Final da Lista       [7]Remover Elemento da Lista");
		Console.WriteLine("[3]Inserir Elemento Depois de:              [8]Quantidade de Elementos na Lista");
		Console.WriteLine("[4]Inserir Elemento Antes de:               [9]Exibir Elementos da Lista");
		Console.WriteLine("[5]Substituir Elemento da Lista             [0]Sair\n");
		Console.Write("Informe uma Operação: ");		
		return int.Parse(Console.ReadLine());
	}
}